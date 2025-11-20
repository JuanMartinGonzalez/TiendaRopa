using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class TalleDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public TalleDAL() => _conexion = new ConexionBD();

        public List<Talle> ObtenerTodos()
        {
            var lista = new List<Talle>();
            string sql = "SELECT TalleId, Talles FROM Talles ORDER BY TRY_CAST(Talles AS INT), Talles";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Talle
                    {
                        TalleId = rdr.GetInt32(0),
                        Talles = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1)
                    });
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return lista;
        }

        public Talle ObtenerPorId(int id)
        {
            Talle item = null;
            string sql = "SELECT TalleId, Talles FROM Talles WHERE TalleId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                using var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    item = new Talle
                    {
                        TalleId = rdr.GetInt32(0),
                        Talles = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1)
                    };
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return item;
        }

        public int Insertar(Talle t)
        {
            string sql = @"INSERT INTO Talles (Talles) VALUES (@Talles); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Talles", SqlDbType.NVarChar, 50).Value = t.Talles ?? string.Empty;
                conn.Open();
                object res = cmd.ExecuteScalar();
                return res == null ? -1 : Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(Talle t)
        {
            string sql = "UPDATE Talles SET Talles = @Talles WHERE TalleId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Talles", SqlDbType.NVarChar, 50).Value = t.Talles ?? string.Empty;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = t.TalleId;
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM Talles WHERE TalleId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
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