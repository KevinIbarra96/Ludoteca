using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_Visita : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Visita"; //Adding ControllerName to Path
        private static List<EN_Visita> VisitasResponse = null;

        public static async Task<List<EN_Visita>> getAllVisitas()
        {
            VisitasResponse = null;
            string _enPoint = _apiPath + "/getAllVisitas"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Visita> VisitaRes = JsonConvert.DeserializeObject<EN_Response<EN_Visita>>(content);

                VisitasResponse = VisitaRes.Rbody;

            }
            return VisitasResponse;
        }

        public static async Task<List<EN_Visita>> getVisitaById(int _id)
        {

            string _endPoint = _apiPath + "/getVisitaById";
            VisitasResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Visita> VisitaRest = JsonConvert.DeserializeObject<EN_Response<EN_Visita>>(result);
                VisitasResponse = VisitaRest.Rbody;
            }

            return VisitasResponse;
        }

        public static async Task<List<EN_Visita>> addNewVisita(EN_Visita _Visita)
        {

            VisitasResponse = null;
            string endpointpath = _apiPath + "/addNewVisita";

            EN_Visita RequestBody = new EN_Visita();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Visita> VisitaRest = JsonConvert.DeserializeObject<EN_Response<EN_Visita>>(result);
                VisitasResponse = VisitaRest.Rbody;
            }

            return VisitasResponse;
        }

        public static async Task<List<EN_Visita>> updateVisita(EN_Visita _Visita)
        {

            VisitasResponse = null;
            string endpointpath = _apiPath + "/editVisita";

            EN_Visita RequestBody = new EN_Visita();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Visita> VisitaRest = JsonConvert.DeserializeObject<EN_Response<EN_Visita>>(result);
                VisitasResponse = VisitaRest.Rbody;
            }

            return VisitasResponse;
        }

        public static async Task<List<EN_Visita>> deleteVisita(int _id)
        {

            string _endPoint = _apiPath + "/deleteVisita";
            VisitasResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Visita> VisitaRest = JsonConvert.DeserializeObject<EN_Response<EN_Visita>>(result);
                VisitasResponse = VisitaRest.Rbody;
            }

            return VisitasResponse;
        }

    }
}
