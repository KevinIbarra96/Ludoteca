using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_TipoServicio : ApiRest_Properties
    {

        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/TipoServicio"; //Adding ControllerName to Path
        private static EN_Response<EN_TipoServicio> TipoServicioResponse = null;

        public static async Task<EN_Response<EN_TipoServicio>> getAllActiveTipoServicio()
        {
            TipoServicioResponse = null;
            string _enPoint = _apiPath + "/getAllActiveTipoServicio"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                TipoServicioResponse = JsonConvert.DeserializeObject<EN_Response<EN_TipoServicio>>(content);

            }
            return TipoServicioResponse;
        }


    }
}
