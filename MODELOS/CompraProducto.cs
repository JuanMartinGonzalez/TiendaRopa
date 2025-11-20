using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TiendaRopa.FE;

namespace TiendaRopa.MODELOS
{
    public class CompraDetalle
    {
        // Corresponde a ComprasProductos (CompraId, ProductoId, Cantidad, Precio)
        public int CompraId { get; set; }               // FK Compras
        public int ProductoId { get; set; }             // FK Productos
        public int Cantidad { get; set; }
        public int Precio { get; set; }             // precio unitario
        public CompraDetalle() { }
        public CompraDetalle(int compraId, int productoId, int cantidad, int precio)
        {
            CompraId = compraId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }


}
