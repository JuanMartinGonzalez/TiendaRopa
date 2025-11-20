using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BEMarca
    {
        public string Error { get; set; }

        public List<Marca> ObtenerTodos()
        {
            try
            {
                var dal = new MarcaDAL();
                var lista = dal.ObtenerTodos();
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Marca>();
            }
        }

        public int Crear(Marca marca)
        {
            try
            {
                var dal = new MarcaDAL();
                int id = dal.Insertar(marca);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(Marca marca)
        {
            try
            {
                var dal = new MarcaDAL();
                bool ok = dal.Modificar(marca);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int marcaId)
        {
            try
            {
                var dal = new MarcaDAL();
                bool ok = dal.Eliminar(marcaId);
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