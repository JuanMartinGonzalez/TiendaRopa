using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;    
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class ClienteDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public ClienteDAL()
        {
            _conexion = new ConexionBD();
        }

        /// <summary>
        /// Devuelve todos los clientes ordenados por Nombre
        /// </summary>
        public List<Cliente> ObtenerTodos()
        {
            var lista = new List<Cliente>();
            string sql = @"SELECT ClienteId, Nombre, DNI
                           FROM Clientes
                           ORDER BY Nombre, ClienteId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Cliente
                    {
                        ClienteId = rdr.GetInt32(0),
                        Nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        DNI = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2)
                    });
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return lista;
        }

        /// <summary>
        /// Obtiene un cliente por id, o null si no existe
        /// </summary>
        public Cliente ObtenerPorId(int clienteId)
        {
            Cliente cliente = null;
            string sql = @"SELECT ClienteId, Nombre, DNI
                           FROM Clientes
                           WHERE ClienteId = @ClienteId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = clienteId;
                conn.Open();

                using var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    cliente = new Cliente
                    {
                        ClienteId = rdr.GetInt32(0),
                        Nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        DNI = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2)
                    };
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return cliente;
        }

        /// <summary>
        /// Inserta un nuevo cliente y devuelve el nuevo ClienteId. En error devuelve -1.
        /// </summary>
        public int InsertarCliente(Cliente cli)
        {
            string sql = @"
                INSERT INTO Clientes (Nombre, DNI)
                VALUES (@Nombre, @DNI);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = cli.Nombre ?? string.Empty;
                cmd.Parameters.Add("@DNI", SqlDbType.NVarChar, 50).Value = cli.DNI ?? string.Empty;

                object result = cmd.ExecuteScalar();
                return result == null ? -1 : Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// Modifica un cliente existente. Devuelve true si se actualizó al menos 1 fila.
        /// </summary>
        public bool ModificarCliente(Cliente cli)
        {
            string sql = @"
                UPDATE Clientes
                SET Nombre = @Nombre,
                    DNI    = @DNI
                WHERE ClienteId = @ClienteId;";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = cli.Nombre ?? string.Empty;
                cmd.Parameters.Add("@DNI", SqlDbType.NVarChar, 50).Value = cli.DNI ?? string.Empty;
                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = cli.ClienteId;

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Elimina físicamente un cliente por id. Devuelve true si se borró al menos 1 fila.
        /// </summary>
        public bool EliminarCliente(int clienteId)
        {
            string sql = @"DELETE FROM Clientes WHERE ClienteId = @ClienteId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = clienteId;

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}