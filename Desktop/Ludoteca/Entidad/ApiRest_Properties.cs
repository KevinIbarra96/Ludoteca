using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ApiRest_Properties
    {
        private static string Path = @"http://localhost:80/LudotecaService";
        //private static string Path = @"https://justkids.site/DesktopProviderDev";
        protected static HttpClient cliente = new HttpClient();

        public ApiRest_Properties() {
            cliente.BaseAddress = new Uri(Path);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
