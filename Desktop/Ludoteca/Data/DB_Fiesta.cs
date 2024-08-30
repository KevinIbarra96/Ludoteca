using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_Fiesta : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Fiesta"; //Adding ControllerName to Path
        private static EN_Response<EN_Fiesta> FiestaResponse = null;

        public static async Task<EN_Response<EN_Fiesta>> getAllFiesta()
        {
            FiestaResponse = null;
            string _enPoint = _apiPath + "/getAllFiesta"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                FiestaResponse = JsonConvert.DeserializeObject<EN_Response<EN_Fiesta>>(content);

            }
            return FiestaResponse;
        }

        public static async Task<EN_Response<EN_Fiesta>> getAllActiveFiesta()
        {
            FiestaResponse = null;
            string _enPoint = _apiPath + "/getAllActiveFiesta"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                FiestaResponse = JsonConvert.DeserializeObject<EN_Response<EN_Fiesta>>(content);

            }
            return FiestaResponse;
        }

        public static async Task<EN_Response<EN_Fiesta>> getFiestaById(int _id)
        {

            string _endPoint = _apiPath + "/getFiestaById";
            FiestaResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                FiestaResponse = JsonConvert.DeserializeObject<EN_Response<EN_Fiesta>>(result);
            }

            return FiestaResponse;
        }

        public static async Task<EN_Response<EN_Fiesta>> addNewFiesta(EN_Fiesta _Fiesta)
        {

            FiestaResponse = null;
            string endpointpath = _apiPath + "/addNewFiesta";

            EN_Fiesta RequestBody = new EN_Fiesta();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                FiestaResponse = JsonConvert.DeserializeObject<EN_Response<EN_Fiesta>>(result);
            }

            return FiestaResponse;
        }

        public static async Task<EN_Response<EN_Fiesta>> updateFiesta(EN_Fiesta _Fiesta)
        {

            FiestaResponse = null;
            string endpointpath = _apiPath + "/editFiesta";

            EN_Fiesta RequestBody = new EN_Fiesta();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                FiestaResponse = JsonConvert.DeserializeObject<EN_Response<EN_Fiesta>>(result);
            }

            return FiestaResponse;
        }

        public static async Task<EN_Response<EN_Fiesta>> deleteFiesta(int _id)
        {

            string _endPoint = _apiPath + "/deleteFiesta";
            FiestaResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                FiestaResponse = JsonConvert.DeserializeObject<EN_Response<EN_Fiesta>>(result);
            }

            return FiestaResponse;
        }

    }
}
