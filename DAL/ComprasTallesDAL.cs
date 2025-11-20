using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class ComprasTallesDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public ComprasTallesDAL() => _conexion = new ConexionBD();
        internal ComprasTallesDAL(ConexionBD conexion) => _conexion = conexion;

        public List<CompraTalle> ObtenerPorCompra(int compraId)
        {
            var lista = new List<CompraTalle>();
            string sql = @"SELECT CompraId, ProductoId, TalleId, Cant
                           FROM ComprasTalles
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
                    lista.Add(new CompraTalle
                    {
                        CompraId = rdr.GetInt32(0),
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

        public bool InsertarDetalle(CompraTalle detalle)
        {
            string sql = @"INSERT INTO ComprasTalles (CompraId, ProductoId, TalleId, Cant)
                           VALUES (@CompraId, @ProductoId, @TalleId, @Cant)";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = detalle.CompraId;
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

        // Inserción usada dentro de una transacción por ComprasDAL
        internal bool InsertarDetalleTransactional(CompraTalle detalle, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"INSERT INTO ComprasTalles (CompraId, ProductoId, TalleId, Cant)
                           VALUES (@CompraId, @ProductoId, @TalleId, @Cant)";
            try
            {
                using var cmd = new SqlCommand(sql, conn, tx);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = detalle.CompraId;
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

        public bool EliminarTallesPorCompra(int compraId)
        {
            string sql = "DELETE FROM ComprasTalles WHERE CompraId = @CompraId";
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