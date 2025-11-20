using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BETipoProducto
    {
        public string Error { get; set; }

        public List<TipoProducto> ObtenerTodos()
        {
            try
            {
                var dal = new TipoProductoDAL();
                var lista = dal.ObtenerTodos();
                if (lista == null) Error = dal.Error;
                return lista ?? new List<TipoProducto>();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<TipoProducto>();
            }
        }

        public int Crear(TipoProducto tipo)
        {
            try
            {
                var dal = new TipoProductoDAL();
                int id = dal.Insertar(tipo);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(TipoProducto tipo)
        {
            try
            {
                var dal = new TipoProductoDAL();
                bool ok = dal.Modificar(tipo);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int tipoProductoId)
        {
            try
            {
                var dal = new TipoProductoDAL();
                bool ok = dal.Eliminar(tipoProductoId);
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
