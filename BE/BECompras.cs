using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BECompras
    {
        public string Error { get; set; }

        public int CrearCompraConDetalles(Compra compra)
        {
            try
            {
                var dal = new ComprasDAL();
                int id = dal.CrearCompraConDetalles(compra);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public Compra ObtenerCompraPorId(int compraId)
        {
            try
            {
                var dal = new ComprasDAL();
                var compra = dal.ObtenerPorId(compraId);
                if (compra == null) Error = dal.Error;
                return compra;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public List<Compra> ObtenerCompras(DateTime desde, DateTime hasta, int proveedorId = 0)
        {
            try
            {
                var dal = new ComprasDAL();
                var lista = dal.ObtenerTodos(desde, hasta, proveedorId);
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Compra>();
            }
        }

        public bool EliminarCompra(int compraId)
        {
            try
            {
                var dal = new ComprasDAL();
                bool ok = dal.EliminarCompra(compraId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        // Métodos para manejar detalles individualmente si los necesitás desde la capa de negocio

        public bool AgregarDetalleProducto(CompraDetalle detalle)
        {
            try
            {
                var dal = new ComprasProductosDAL();
                bool ok = dal.InsertarDetalle(detalle);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool EliminarDetallesPorCompra(int compraId)
        {
            try
            {
                var dal = new ComprasProductosDAL();
                bool ok = dal.EliminarDetallesPorCompra(compraId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool AgregarDetalleTalle(CompraTalle detalle)
        {
            try
            {
                var dal = new ComprasTallesDAL();
                bool ok = dal.InsertarDetalle(detalle);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool EliminarTallesPorCompra(int compraId)
        {
            try
            {
                var dal = new ComprasTallesDAL();
                bool ok = dal.EliminarTallesPorCompra(compraId);
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