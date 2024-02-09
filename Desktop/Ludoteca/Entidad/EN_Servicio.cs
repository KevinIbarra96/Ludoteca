using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Servicio
    {
        public int id {  get; set; }
        public string ServicioName { get; set; }
        public int Tiempo { get; set; } // Time in minutes
        public int status { get; set; }
    }
}
