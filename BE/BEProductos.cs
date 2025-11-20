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
        /// <summary>
        /// Recibe la lista de renglones cargados en la grilla (ProductoEnCarga),
        /// arma el lote de productos + talles, y delega al DAL que haga
        /// la transacción.
        /// </summary>
        public bool GuardarLoteDesdeCarga(List<ProductoEnCarga> carga)
        {
            Error = null;

            if (carga == null || carga.Count == 0)
            {
                Error = "No hay productos para guardar.";
                return false;
            }

            try
            {
                // 1) Agrupar por producto (NombreModelo + MarcaId + TipoProductoId)
                var grupos = carga
                    .GroupBy(p => new
                    {
                        p.NombreModelo,
                        p.MarcaId,
                        p.TipoProductoId
                    });

                var loteDal = new List<ProductoDAL.ProductoLoteInput>();

                foreach (var grupo in grupos)
                {
                    // Talles para este producto (si corresponde)
                    var tallesIds = grupo
                        .Where(x => x.PoseeTalle && x.TalleId.HasValue)
                        .Select(x => x.TalleId.Value)
                        .Distinct()
                        .ToList();

                    var input = new ProductoDAL.ProductoLoteInput
                    {
                        NombreModelo = grupo.Key.NombreModelo,
                        MarcaId = grupo.Key.MarcaId,
                        TipoProductoId = grupo.Key.TipoProductoId,
                        TalleIds = tallesIds
                    };

                    loteDal.Add(input);
                }

                // 2) Llamar al DAL para que ejecute la transacción
                var dal = new ProductoDAL();
                bool ok = dal.InsertarLoteConTalles(loteDal);
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