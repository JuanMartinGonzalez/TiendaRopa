using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class MarcaDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public MarcaDAL() => _conexion = new ConexionBD();

        public List<Marca> ObtenerTodos()
        {
            var lista = new List<Marca>();
            string sql = "SELECT MarcaId, Nombre FROM Marcas ORDER BY Nombre";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Marca
                    {
                        MarcaId = rdr.GetInt32(0),
                        Nombre = rdr.GetString(1)
                    });
                }
            }
            catch (Exception ex) { Error = ex.Message; }
            return lista;
        }

        public int Insertar(Marca m)
        {
            string sql = @"INSERT INTO Marcas (Nombre) VALUES (@Nombre);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = m.Nombre;
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex) { Error = ex.Message; return -1; }
        }

        public bool Modificar(Marca m)
        {
            string sql = "UPDATE Marcas SET Nombre = @Nombre WHERE MarcaId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150).Value = m.Nombre;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = m.MarcaId;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Error = ex.Message; return false; }
        }

        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM Marcas WHERE MarcaId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Error = ex.Message; return false; }
        }
    }
}