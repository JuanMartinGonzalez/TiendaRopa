using System;

namespace TiendaRopa.BE
{
    /// <summary>
    /// DTO usado por el frontend para armar la grilla de productos a cargar.
    /// Representa UN renglón de la grilla.
    /// </summary>
    public class ProductoEnCarga
    {
        public string NombreModelo { get; set; }

        public int MarcaId { get; set; }
        public string MarcaNombre { get; set; }

        public int TipoProductoId { get; set; }
        public string TipoProductoNombre { get; set; }
        public bool PoseeTalle { get; set; }

        public int? TalleId { get; set; }
        public string TalleNombre { get; set; }
    }
}
