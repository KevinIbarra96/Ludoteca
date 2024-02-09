using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_Servicio : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Servicio"; //Adding ControllerName to Path
        private static List<EN_Servicio> ServiciosResponse = null;

        public static async Task<List<EN_Servicio>> getAllServicios()
        {
            ServiciosResponse = null;
            string _enPoint = _apiPath + "/getAllServicios"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRes = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(content);

                ServiciosResponse = ServicioRes.Rbody;

            }
            return ServiciosResponse;
        }

        public static async Task<List<EN_Servicio>> getServiciosById(int _id)
        {

            string _endPoint = _apiPath + "/getServiciosById";
            ServiciosResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRest = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
                ServiciosResponse = ServicioRest.Rbody;
            }

            return ServiciosResponse;
        }

        public static async Task<List<EN_Servicio>> addNewServicios(EN_Servicio _Servicio)
        {

            ServiciosResponse = null;
            string endpointpath = _apiPath + "/addNewServicios";

            EN_Servicio RequestBody = new EN_Servicio();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRest = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
                ServiciosResponse = ServicioRest.Rbody;
            }

            return ServiciosResponse;
        }

        public static async Task<List<EN_Servicio>> updateServicio(EN_Servicio _Servicio)
        {

            ServiciosResponse = null;
            string endpointpath = _apiPath + "/editServicios";

            EN_Servicio RequestBody = new EN_Servicio();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRest = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
                ServiciosResponse = ServicioRest.Rbody;
            }

            return ServiciosResponse;
        }

        public static async Task<List<EN_Servicio>> deleteServicios(int _id)
        {

            string _endPoint = _apiPath + "/deleteServicios";
            ServiciosResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRest = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
                ServiciosResponse = ServicioRest.Rbody;
            }

            return ServiciosResponse;
        }

    }
}
