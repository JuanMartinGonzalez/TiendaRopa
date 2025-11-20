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
    }
}