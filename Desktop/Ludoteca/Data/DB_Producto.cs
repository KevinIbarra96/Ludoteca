using Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_Producto : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Productos"; //Adding ControllerName to Path
        private static List<EN_Producto> ProductosResponse = null;

        public static async Task<EN_Response<EN_Producto>> increaseCantidadProducto(int id,int cantidad)
        {

            ProductosResponse = null;
            EN_Response<EN_Producto> ProductRest = new EN_Response<EN_Producto>();
            string endpointpath = _apiPath + "/increaseCantidadProduct";

            var RequestBody = new { id=id , Cantidad = cantidad };

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                ProductRest = JsonConvert.DeserializeObject<EN_Response<EN_Producto>>(result);
            }

            return ProductRest;
        }

        public static async Task<List<EN_Producto>> getAllProductos()
        {
            ProductosResponse = null;
            string _enPoint = _apiPath + "/getAllProductos"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Producto> ProductoRes = JsonConvert.DeserializeObject<EN_Response<EN_Producto>>(content);

                ProductosResponse = ProductoRes.Rbody;

            }
            return ProductosResponse;
        }

        public static async Task<List<EN_Producto>> getProductoById(int _id)
        {

            string _endPoint = _apiPath + "/getProductoById";
            ProductosResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Producto> ProductoRest = JsonConvert.DeserializeObject<EN_Response<EN_Producto>>(result);
                ProductosResponse = ProductoRest.Rbody;
            }

            return ProductosResponse;
        }

        public static async Task<EN_Response<EN_Producto>> addNewProducto(EN_Producto _Producto)
        {
            EN_Response<EN_Producto> Response = null;

            string endpointpath = _apiPath + "/addNewProducto";

            EN_Producto RequestBody = _Producto;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                Response = JsonConvert.DeserializeObject<EN_Response<EN_Producto>>(result);
            }

            return Response;
        }

        public static async Task updateProducto(EN_Producto _Producto)
        {

            ProductosResponse = null;
            string endpointpath = _apiPath + "/editProducto";

            var requestData = JsonConvert.SerializeObject(_Producto);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Producto> ProductoRest = JsonConvert.DeserializeObject<EN_Response<EN_Producto>>(result);
                ProductosResponse = ProductoRest.Rbody;
            }
        }

        public static async Task<List<EN_Producto>> deleteProducto(int _id)
        {

            string _endPoint = _apiPath + "/deleteProducto";
            ProductosResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Producto> ProductoRest = JsonConvert.DeserializeObject<EN_Response<EN_Producto>>(result);
                ProductosResponse = ProductoRest.Rbody;
            }

            return ProductosResponse;
        }

    }
}
