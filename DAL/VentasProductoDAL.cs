using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class VentasProductoDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public VentasProductoDAL() => _conexion = new ConexionBD();
        internal VentasProductoDAL(ConexionBD conexion) => _conexion = conexion;

        public List<VentaDetalle> ObtenerPorVenta(int ventaId)
        {
            var lista = new List<VentaDetalle>();
            string sql = @"SELECT VentaId, ProductoId, Cantidad, Precio
                           FROM VentasProducto
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
                    lista.Add(new VentaDetalle
                    {
                        VentaId = rdr.GetInt32(0),
                        ProductoId = rdr.GetInt32(1),
                        Cantidad = rdr.GetInt32(2),
                        Precio = rdr.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return lista;
        }

        public bool InsertarDetalle(VentaDetalle detalle)
        {
            string sql = @"INSERT INTO VentasProducto (VentaId, ProductoId, Cantidad, Precio)
                           VALUES (@VentaId, @ProductoId, @Cantidad, @Precio)";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = detalle.VentaId;
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = detalle.ProductoId;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = detalle.Precio;
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
        internal bool InsertarDetalleTransactional(VentaDetalle detalle, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"INSERT INTO VentasProducto (VentaId, ProductoId, Cantidad, Precio)
                           VALUES (@VentaId, @ProductoId, @Cantidad, @Precio)";
            try
            {
                using var cmd = new SqlCommand(sql, conn, tx);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = detalle.VentaId;
                cmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = detalle.ProductoId;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detalle.Cantidad;
                cmd.Parameters.Add("@Precio", SqlDbType.Int).Value = detalle.Precio;
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool EliminarDetallesPorVenta(int ventaId)
        {
            string sql = "DELETE FROM VentasProducto WHERE VentaId = @VentaId";
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