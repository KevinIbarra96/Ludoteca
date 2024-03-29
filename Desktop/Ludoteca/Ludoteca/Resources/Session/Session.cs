using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System;
using System.Xml.Serialization;
using Windows.System;
using System.Xml;
using System.Xml.Linq;

namespace Ludoteca.Resources
{
    public class Session
    {
        public static string SessionId { get; set; }
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string RolName { get; set; }
        public static int RolId { get; set; }

        public static bool SessionActiva { get; set; }

        public static DateTime HoraInicioSession { get;set; }





    }

    
}
