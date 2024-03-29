using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_ServiciosVisita
    {
        public int Servicio_Id {  get; set; }
        public int Servicio_Precio {  get; set; }
        public string ServicioName {  get; set; }
        public int  Tiempo { get; set; } //Tiempo en minutos
   }
}
