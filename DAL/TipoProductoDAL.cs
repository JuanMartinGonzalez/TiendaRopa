using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using TiendaRopa.MODELOS;
using static TiendaRopa.FormPadre;

namespace TiendaRopa.DAL
{
    public class TipoProductoDAL
    {
        private readonly ConexionBD _conexion;
        public string Error { get; private set; }

        public TipoProductoDAL() => _conexion = new ConexionBD();

        public List<TipoProducto> ObtenerTodos()
        {
            var lista = new List<TipoProducto>();
            string sql = "SELECT TipoProductoId, Nombre, PoseeTalle FROM TipoProducto ORDER BY Nombre";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                conn.Open();
                using var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lista.Add(new TipoProducto
                    {
                        TipoProductoId = rdr.GetInt32(0),
                        Nombre = rdr.GetString(1),
                        PoseeTalle = rdr.GetBoolean(2)
                    });
                }
            }
            catch (Exception ex) { Error = ex.Message; }
            return lista;
        }

        public int Insertar(TipoProducto tp)
        {
            string sql = @"INSERT INTO TipoProducto (Nombre, PoseeTalle)
                           VALUES (@Nombre, @PoseeTalle);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = tp.Nombre;
                cmd.Parameters.Add("@PoseeTalle", SqlDbType.Bit).Value = tp.PoseeTalle;
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex) { Error = ex.Message; return -1; }
        }

        public bool Modificar(TipoProducto tp)
        {
            string sql = @"UPDATE TipoProducto SET Nombre = @Nombre, PoseeTalle = @PoseeTalle
                           WHERE TipoProductoId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = tp.Nombre;
                cmd.Parameters.Add("@PoseeTalle", SqlDbType.Bit).Value = tp.PoseeTalle;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = tp.TipoProductoId;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Error = ex.Message; return false; }
        }

        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM TipoProducto WHERE TipoProductoId = @Id";
            try
            {
                using var conn = _conexion.ObtenerConexion();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { Error = ex.Message; return false; }
        }
    }
}