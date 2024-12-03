using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Rol : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Rol"; //Adding ControllerName to Path
        private static List<EN_Rol> RolsResponse = null;

        public static async Task<EN_Response<EN_Rol>> getAllRol()
        {
            EN_Response<EN_Rol> RolsResponse = null;
            string _enPoint = _apiPath + "/getAllRol"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                RolsResponse = JsonConvert.DeserializeObject<EN_Response<EN_Rol>>(content);

            }
            return RolsResponse;
        }

        public static async Task<EN_Response<EN_Rol>> getAllActiveRol()
        {
            EN_Response<EN_Rol> RolsResponse = null;
            string _enPoint = _apiPath + "/getAllActiveRol"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                RolsResponse = JsonConvert.DeserializeObject<EN_Response<EN_Rol>>(content);

            }
            return RolsResponse;
        }

        public static async Task<List<EN_Rol>> getRolById(int _id)
        {

            string _endPoint = _apiPath + "/getRolById";
            RolsResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Rol> RolRest = JsonConvert.DeserializeObject<EN_Response<EN_Rol>>(result);
                RolsResponse = RolRest.Rbody;
            }

            return RolsResponse;
        }

        public static async Task<EN_Response<EN_Rol>> addNewRol(EN_Rol eN_Rol, List<EN_Menu> MenuList)
        {            
            EN_Response<EN_Rol> RolsResponse = null;
            string endpointpath = _apiPath + "/addNewRol";

            var RequestBody = new { RolName = eN_Rol.RolName, MenuList = MenuList };

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                RolsResponse = JsonConvert.DeserializeObject<EN_Response<EN_Rol>>(result);
            }

            return RolsResponse;
        }

        public static async Task<EN_Response<EN_Rol>> updateRol(EN_Rol _Rol, List<EN_Menu> MenuList)
        {

            return null;

            EN_Response<EN_Rol> RolsResponse = null;
            string endpointpath = _apiPath + "/editRol";

            var RequestBody = new { RolName = _Rol.RolName, MenuList = MenuList };

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                RolsResponse = JsonConvert.DeserializeObject<EN_Response<EN_Rol>>(result);
            }

            return RolsResponse;
        }

        public static async Task<List<EN_Rol>> deleteRol(int _id)
        {

            string _endPoint = _apiPath + "/deleteRol";
            RolsResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Rol> RolRest = JsonConvert.DeserializeObject<EN_Response<EN_Rol>>(result);
                RolsResponse = RolRest.Rbody;
            }

            return RolsResponse;
        }

    }
}
