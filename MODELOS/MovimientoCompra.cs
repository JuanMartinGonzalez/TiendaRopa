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
    public class MovimientoCompraResumen
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public int Total { get; set; }
        public MovimientoCompraResumen() { }
        public MovimientoCompraResumen(int compraId, DateTime fecha, int proveedorId, string proveedorNombre, int Total)
        {
            CompraId = compraId;
            Fecha = fecha;
            ProveedorId = proveedorId;
            ProveedorNombre = proveedorNombre;
            this.Total = Total;
        }
    }
}
