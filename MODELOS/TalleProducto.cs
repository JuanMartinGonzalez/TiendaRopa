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
    public class TalleProducto
    {
        public int TalleId { get; set; }
        public int ProductoId { get; set; }
        public TalleProducto() { }
        public TalleProducto(int talleId, int productoId)
        {
            TalleId = talleId;
            ProductoId = productoId;
        }
    }
}
