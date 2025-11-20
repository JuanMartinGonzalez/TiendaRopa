using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopa.MODELOS
{
    public class TipoProducto
    {
        public int TipoProductoId { get; set; }
        public string Nombre { get; set; }
        public bool PoseeTalle { get; set; }
        public TipoProducto() { }
        public TipoProducto(int tipoProductoId, string nombre, bool poseeTalle)
        {
            TipoProductoId = tipoProductoId;
            Nombre = nombre;
            PoseeTalle = poseeTalle;
        }
    }

}
