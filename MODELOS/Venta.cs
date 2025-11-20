using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.MODELOS
{
    public class Venta
    {
        public int VentaId { get; set; }                // identity
        public int ClienteId { get; set; }              // FK Clientes
        public DateTime Fecha { get; set; }

        // Líneas relacionadas
        public List<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();
        public List<VentaTalle> DetallesTalle { get; set; } = new List<VentaTalle>();
        public Venta() { }
        public Venta(int ventaId, int clienteId, DateTime fecha)
        {
            VentaId = ventaId;
            ClienteId = clienteId;
            Fecha = fecha;
        }
    }

}
