using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Oferta : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Ofertas"; //Adding ControllerName to Path
        private static EN_Response<EN_Oferta> OfertasResponse = null;

        public static async Task<EN_Response<EN_Oferta>> getAllOfertas()
        {
            OfertasResponse = null;
            string _enPoint = _apiPath + "/getAllOfertas"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                OfertasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Oferta>>(content);

            }
            return OfertasResponse;
        }

        public static async Task<EN_Response<EN_Oferta>> getAllActiveOfertas()
        {
            OfertasResponse = null;
            string _enPoint = _apiPath + "/getAllActiveOfertas"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                OfertasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Oferta>>(content);

            }
            return OfertasResponse;
        }

        public static async Task<EN_Response<EN_Oferta>> getOfertasById(int _id)
        {

            string _endPoint = _apiPath + "/getOfertasById";
            OfertasResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                OfertasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Oferta>>(result);

            }

            return OfertasResponse;
        }

        public static async Task<EN_Response<EN_Oferta>> addNewOfertas(EN_Oferta _Oferta)
        {

            OfertasResponse = null;
            string endpointpath = _apiPath + "/addNewOfertas";

            EN_Oferta RequestBody = _Oferta;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                OfertasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Oferta>>(result);

            }

            return OfertasResponse;
        }

        public static async Task<EN_Response<EN_Oferta>> updateOferta(EN_Oferta _Oferta)
        {

            OfertasResponse = null;
            string endpointpath = _apiPath + "/editOfertas";

            EN_Oferta RequestBody = _Oferta;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                OfertasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Oferta>>(result);
            }

            return OfertasResponse;
        }

        public static async Task<EN_Response<EN_Oferta>> deleteOfertas(int _id)
        {

            string _endPoint = _apiPath + "/deleteOfertas";
            OfertasResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                OfertasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Oferta>>(result);
            }

            return OfertasResponse;
        }

    }
}
