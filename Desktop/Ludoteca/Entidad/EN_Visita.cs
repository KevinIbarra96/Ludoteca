using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    internal class EN_Visita
    {
        public int id { get; set; }
        public int Hijo { get; set; }
        public int Servicio {  get; set; }
        public string Productos {  get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida {  get; set; }
        public int Oferta {  get; set; }
        public int status {  get; set; }
    }
}
