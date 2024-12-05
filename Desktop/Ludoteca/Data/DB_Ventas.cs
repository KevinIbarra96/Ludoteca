using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class DB_Ventas : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Ventas"; //Adding ControllerName to Path
        private static EN_Response<EN_Ventas> VentasResponse = null;

        public static async Task<EN_Response<EN_Ventas>> getAllVentas()
        {
            VentasResponse = null;
            string _enPoint = _apiPath + "/getAllVentas"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                VentasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Ventas>>(content);

            }

            return VentasResponse;
        }

        public static async Task<EN_Response<EN_Ventas>> addNewProducto(EN_Ventas _Venta)
        {
            VentasResponse = null;

            string endpointpath = _apiPath + "/addNewVenta";

            EN_Ventas RequestBody = _Venta;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                VentasResponse = JsonConvert.DeserializeObject<EN_Response<EN_Ventas>>(result);
            }

            return VentasResponse;
        }

    }
}
