using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_Padre : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Padres"; //Adding ControllerName to Path
        private static List<EN_Padre> PadresResponse = null;

        public static async Task<EN_Padre> getPadreByPhone(string _phone)
        {
            EN_Padre padreResult=null;
            string _endPoint = _apiPath + "/getPadreByPhone"; //Adding endpoint to path


            var requestBody = new { phone = _phone };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Padre> PadreRest = JsonConvert.DeserializeObject<EN_Response<EN_Padre>>(result);
                padreResult = PadreRest.Rbody[0];
            }

            return padreResult;
        }

        public static async Task<List<EN_Padre>> getAllPadres()
        {
            PadresResponse = null;
            string _endPoint = _apiPath + "/getAllPadres"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Padre> PadreRes = JsonConvert.DeserializeObject<EN_Response<EN_Padre>>(content);

                PadresResponse = PadreRes.Rbody;

            }
            return PadresResponse;
        }

        public static async Task<List<EN_Padre>> getPadreById(int _id)
        {

            string _endPoint = _apiPath + "/getPadreById";
            PadresResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Padre> PadreRest = JsonConvert.DeserializeObject<EN_Response<EN_Padre>>(result);
                PadresResponse = PadreRest.Rbody;
            }

            return PadresResponse;
        }

        public static async Task<List<EN_Padre>> addNewPadre(EN_Padre _Padre)
        {

            PadresResponse = null;
            string endpointpath = _apiPath + "/addNewPadre";

            EN_Padre RequestBody = new EN_Padre();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Padre> PadreRest = JsonConvert.DeserializeObject<EN_Response<EN_Padre>>(result);
                PadresResponse = PadreRest.Rbody;
            }

            return PadresResponse;
        }

        public static async Task<List<EN_Padre>> updatePadre(EN_Padre _Padre)
        {

            PadresResponse = null;
            string endpointpath = _apiPath + "/editPadre";

            EN_Padre RequestBody = new EN_Padre();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Padre> PadreRest = JsonConvert.DeserializeObject<EN_Response<EN_Padre>>(result);
                PadresResponse = PadreRest.Rbody;
            }

            return PadresResponse;
        }

        public static async Task<List<EN_Padre>> deletePadre(int _id)
        {

            string _endPoint = _apiPath + "/deletePadre";
            PadresResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Padre> PadreRest = JsonConvert.DeserializeObject<EN_Response<EN_Padre>>(result);
                PadresResponse = PadreRest.Rbody;
            }

            return PadresResponse;
        }

    }
}
