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
    public class Compra
    {
        public int CompraId { get; set; }               // identity
        public int ProveedorId { get; set; }            // FK Proveedores
        public DateTime Fecha { get; set; }

        // Líneas relacionadas
        public List<CompraDetalle> Detalles { get; set; } = new List<CompraDetalle>();
        public List<CompraTalle> DetallesTalle { get; set; } = new List<CompraTalle>();
        public Compra() { }
        public Compra(int compraId, int proveedorId, DateTime fecha)
        {
            CompraId = compraId;
            ProveedorId = proveedorId;
            Fecha = fecha;
        }
    }

}
