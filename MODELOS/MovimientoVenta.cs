using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.MODELOS
{
    public class MovimientoVentaResumen
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public int Total { get; set; }
        public MovimientoVentaResumen() { }
        public MovimientoVentaResumen(int ventaId, DateTime fecha, int clienteId, string clienteNombre, int Total)
        {
            VentaId = ventaId;
            Fecha = fecha;
            ClienteId = clienteId;
            ClienteNombre = clienteNombre;
            this.Total = Total;
        }
    }

}
