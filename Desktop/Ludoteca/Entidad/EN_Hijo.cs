using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    internal class EN_Hijo
    {
        public int id {  get; set; }
        public string NombreHijo { get; set; }
        public int Papa {  get; set; }
        public int Mama { get; set; }
        public DateTime fechaNac {  get; set; }
        public int  status { get; set; }
    }
}
