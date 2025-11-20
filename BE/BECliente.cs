using System;
using System.Collections.Generic;
using TiendaRopa.DAL;
using TiendaRopa.MODELOS;

namespace TiendaRopa.BE
{
    public class BECliente
    {
        public string Error { get; set; }

        public List<Cliente> ObtenerTodos()
        {
            try
            {
                var dal = new ClienteDAL();
                var lista = dal.ObtenerTodos();
                if (lista == null) Error = dal.Error;
                return lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return new List<Cliente>();
            }
        }

        public Cliente ObtenerPorId(int clienteId)
        {
            try
            {
                var dal = new ClienteDAL();
                var cli = dal.ObtenerPorId(clienteId);
                if (cli == null) Error = dal.Error;
                return cli;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        public int Crear(Cliente cliente)
        {
            try
            {
                var dal = new ClienteDAL();
                int id = dal.InsertarCliente(cliente);
                if (id <= 0) Error = dal.Error;
                return id;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public bool Modificar(Cliente cliente)
        {
            try
            {
                var dal = new ClienteDAL();
                bool ok = dal.ModificarCliente(cliente);
                if (!ok) Error = dal.Error;
                return ok;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool Eliminar(int clienteId)
        {
            try
            {
                var dal = new ClienteDAL();
                bool ok = dal.EliminarCliente(clienteId);
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