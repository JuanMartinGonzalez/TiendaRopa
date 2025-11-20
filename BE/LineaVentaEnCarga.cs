using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.BE
{
    public class LineaVentaEnCarga
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }

        public int? TalleId { get; set; }
        public string TalleNombre { get; set; }

        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }

        public int Subtotal => Cantidad * PrecioUnitario;
    }

}
