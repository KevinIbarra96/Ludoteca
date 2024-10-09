using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Tickets
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idvisita {  get; set; }
        public DateTime fecha_creacion { get; set; }
        public string ruta { get; set; }
        public int status { get; set; }
    }
}
