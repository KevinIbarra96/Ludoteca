using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Hijo : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Hijos"; //Adding ControllerName to Path
        private static List<EN_Hijo> HijosResponse = null;

        public static async Task<List<EN_Hijo>> getHijoByPadreId(int _padreId)
        {
            string _endPoint = _apiPath + "/getHijoByPadreId";
            HijosResponse = null;

            var requestBody = new { padreid = _padreId };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Hijo> HijoRest = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(result);
                HijosResponse = HijoRest.Rbody;
            }

            return HijosResponse;
        }

        public static async Task<List<EN_Hijo>> getAllHijos()
        {
            HijosResponse = null;
            string _enPoint = _apiPath + "/getAllHijos"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Hijo> HijoRes = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(content);

                HijosResponse = HijoRes.Rbody;

            }
            return HijosResponse;
        }
        public static async Task<List<EN_Hijo>> getAllActiveHijos()
        {
            HijosResponse = null;
            string _enPoint = _apiPath + "/getAllActiveHijos"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Hijo> HijoRes = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(content);

                HijosResponse = HijoRes.Rbody;

            }
            return HijosResponse;
        }

        public static async Task<List<EN_Hijo>> getHijoById(int _id)
        {

            string _endPoint = _apiPath + "/getHijoById";
            HijosResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Hijo> HijoRest = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(result);
                HijosResponse = HijoRest.Rbody;
            }

            return HijosResponse;
        }

        public static async Task<EN_Response<EN_Hijo>> addNewHijo(EN_Hijo _Hijo)
        {

            EN_Response<EN_Hijo> HijosResponse = null;
            string endpointpath = _apiPath + "/addNewHijo";

            EN_Hijo RequestBody = _Hijo;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                HijosResponse = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(result);
            }

            return HijosResponse;
        }

        public static async Task<List<EN_Hijo>> updateHijo(EN_Hijo _Hijo)
        {

            HijosResponse = null;
            string endpointpath = _apiPath + "/editHijo";

            EN_Hijo RequestBody = new EN_Hijo();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Hijo> HijoRest = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(result);
                HijosResponse = HijoRest.Rbody;
            }

            return HijosResponse;
        }

        public static async Task<List<EN_Hijo>> deleteHijo(int _id)
        {

            string _endPoint = _apiPath + "/deleteHijo";
            HijosResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Hijo> HijoRest = JsonConvert.DeserializeObject<EN_Response<EN_Hijo>>(result);
                HijosResponse = HijoRest.Rbody;
            }

            return HijosResponse;
        }

    }
}
