using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BETalle
    {
        public string Error { get; set; }

        public List<Talle> ObtenerTodos()
        {
            try
            {
                var dal = new TalleDAL();
                var lista = dal.ObtenerTodos();
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Talle>();
            }
        }

        public Talle ObtenerPorId(int talleId)
        {
            try
            {
                var dal = new TalleDAL();
                var item = dal.ObtenerPorId(talleId);
                if (item == null) Error = dal.Error;
                return item;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public int Crear(Talle talle)
        {
            try
            {
                var dal = new TalleDAL();
                int id = dal.Insertar(talle);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(Talle talle)
        {
            try
            {
                var dal = new TalleDAL();
                bool ok = dal.Modificar(talle);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int talleId)
        {
            try
            {
                var dal = new TalleDAL();
                bool ok = dal.Eliminar(talleId);
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