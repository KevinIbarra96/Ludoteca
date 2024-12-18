﻿using Entidad;
using Newtonsoft.Json;



namespace Data
{
    public class DB_Users : ApiRest_Properties
    {

        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Users"; //Adding ControllerName to Path
        private static List<EN_User> usersResponse = null;

        public static async Task<EN_Response<EN_User>> login(string _UserName, string _Password)
        {
            EN_Response<EN_User> usersResponse = new EN_Response<EN_User>();
            string _endPoint = _apiPath + "/login";

            var requestBody = new { UserName = _UserName, Password = _Password };
            var requestData = JsonConvert.SerializeObject(requestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await cliente.PostAsync(_endPoint, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_User> userRest = JsonConvert.DeserializeObject<EN_Response<EN_User>>(result);
                usersResponse = userRest;

            }

            //return usersResponse.Rmessage;
            return usersResponse;
        }

        public static async Task<EN_Response<EN_User>> getUsersAndRol()
        {
            EN_Response<EN_User> usersResponse = null;
            string _enPoint = _apiPath + "/getUsersAndRol"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                usersResponse = JsonConvert.DeserializeObject<EN_Response<EN_User>>(content);

            }
            return usersResponse;
        }

        public static async Task<List<EN_User>> getAllUsers()
        {
            usersResponse = null;
            string _enPoint = _apiPath + "/getAllUsers"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_User> userRes = JsonConvert.DeserializeObject<EN_Response<EN_User>>(content);

                usersResponse = userRes.Rbody;

            }
            return usersResponse;
        }

        public static async Task<List<EN_User>> getAllActiveUsers()
        {
            usersResponse = null;
            string _enPoint = _apiPath + "/getAllActiveUsers"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_User> userRes = JsonConvert.DeserializeObject<EN_Response<EN_User>>(content);

                usersResponse = userRes.Rbody;

            }
            return usersResponse;
        }

        public static async Task<List<EN_User>> getUserByID(int _id)
        {

            string _endPoint = _apiPath + "/getUserById";
            usersResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await cliente.PostAsync(_endPoint, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_User> userRest = JsonConvert.DeserializeObject<EN_Response<EN_User>>(result);
                usersResponse = userRest.Rbody;
            }

            return usersResponse;
        }

        public static async Task<EN_Response<EN_User>> addNewUser(EN_User _user)
        {

            EN_Response<EN_User> usersResponse = null;
            string endpointpath = _apiPath + "/addNewUser";

            EN_User RequestBody = _user;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                usersResponse = JsonConvert.DeserializeObject<EN_Response<EN_User>>(result);

            }

            return usersResponse;
        }

        public static async Task<EN_Response<EN_User>> updateUser(EN_User _user)
        {

            EN_Response<EN_User> userRest = null;
            string endpointpath = _apiPath + "/editUser";

            EN_User RequestBody = _user;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                userRest = JsonConvert.DeserializeObject<EN_Response<EN_User>>(result);

            }

            return userRest;
        }

        public static async Task<List<EN_User>> deleteUser(int _id)
        {

            string _endPoint = _apiPath + "/deleteUser";
            usersResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_User> userRest = JsonConvert.DeserializeObject<EN_Response<EN_User>>(result);
                usersResponse = userRest.Rbody;
            }

            return usersResponse;
        }


    }
}
