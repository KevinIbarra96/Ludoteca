﻿using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Servicio : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Servicios"; //Adding ControllerName to Path
        private static List<EN_Servicio> ServiciosResponse = null;

        public static async Task<EN_Response<EN_Servicio>> setNewPrecio(int id, int Precio)
        {

            EN_Response<EN_Servicio> servicioResponse = new EN_Response<EN_Servicio>();
            string endpointpath = _apiPath + "/setNewPrecio";

            var RequestBody = new { id = id, Precio = Precio };

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                servicioResponse = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
            }


            return servicioResponse;
        }

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

        public static async Task<List<EN_Servicio>> getAllActiveServicios()
        {
            ServiciosResponse = null;
            string _enPoint = _apiPath + "/getAllActiveServicios"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRes = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(content);

                ServiciosResponse = ServicioRes.Rbody;

            }
            return ServiciosResponse;
        }

        public static async Task<EN_Response<EN_Servicio>> getallServiciosByTipoServicio(int _idTipoServicio)
        {

            string _endPoint = _apiPath + "/getallServiciosByTipoServicio";
            EN_Response<EN_Servicio> ServicioRest = null;

            var requestBody = new { IdTipoServicio = _idTipoServicio };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                ServicioRest = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
            }

            return ServicioRest;
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

        public static async Task<EN_Response<EN_Servicio>> addNewServicios(EN_Servicio _Servicio)
        {
            EN_Response<EN_Servicio> ServicioResponse = null;

            string endpointpath = _apiPath + "/addNewServicios";

            EN_Servicio RequestBody = _Servicio;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                ServicioResponse = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
            }

            return ServicioResponse;
        }

        public static async Task updateServicio(EN_Servicio _Servicio)
        {
            string endpointpath = _apiPath + "/editServicios";

            EN_Servicio RequestBody = _Servicio;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Servicio> ServicioRest = JsonConvert.DeserializeObject<EN_Response<EN_Servicio>>(result);
            }
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
