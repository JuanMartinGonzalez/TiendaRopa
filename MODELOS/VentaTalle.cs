using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.MODELOS
{
    public class VentaTalle
    {
        // Corresponde a VentasTalles (VentaId, ProductoId, TalleId, Cant)
        public int VentaId { get; set; }                // FK Ventas
        public int ProductoId { get; set; }             // FK Productos
        public int TalleId { get; set; }                // FK Talles
        public int Cant { get; set; }                   // cantidad por talle (entero)
        public VentaTalle() { }
        public VentaTalle(int ventaId, int productoId, int talleId, int cantidad)
        {
            VentaId = ventaId;
            ProductoId = productoId;
            TalleId = talleId;
            Cant = cantidad;
        }
    }

}
