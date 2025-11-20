using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BETalleProducto
    {
        public string Error { get; set; }

        public List<Talle> ObtenerTallesPorProducto(int productoId)
        {
            try
            {
                var dal = new TalleProductoDAL();
                var lista = dal.ObtenerTallesPorProducto(productoId);
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Talle>();
            }
        }

        public bool AgregarTalleAProducto(int productoId, int talleId)
        {
            try
            {
                var dal = new TalleProductoDAL();
                bool ok = dal.AgregarTalleAProducto(productoId, talleId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool QuitarTalleDeProducto(int productoId, int talleId)
        {
            try
            {
                var dal = new TalleProductoDAL();
                bool ok = dal.QuitarTalleDeProducto(productoId, talleId);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool ExisteTalleEnProducto(int productoId, int talleId)
        {
            try
            {
                var dal = new TalleProductoDAL();
                bool existe = dal.ExisteTalleEnProducto(productoId, talleId);
                if (!existe && !string.IsNullOrEmpty(dal.Error)) Error = dal.Error;
                return existe;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}