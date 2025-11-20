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
    public class CompraTalle
    {
        // Corresponde a ComprasTalles (CompraId, ProductoId, TalleId, Cant)
        public int CompraId { get; set; }               // FK Compras
        public int ProductoId { get; set; }             // FK Productos
        public int TalleId { get; set; }                // FK Talles
        public int Cant { get; set; }                   // cantidad por talle (entero)
        public CompraTalle() { }
        public CompraTalle(int compraId, int productoId, int talleId, int cantidad)
        {
            CompraId = compraId;
            ProductoId = productoId;
            TalleId = talleId;
            Cant = cantidad;
        }
    }


}
