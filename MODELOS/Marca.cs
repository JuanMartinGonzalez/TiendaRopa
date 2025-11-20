using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TiendaRopa.FE;

namespace TiendaRopa.MODELOS
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
        public Marca() { }
        public Marca(int marcaId, string nombre)
        {
            MarcaId = marcaId;  
            Nombre = nombre;
        }
    }

}
