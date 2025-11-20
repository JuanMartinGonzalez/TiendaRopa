using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TiendaRopa.FE;
using System.Net.Http.Headers;

namespace TiendaRopa.MODELOS
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string NombreModelo { get; set; }
        public int MarcaId { get; set; }
        public int TipoProductoId { get; set; }

        // Campos de ayuda (opcionales en DTO) para JOINs
        public string NombreMarca { get; set; }
        public string NombreTipoProducto { get; set; }
        public Producto() { }
        public Producto(int productoId, string nombreModelo, int marcaId, int tipoProductoId)
        {
            ProductoId = productoId;
            NombreModelo = nombreModelo;
            MarcaId = marcaId;
            TipoProductoId = tipoProductoId;
        }
    }

}
