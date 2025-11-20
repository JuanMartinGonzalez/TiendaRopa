using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BEVentas
    {
        public string Error { get; set; }

        public int CrearVentaConDetalles(Venta venta)
        {
            try
            {
                var dal = new VentasDAL();
                int id = dal.CrearVentaConDetalles(venta);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public Venta ObtenerVentaPorId(int ventaId)
        {
            try
            {
                var dal = new VentasDAL();
                var venta = dal.ObtenerPorId(ventaId);
                if (venta == null) Error = dal.Error;
                return venta;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public List<Venta> ObtenerVentas(DateTime desde, DateTime hasta, int clienteId = 0)
        {
            try
            {
                var dal = new VentasDAL();
                var lista = dal.ObtenerTodos(desde, hasta, clienteId);
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Venta>();
            }
        }

        public bool EliminarVenta(int ventaId)
        {
            try
            {
                var dal = new VentasDAL();
                bool ok = dal.EliminarVenta(ventaId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        // Métodos para manejar detalles individualmente desde la capa de negocio

        public bool AgregarDetalleProducto(VentaDetalle detalle)
        {
            try
            {
                var dal = new VentasProductoDAL();
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

        public bool EliminarDetallesPorVenta(int ventaId)
        {
            try
            {
                var dal = new VentasProductoDAL();
                bool ok = dal.EliminarDetallesPorVenta(ventaId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool AgregarDetalleTalle(VentaTalle detalle)
        {
            try
            {
                var dal = new VentasTallesDAL();
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

        public bool EliminarTallesPorVenta(int ventaId)
        {
            try
            {
                var dal = new VentasTallesDAL();
                bool ok = dal.EliminarTallesPorVenta(ventaId);
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