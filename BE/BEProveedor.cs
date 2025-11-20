using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BEProveedor
    {
        public string Error { get; set; }

        public List<Proveedor> ObtenerTodos()
        {
            try
            {
                var dal = new ProveedorDAL();
                var lista = dal.ObtenerTodos();
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Proveedor>();
            }
        }

        public Proveedor ObtenerPorId(int proveedorId)
        {
            try
            {
                var dal = new ProveedorDAL();
                var prov = dal.ObtenerPorId(proveedorId);
                if (prov == null) Error = dal.Error;
                return prov;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public int Crear(Proveedor proveedor)
        {
            try
            {
                var dal = new ProveedorDAL();
                int id = dal.InsertarProveedor(proveedor);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(Proveedor proveedor)
        {
            try
            {
                var dal = new ProveedorDAL();
                bool ok = dal.ModificarProveedor(proveedor);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int proveedorId)
        {
            try
            {
                var dal = new ProveedorDAL();
                bool ok = dal.EliminarProveedor(proveedorId);
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