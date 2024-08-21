using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Oferta
    {
        public int id { get; set; }
        public string OfertaName { get; set; }
        public string Descripcion { get; set; }
        public int Tiempo { get; set; } //Time in minutes.
        public double totalDescuento { get; set; }
        public int status { get; set; } 
    }
}
