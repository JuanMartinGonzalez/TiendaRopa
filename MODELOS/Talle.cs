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
    public class Talle
    {
        public int TalleId { get; set; }
        public string Talles { get; set; }
        public Talle() { }
        public Talle(int talleId, string talles)
        {
            TalleId = talleId;
            Talles = talles;
        }
    }

}
