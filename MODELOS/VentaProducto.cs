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
    public class VentaDetalle
    {
        // Corresponde a VentasProducto (VentaId, ProductoId, Cantidad, Precio)
        public int VentaId { get; set; }                // FK Ventas
        public int ProductoId { get; set; }             // FK Productos
        public int Cantidad { get; set; }
        public int Precio { get; set; }             // precio unitario
        public VentaDetalle() { }
        public VentaDetalle(int ventaId, int productoId, int cantidad, int precio)
        {
            VentaId = ventaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }

}
