using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class ComprasProductosDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public ComprasProductosDAL() => _conexion = new ConexionBD();
        internal ComprasProductosDAL(ConexionBD conexion) => _conexion = conexion;

        public List<CompraDetalle> ObtenerPorCompra(int compraId)
        {
            var lista = new List<CompraDetalle>();
            string sql = @"SELECT CompraId, ProductoId, Cantidad, Precio
                           FROM ComprasProductos
                           WHERE CompraId = @CompraId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = compraId;
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new CompraDetalle
                    {
                        CompraId = rdr.GetInt32(0),
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

        public bool InsertarDetalle(CompraDetalle detalle)
        {
            string sql = @"INSERT INTO ComprasProductos (CompraId, ProductoId, Cantidad, Precio)
                           VALUES (@CompraId, @ProductoId, @Cantidad, @Precio)";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = detalle.CompraId;
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

        // Inserción usada dentro de una transacción por ComprasDAL
        internal bool InsertarDetalleTransactional(CompraDetalle detalle, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"INSERT INTO ComprasProductos (CompraId, ProductoId, Cantidad, Precio)
                           VALUES (@CompraId, @ProductoId, @Cantidad, @Precio)";
            try
            {
                using var cmd = new SqlCommand(sql, conn, tx);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = detalle.CompraId;
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

        public bool EliminarDetallesPorCompra(int compraId)
        {
            string sql = "DELETE FROM ComprasProductos WHERE CompraId = @CompraId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = compraId;
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