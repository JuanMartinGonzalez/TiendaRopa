using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class ProveedorDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public ProveedorDAL()
        {
            _conexion = new ConexionBD();
        }

        /// <summary>
        /// Devuelve todos los proveedores ordenados por Nombre
        /// </summary>
        public List<Proveedor> ObtenerTodos()
        {
            var lista = new List<Proveedor>();
            string sql = @"SELECT ProveedorId, Nombre, CUIT
                           FROM Proveedores
                           ORDER BY Nombre, ProveedorId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Proveedor
                    {
                        ProveedorId = rdr.GetInt32(0),
                        Nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        CUIT = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2)
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
        /// Obtiene un proveedor por id, o null si no existe
        /// </summary>
        public Proveedor ObtenerPorId(int proveedorId)
        {
            Proveedor prov = null;
            string sql = @"SELECT ProveedorId, Nombre, CUIT
                           FROM Proveedores
                           WHERE ProveedorId = @ProveedorId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = proveedorId;
                conn.Open();

                using var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    prov = new Proveedor
                    {
                        ProveedorId = rdr.GetInt32(0),
                        Nombre = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        CUIT = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2)
                    };
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return prov;
        }

        /// <summary>
        /// Inserta un nuevo proveedor y devuelve el nuevo ProveedorId. En error devuelve -1.
        /// </summary>
        public int InsertarProveedor(Proveedor prov)
        {
            string sql = @"
                INSERT INTO Proveedores (Nombre, CUIT)
                VALUES (@Nombre, @CUIT);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = prov.Nombre ?? string.Empty;
                cmd.Parameters.Add("@CUIT", SqlDbType.NVarChar, 50).Value = prov.CUIT ?? string.Empty;

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
        /// Modifica un proveedor existente. Devuelve true si se actualizó al menos 1 fila.
        /// </summary>
        public bool ModificarProveedor(Proveedor prov)
        {
            string sql = @"
                UPDATE Proveedores
                SET Nombre = @Nombre,
                    CUIT   = @CUIT
                WHERE ProveedorId = @ProveedorId;";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = prov.Nombre ?? string.Empty;
                cmd.Parameters.Add("@CUIT", SqlDbType.NVarChar, 50).Value = prov.CUIT ?? string.Empty;
                cmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = prov.ProveedorId;

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
        /// Elimina físicamente un proveedor por id. Devuelve true si se borró al menos 1 fila.
        /// </summary>
        public bool EliminarProveedor(int proveedorId)
        {
            string sql = @"DELETE FROM Proveedores WHERE ProveedorId = @ProveedorId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = proveedorId;

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