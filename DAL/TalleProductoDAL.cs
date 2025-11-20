using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class TalleProductoDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public TalleProductoDAL() => _conexion = new ConexionBD();

        public List<Talle> ObtenerTallesPorProducto(int productoId)
        {
            var lista = new List<Talle>();
            string sql = @"
                SELECT t.TalleId, t.Talles
                FROM TalleProducto tp
                JOIN Talles t ON t.TalleId = tp.TalleId
                WHERE tp.ProductoId = @ProductoId
                ORDER BY TRY_CAST(t.Talles AS INT), t.Talles";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
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

        public bool AgregarTalleAProducto(int productoId, int talleId)
        {
            string sql = "INSERT INTO TalleProducto (TalleId, ProductoId) VALUES (@TalleId, @ProductoId)";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@TalleId", SqlDbType.Int).Value = talleId;
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
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

        public bool QuitarTalleDeProducto(int productoId, int talleId)
        {
            string sql = "DELETE FROM TalleProducto WHERE ProductoId = @ProductoId AND TalleId = @TalleId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
                cmd.Parameters.Add("@TalleId", SqlDbType.Int).Value = talleId;
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

        public bool ExisteTalleEnProducto(int productoId, int talleId)
        {
            string sql = "SELECT COUNT(1) FROM TalleProducto WHERE ProductoId = @ProductoId AND TalleId = @TalleId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
                cmd.Parameters.Add("@TalleId", SqlDbType.Int).Value = talleId;
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}