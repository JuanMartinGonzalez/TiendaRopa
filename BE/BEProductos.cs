using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BEProducto
    {
        public string Error { get; set; }

        public List<Producto> ObtenerTodos()
        {
            try
            {
                var dal = new ProductoDAL();
                var lista = dal.ObtenerTodos();
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Producto>();
            }
        }

        public Producto ObtenerPorId(int productoId)
        {
            try
            {
                var dal = new ProductoDAL();
                var item = dal.ObtenerPorId(productoId);
                if (item == null) Error = dal.Error;
                return item;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public int Crear(Producto producto)
        {
            try
            {
                var dal = new ProductoDAL();
                int id = dal.Insertar(producto);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(Producto producto)
        {
            try
            {
                var dal = new ProductoDAL();
                bool ok = dal.Modificar(producto);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int productoId)
        {
            try
            {
                var dal = new ProductoDAL();
                bool ok = dal.Eliminar(productoId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}