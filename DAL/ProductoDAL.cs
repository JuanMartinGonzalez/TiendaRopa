using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class ProductoDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public ProductoDAL() => _conexion = new ConexionBD();
        public class ProductoLoteInput //DTO
        {
            public string NombreModelo { get; set; }
            public int MarcaId { get; set; }
            public int TipoProductoId { get; set; }
            public List<int> TalleIds { get; set; } = new List<int>();
        }

        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            string sql = @"SELECT ProductoId, NombreModelo, MarcaId, TipoProductoId
                           FROM Productos
                           ORDER BY NombreModelo, ProductoId";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new Producto
                    {
                        ProductoId = rdr.GetInt32(0),
                        NombreModelo = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        MarcaId = rdr.GetInt32(2),
                        TipoProductoId = rdr.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return lista;
        }

        public Producto ObtenerPorId(int id)
        {
            Producto item = null;
            string sql = @"SELECT ProductoId, NombreModelo, MarcaId, TipoProductoId
                           FROM Productos
                           WHERE ProductoId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                using var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rdr.Read())
                {
                    item = new Producto
                    {
                        ProductoId = rdr.GetInt32(0),
                        NombreModelo = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        MarcaId = rdr.GetInt32(2),
                        TipoProductoId = rdr.GetInt32(3)
                    };
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return item;
        }

        public int Insertar(Producto p)
        {
            string sql = @"
                INSERT INTO Productos (NombreModelo, MarcaId, TipoProductoId)
                VALUES (@NombreModelo, @MarcaId, @TipoProductoId);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@NombreModelo", SqlDbType.NVarChar, 200).Value = p.NombreModelo ?? string.Empty;
                cmd.Parameters.Add("@MarcaId", SqlDbType.Int).Value = p.MarcaId;
                cmd.Parameters.Add("@TipoProductoId", SqlDbType.Int).Value = p.TipoProductoId;
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

        public bool Modificar(Producto p)
        {
            string sql = @"
                UPDATE Productos
                SET NombreModelo = @NombreModelo,
                    MarcaId = @MarcaId,
                    TipoProductoId = @TipoProductoId
                WHERE ProductoId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@NombreModelo", SqlDbType.NVarChar, 200).Value = p.NombreModelo ?? string.Empty;
                cmd.Parameters.Add("@MarcaId", SqlDbType.Int).Value = p.MarcaId;
                cmd.Parameters.Add("@TipoProductoId", SqlDbType.Int).Value = p.TipoProductoId;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = p.ProductoId;
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
            string sql = "DELETE FROM Productos WHERE ProductoId = @Id";
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
        public bool InsertarLoteConTalles(List<ProductoLoteInput> lote)
        {
            Error = null;

            if (lote == null || lote.Count == 0)
            {
                Error = "El lote de productos está vacío.";
                return false;
            }

            try
            {
                using var conn = _conexion.ObtenerConexion();
                conn.Open();

                using var tx = conn.BeginTransaction();

                try
                {
                    foreach (var item in lote)
                    {
                        if (item == null)
                            throw new InvalidOperationException("Item nulo en el lote.");

                        // 1) Insertar producto
                        const string sqlProducto = @"
                            INSERT INTO Productos (NombreModelo, MarcaId, TipoProductoId)
                            VALUES (@NombreModelo, @MarcaId, @TipoProductoId);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int nuevoProductoId;
                        using (var cmdProd = new SqlCommand(sqlProducto, conn, tx))
                        {
                            cmdProd.Parameters.Add("@NombreModelo", SqlDbType.NVarChar, 200)
                                  .Value = item.NombreModelo ?? string.Empty;
                            cmdProd.Parameters.Add("@MarcaId", SqlDbType.Int).Value = item.MarcaId;
                            cmdProd.Parameters.Add("@TipoProductoId", SqlDbType.Int).Value = item.TipoProductoId;

                            object escalar = cmdProd.ExecuteScalar();
                            if (escalar == null || escalar == DBNull.Value)
                                throw new Exception("No se obtuvo el ID del producto insertado.");

                            nuevoProductoId = Convert.ToInt32(escalar);
                        }

                        // 2) Insertar talles en TalleProducto (si hay)
                        if (item.TalleIds != null && item.TalleIds.Count > 0)
                        {
                            const string sqlTalleProd = @"
                                INSERT INTO TalleProducto (TalleId, ProductoId)
                                VALUES (@TalleId, @ProductoId);";

                            foreach (int talleId in item.TalleIds.Distinct())
                            {
                                using var cmdTP = new SqlCommand(sqlTalleProd, conn, tx);
                                cmdTP.Parameters.Add("@TalleId", SqlDbType.Int).Value = talleId;
                                cmdTP.Parameters.Add("@ProductoId", SqlDbType.Int).Value = nuevoProductoId;
                                cmdTP.ExecuteNonQuery();
                            }
                        }
                    }

                    tx.Commit();
                    return true;
                }
                catch (Exception exTx)
                {
                    tx.Rollback();
                    Error = exTx.Message;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}