using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class VentasDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public VentasDAL() => _conexion = new ConexionBD();
        internal VentasDAL(ConexionBD conexion) => _conexion = conexion;

        /// <summary>
        /// Crea una venta con sus detalles (productos y talles) en una sola transacción.
        /// Valida stock disponible antes de insertar. Devuelve VentaId o -1 en error.
        /// </summary>
        public int CrearVentaConDetalles(Venta venta)
        {
            if (venta == null) { Error = "Venta nula"; return -1; }

            string sqlInsertVenta = @"INSERT INTO Ventas (ClienteId, Fecha)
                                      VALUES (@ClienteId, @Fecha);
                                      SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using var conn = _conexion.ObtenerConexion();
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                // validar que existan líneas
                if ((venta.Detalles == null || venta.Detalles.Count == 0) &&
                    (venta.DetallesTalle == null || venta.DetallesTalle.Count == 0))
                {
                    throw new Exception("La venta debe contener al menos una línea.");
                }

                // Validar stock agregado por producto/talle
                // Calculamos cantidades por producto y por product+talle que se intentan vender
                var requeridosPorProducto = new Dictionary<int, int>();
                var requeridosPorProductoTalle = new Dictionary<(int productoId, int talleId), int>();

                if (venta.Detalles != null)
                {
                    foreach (var d in venta.Detalles)
                    {
                        if (!requeridosPorProducto.ContainsKey(d.ProductoId))
                            requeridosPorProducto[d.ProductoId] = 0;
                        requeridosPorProducto[d.ProductoId] += d.Cantidad;
                    }
                }

                if (venta.DetallesTalle != null)
                {
                    foreach (var t in venta.DetallesTalle)
                    {
                        var key = (t.ProductoId, t.TalleId);
                        if (!requeridosPorProductoTalle.ContainsKey(key))
                            requeridosPorProductoTalle[key] = 0;
                        requeridosPorProductoTalle[key] += t.Cant;
                    }
                }

                // Validación: para cada product+talle comprobar stockTalle >= requeridoTalle
                foreach (var kv in requeridosPorProductoTalle)
                {
                    int productoId = kv.Key.productoId;
                    int talleId = kv.Key.talleId;
                    int requerido = kv.Value;
                    int stock = GetStockProductoTalleTransactional(productoId, talleId, conn, tx);
                    if (stock < requerido)
                        throw new Exception($"Stock insuficiente para ProductoId={productoId} TalleId={talleId}. Disponible={stock}, requerido={requerido}");
                }

                // Para productos sin talle: comprobar stock agregado por producto (excluyendo talles)
                // Nota: si existen both (talles + sin talle) y la política es mezclarlos, adaptá la validación.
                foreach (var kv in requeridosPorProducto)
                {
                    int productoId = kv.Key;
                    int requerido = kv.Value;
                    int stock = GetStockProductoTransactional(productoId, conn, tx);
                    if (stock < requerido)
                        throw new Exception($"Stock insuficiente para ProductoId={productoId}. Disponible={stock}, requerido={requerido}");
                }

                // Insertar cabecera
                using (var cmd = new SqlCommand(sqlInsertVenta, conn, tx))
                {
                    cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = venta.ClienteId;
                    cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = venta.Fecha;
                    object result = cmd.ExecuteScalar();
                    if (result == null) throw new Exception("No se pudo insertar cabecera de venta.");
                    venta.VentaId = Convert.ToInt32(result);
                }

                // Insertar detalles productos
                var ventasProductosDal = new VentasProductoDAL(_conexion);
                foreach (var d in venta.Detalles)
                {
                    d.VentaId = venta.VentaId;
                    if (!ventasProductosDal.InsertarDetalleTransactional(d, conn, tx))
                        throw new Exception(ventasProductosDal.Error ?? "Error al insertar detalle producto.");
                }

                // Insertar detalles por talle
                var ventasTallesDal = new VentasTallesDAL(_conexion);
                foreach (var t in venta.DetallesTalle)
                {
                    t.VentaId = venta.VentaId;
                    if (!ventasTallesDal.InsertarDetalleTransactional(t, conn, tx))
                        throw new Exception(ventasTallesDal.Error ?? "Error al insertar detalle por talle.");
                }

                tx.Commit();
                return venta.VentaId;
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
        /// Obtiene una venta con sus detalles y talles
        /// </summary>
        public Venta ObtenerPorId(int ventaId)
        {
            Venta venta = null;
            string sql = @"SELECT VentaId, ClienteId, Fecha FROM Ventas WHERE VentaId = @VentaId";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = ventaId;
                conn.Open();
                using var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    venta = new Venta
                    {
                        VentaId = rdr.GetInt32(0),
                        ClienteId = rdr.GetInt32(1),
                        Fecha = rdr.GetDateTime(2)
                    };
                }
                if (venta != null)
                {
                    var prodDal = new VentasProductoDAL(_conexion);
                    venta.Detalles = prodDal.ObtenerPorVenta(ventaId);

                    var talleDal = new VentasTallesDAL(_conexion);
                    venta.DetallesTalle = talleDal.ObtenerPorVenta(ventaId);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return venta;
        }

        /// <summary>
        /// Lista ventas (sin detalles) entre fechas; si clienteId = 0 no filtra por cliente
        /// </summary>
        public List<Venta> ObtenerTodos(DateTime desde, DateTime hasta, int clienteId = 0)
        {
            var lista = new List<Venta>();
            string sql = @"SELECT VentaId, ClienteId, Fecha
                           FROM Ventas
                           WHERE Fecha BETWEEN @Desde AND @Hasta"
                         + (clienteId > 0 ? " AND ClienteId = @ClienteId" : "")
                         + " ORDER BY Fecha DESC";

            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value = desde;
                cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value = hasta;
                if (clienteId > 0) cmd.Parameters.Add("@ClienteId", SqlDbType.Int).Value = clienteId;
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Venta
                    {
                        VentaId = rdr.GetInt32(0),
                        ClienteId = rdr.GetInt32(1),
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
        /// Elimina físicamente una venta (cuidado: elimina también detalles por FK en BD si cascade)
        /// </summary>
        public bool EliminarVenta(int ventaId)
        {
            string sql = "DELETE FROM Ventas WHERE VentaId = @VentaId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = ventaId;
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

        #region Validación de stock (consultas internas)

        // Stock total para producto sin talles (ComprasProductos - VentasProducto)
        private int GetStockProductoTransactional(int productoId, SqlConnection conn, SqlTransaction tx)
        {
            string sqlCompras = "SELECT ISNULL(SUM(Cantidad),0) FROM ComprasProductos WHERE ProductoId = @ProductoId";
            string sqlVentas = "SELECT ISNULL(SUM(Cantidad),0) FROM VentasProducto WHERE ProductoId = @ProductoId";

            using var cmdC = new SqlCommand(sqlCompras, conn, tx);
            cmdC.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
            int totalCompras = Convert.ToInt32(cmdC.ExecuteScalar());

            using var cmdV = new SqlCommand(sqlVentas, conn, tx);
            cmdV.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
            int totalVentas = Convert.ToInt32(cmdV.ExecuteScalar());

            return totalCompras - totalVentas;
        }

        // Stock para producto por talle (ComprasTalles - VentasTalles)
        private int GetStockProductoTalleTransactional(int productoId, int talleId, SqlConnection conn, SqlTransaction tx)
        {
            string sqlCompras = "SELECT ISNULL(SUM(Cant),0) FROM ComprasTalles WHERE ProductoId = @ProductoId AND TalleId = @TalleId";
            string sqlVentas = "SELECT ISNULL(SUM(Cant),0) FROM VentasTalles WHERE ProductoId = @ProductoId AND TalleId = @TalleId";

            using var cmdC = new SqlCommand(sqlCompras, conn, tx);
            cmdC.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
            cmdC.Parameters.Add("@TalleId", SqlDbType.Int).Value = talleId;
            int totalCompras = Convert.ToInt32(cmdC.ExecuteScalar());

            using var cmdV = new SqlCommand(sqlVentas, conn, tx);
            cmdV.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;
            cmdV.Parameters.Add("@TalleId", SqlDbType.Int).Value = talleId;
            int totalVentas = Convert.ToInt32(cmdV.ExecuteScalar());

            return totalCompras - totalVentas;
        }

        #endregion
    }
}