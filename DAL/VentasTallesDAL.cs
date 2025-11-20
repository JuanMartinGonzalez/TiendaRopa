using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class VentasTallesDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public VentasTallesDAL() => _conexion = new ConexionBD();
        internal VentasTallesDAL(ConexionBD conexion) => _conexion = conexion;

        public List<VentaTalle> ObtenerPorVenta(int ventaId)
        {
            var lista = new List<VentaTalle>();
            string sql = @"SELECT VentaId, ProductoId, TalleId, Cant
                           FROM VentasTalles
                           WHERE VentaId = @VentaId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = ventaId;
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new VentaTalle
                    {
                        VentaId = rdr.GetInt32(0),
                        ProductoId = rdr.GetInt32(1),
                        TalleId = rdr.GetInt32(2),
                        Cant = rdr.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return lista;
        }

        public bool InsertarDetalle(VentaTalle detalle)
        {
            string sql = @"INSERT INTO VentasTalles (VentaId, ProductoId, TalleId, Cant)
                           VALUES (@VentaId, @ProductoId, @TalleId, @Cant)";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = detalle.VentaId;
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = detalle.ProductoId;
                cmd.Parameters.Add("@TalleId", SqlDbType.Int).Value = detalle.TalleId;
                cmd.Parameters.Add("@Cant", SqlDbType.Int).Value = detalle.Cant;
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

        // Inserción usada dentro de una transacción por VentasDAL
        internal bool InsertarDetalleTransactional(VentaTalle detalle, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"INSERT INTO VentasTalles (VentaId, ProductoId, TalleId, Cant)
                           VALUES (@VentaId, @ProductoId, @TalleId, @Cant)";
            try
            {
                using var cmd = new SqlCommand(sql, conn, tx);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = detalle.VentaId;
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = detalle.ProductoId;
                cmd.Parameters.Add("@TalleId", SqlDbType.Int).Value = detalle.TalleId;
                cmd.Parameters.Add("@Cant", SqlDbType.Int).Value = detalle.Cant;
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool EliminarTallesPorVenta(int ventaId)
        {
            string sql = "DELETE FROM VentasTalles WHERE VentaId = @VentaId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = ventaId;
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows >= 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}