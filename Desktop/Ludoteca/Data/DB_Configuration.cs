using Entidad;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Data
{
    public class DB_Configuracion : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Configuracion"; //Adding ControllerName to Path
        private static EN_Response<EN_Configuracion> ConfiguracionResponse = null;

        public static async Task<EN_Response<EN_Configuracion>> getAllConfiguracion()
        {
            ConfiguracionResponse = null;
            string _endPoint = _apiPath + "/getAllConfiguracion";

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                EN_Response<EN_Configuracion> ConfiguracionResponse = JsonConvert.DeserializeObject<EN_Response<EN_Configuracion>>(content);
            }

            return ConfiguracionResponse;
        }
        public static async Task<EN_Response<EN_Configuracion>> getAllActiveConfiguracion()
        {
            ConfiguracionResponse = null;
            string _endPoint = _apiPath + "/getAllActiveConfiguracion";

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                EN_Response<EN_Configuracion> ConfiguracionResponse = JsonConvert.DeserializeObject<EN_Response<EN_Configuracion>>(content);
            }

            return ConfiguracionResponse;
        }

        public static async Task<EN_Response<EN_Configuracion>> getConfigurationById(int _id)
        {
            ConfiguracionResponse = null;

            string _endPoint = _apiPath + "/getConfiguracionById";

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                ConfiguracionResponse = JsonConvert.DeserializeObject<EN_Response<EN_Configuracion>>(result);
            }

            return ConfiguracionResponse;

        }

        public static async Task<EN_Response<EN_Configuracion>> updateConfigurationValues(EN_Configuracion _configuration)
        {
            ConfiguracionResponse = null;

            string _endPoint = _apiPath + "/editConfiguracion";

            var requestBody = _configuration;

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                ConfiguracionResponse = JsonConvert.DeserializeObject<EN_Response<EN_Configuracion>>(result);
            }

            return ConfiguracionResponse;
        }

    }
}
