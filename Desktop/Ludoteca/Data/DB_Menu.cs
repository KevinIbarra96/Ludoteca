using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Menu : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Menu"; //Adding ControllerName to Path
        private static List<EN_Menu> MenusResponse = null;

        public static async Task<List<EN_Menu>> getAllMenu()
        {
            MenusResponse = null;
            string _enPoint = _apiPath + "/getAllMenu"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Menu> MenuRes = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(content);

                MenusResponse = MenuRes.Rbody;

            }
            return MenusResponse;
        }

        public static async Task<EN_Response<EN_Menu>> getAllActiveMenu()
        {
            EN_Response<EN_Menu> MenusResponse = null;
            string _enPoint = _apiPath + "/getAllActiveMenu"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                MenusResponse = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(content);

            }
            return MenusResponse;
        }

        public static async Task<List<EN_Menu>> getMenuById(int _id)
        {

            string _endPoint = _apiPath + "/getMenuById";
            MenusResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Menu> MenuRest = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(result);
                MenusResponse = MenuRest.Rbody;
            }

            return MenusResponse;
        }

        public static async Task<List<EN_Menu>> addNewMenu(EN_Menu _Menu)
        {

            MenusResponse = null;
            string endpointpath = _apiPath + "/addNewMenu";

            EN_Menu RequestBody = new EN_Menu();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Menu> MenuRest = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(result);
                MenusResponse = MenuRest.Rbody;
            }

            return MenusResponse;
        }

        public static async Task<List<EN_Menu>> updateMenu(EN_Menu _Menu)
        {

            MenusResponse = null;
            string endpointpath = _apiPath + "/editMenu";

            EN_Menu RequestBody = new EN_Menu();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Menu> MenuRest = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(result);
                MenusResponse = MenuRest.Rbody;
            }

            return MenusResponse;
        }

        public static async Task<List<EN_Menu>> deleteMenu(int _id)
        {

            string _endPoint = _apiPath + "/deleteMenu";
            MenusResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Menu> MenuRest = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(result);
                MenusResponse = MenuRest.Rbody;
            }

            return MenusResponse;
        }

        public static async Task<EN_Response<EN_Menu>> getMenuByRol(int idRol)
        {
            string _endPoint = _apiPath + "/getMenuByRol";
            EN_Response<EN_Menu> MenuRest = null;

            var requestBody = new { idRol = idRol };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                MenuRest = JsonConvert.DeserializeObject<EN_Response<EN_Menu>>(result);
            }

            return MenuRest;
        }

    }
}
