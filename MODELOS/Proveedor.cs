using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TiendaRopa.FE;

namespace TiendaRopa.MODELOS
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }   // 0 para nuevos registros
        public string Nombre { get; set; }     // NOT NULL
        public string CUIT { get; set; }       // NOT NULL
        public Proveedor() { } // constructor por defecto
        public Proveedor(int proveedorId, string nombre, string cUIT)
        {
            ProveedorId = proveedorId;
            Nombre = nombre;
            CUIT = cUIT;
        }
    }
}
