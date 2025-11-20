using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class ComprasDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public ComprasDAL() => _conexion = new ConexionBD();

        /// <summary>
        /// Crea una compra con sus detalles (productos y talles) en una sola transacción.
        /// Devuelve CompraId o -1 en error.
        /// </summary>
        public int CrearCompraConDetalles(Compra compra)
        {
            if (compra == null) { Error = "Compra nula"; return -1; }

            string sqlInsertCompra = @"INSERT INTO Compras (ProveedorId, Fecha)
                                       VALUES (@ProveedorId, @Fecha);
                                       SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using var conn = _conexion.ObtenerConexion();
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                // Insertar cabecera
                using (var cmd = new SqlCommand(sqlInsertCompra, conn, tx))
                {
                    cmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = compra.ProveedorId;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = compra.Fecha;
                    object result = cmd.ExecuteScalar();
                    if (result == null) throw new Exception("No se pudo insertar cabecera de compra.");
                    compra.CompraId = Convert.ToInt32(result);
                }

                // Insertar detalles productos
                var comprasProductosDal = new ComprasProductosDAL(_conexion); // overload constructor used below
                foreach (var d in compra.Detalles)
                {
                    d.CompraId = compra.CompraId;
                    if (!comprasProductosDal.InsertarDetalleTransactional(d, conn, tx))
                        throw new Exception(comprasProductosDal.Error ?? "Error al insertar detalle producto.");
                }

                // Insertar detalles por talle
                var comprasTallesDal = new ComprasTallesDAL(_conexion);
                foreach (var t in compra.DetallesTalle)
                {
                    t.CompraId = compra.CompraId;
                    if (!comprasTallesDal.InsertarDetalleTransactional(t, conn, tx))
                        throw new Exception(comprasTallesDal.Error ?? "Error al insertar detalle por talle.");
                }

                tx.Commit();
                return compra.CompraId;
            }
            catch (Exception ex)
            {
                try { tx.Rollback(); } catch { }
                Error = ex.Message;
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Obtiene una compra con sus detalles y talles
        /// </summary>
        public Compra ObtenerPorId(int compraId)
        {
            Compra compra = null;
            string sql = @"SELECT CompraId, ProveedorId, Fecha FROM Compras WHERE CompraId = @CompraId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = compraId;
                conn.Open();
                using var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    compra = new Compra
                    {
                        CompraId = rdr.GetInt32(0),
                        ProveedorId = rdr.GetInt32(1),
                        Fecha = rdr.GetDateTime(2)
                    };
                }
                if (compra != null)
                {
                    var prodDal = new ComprasProductosDAL(_conexion);
                    compra.Detalles = prodDal.ObtenerPorCompra(compraId);

                    var talleDal = new ComprasTallesDAL(_conexion);
                    compra.DetallesTalle = talleDal.ObtenerPorCompra(compraId);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return compra;
        }

        /// <summary>
        /// Lista compras (sin detalles) entre fechas; si proveedorId = 0 no filtra por proveedor
        /// </summary>
        public List<Compra> ObtenerTodos(DateTime desde, DateTime hasta, int proveedorId = 0)
        {
            var lista = new List<Compra>();
            string sql = @"SELECT CompraId, ProveedorId, Fecha
                           FROM Compras
                           WHERE Fecha BETWEEN @Desde AND @Hasta"
                         + (proveedorId > 0 ? " AND ProveedorId = @ProveedorId" : "")
                         + " ORDER BY Fecha DESC";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value = hasta;
                if (proveedorId > 0) cmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = proveedorId;
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Compra
                    {
                        CompraId = rdr.GetInt32(0),
                        ProveedorId = rdr.GetInt32(1),
                        Fecha = rdr.GetDateTime(2)
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
        /// Elimina físicamente una compra (cuidado: elimina también detalles por FK en BD si cascade)
        /// </summary>
        public bool EliminarCompra(int compraId)
        {
            string sql = "DELETE FROM Compras WHERE CompraId = @CompraId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@CompraId", SqlDbType.Int).Value = compraId;
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

        // Constructor interno para que otros DALs reutilicen la misma ConexionBD sin exponerla publicamente
        internal ComprasDAL(ConexionBD conexion) { _conexion = conexion; }
    }
}