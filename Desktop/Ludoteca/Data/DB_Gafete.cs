﻿using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Gafete : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Gafete"; //Adding ControllerName to Path
        private static EN_Response<EN_Gafete> GafeteResponse = null;

        public static async Task<EN_Response<EN_Gafete>> getGafeteNoAsignado()
        {
            GafeteResponse = null;
            string _endPoint = _apiPath + "/getGafeteNoAsignado";

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                GafeteResponse = JsonConvert.DeserializeObject<EN_Response<EN_Gafete>>(content);
            }

            return GafeteResponse;
        }
        public static async Task<EN_Response<EN_Gafete>> getAllGafete()
        {
            GafeteResponse = null;
            string _endPoint = _apiPath + "/getAllGafete";

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                GafeteResponse = JsonConvert.DeserializeObject<EN_Response<EN_Gafete>>(content);
            }

            return GafeteResponse;
        }

        public static async Task<EN_Response<EN_Gafete>> getAllActiveGafete()
        {
            GafeteResponse = null;
            string _endPoint = _apiPath + "/getAllActiveGafete";

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                GafeteResponse = JsonConvert.DeserializeObject<EN_Response<EN_Gafete>>(content);
            }

            return GafeteResponse;
        }

        public static async Task<EN_Response<EN_Gafete>> Delete(int _id)
        {
            string _endPoint = _apiPath + "/deleteGafete";
            GafeteResponse = null;

            var requestBody = new { id = _id };

            var requestData = JsonConvert.SerializeObject(requestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                GafeteResponse = JsonConvert.DeserializeObject<EN_Response<EN_Gafete>>(result);

            }

            return GafeteResponse;
        }


    }
}
