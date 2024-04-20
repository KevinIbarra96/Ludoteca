using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Configuracion
    {
        public int id {  get; set; }

        public string ConfigName { get; set; }
        public string? ConfigDescripcion {  get; set; } 
        public string? ConfigStringValue { get; set; }
        public bool? ConfigBoolValue { get; set; }
        public int? ConfigIntValue { get; set; }
        public double? ConfigDecimalValue { get; set; }

    }
}
