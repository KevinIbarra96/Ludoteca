using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Tickets : ApiRest_Properties
    {
        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Tickets"; //Adding ControllerName to Path
        private static List<EN_Tickets> TicketsResponse = null;

        public static async Task<EN_Response<EN_Tickets>> getAllTicketsActivas()
        {
            EN_Response<EN_Tickets> response = null;

            string _endPoint = _apiPath + "/getAllActiveTickets"; //Adding endpoint to path

            using HttpResponseMessage responsevisit = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (responsevisit.IsSuccessStatusCode)
            {
                var content = await responsevisit.Content.ReadAsStringAsync();

                response = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(content);
            }

            return response;
        }

        public static async Task<List<EN_Tickets>> getAllTickets()
        {
            TicketsResponse = null;
            string _enPoint = _apiPath + "/getAllTickets"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                EN_Response<EN_Tickets> TicketRes = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(content);

                TicketsResponse = TicketRes.Rbody;

            }
            return TicketsResponse;
        }


        public static async Task<EN_Response<EN_Tickets>> addNewTicket(EN_Tickets _Ticket)
        {


            EN_Response<EN_Tickets> Response = null;
            string endpointpath = _apiPath + "/addNewTicket";

            EN_Tickets RequestBody = _Ticket;

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();


                Response = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(result);
            }

            return Response;
        }
        public static async Task<List<EN_Tickets>> getTicketById(int _id)
        {

            string _endPoint = _apiPath + "/getTicketById";
            TicketsResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Tickets> TicketRest = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(result);
                TicketsResponse = TicketRest.Rbody;
            }

            return TicketsResponse;
        }
        public static async Task<List<EN_Tickets>> updateTicket(EN_Tickets _Ticket)
        {

            TicketsResponse = null;
            string endpointpath = _apiPath + "/editTicket";

            EN_Tickets RequestBody = new EN_Tickets();

            var requestData = JsonConvert.SerializeObject(RequestBody);

            HttpContent content = new StringContent(requestData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(endpointpath, content);


            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Tickets> TicketRest = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(result);
                TicketsResponse = TicketRest.Rbody;
            }

            return TicketsResponse;
        }

        public static async Task<List<EN_Tickets>> deleteTicket(int _id)
        {

            string _endPoint = _apiPath + "/deleteTicket";
            TicketsResponse = null;

            var requestBody = new { id = _id };

            var requesData = JsonConvert.SerializeObject(requestBody);

            HttpContent content =
                new StringContent(requesData, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await cliente.PostAsync(_endPoint, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                EN_Response<EN_Tickets> TicketRest = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(result);
                TicketsResponse = TicketRest.Rbody;
            }

            return TicketsResponse;
        }
        public static async Task<EN_Response<EN_Tickets>> getNewFolio()
        {


            EN_Response<EN_Tickets> response = null;
            string _endPoint = _apiPath + "/getNewFolio"; //Adding endpoint to path

            using HttpResponseMessage responsevisit = await ApiRest_Properties.cliente.GetAsync(_endPoint);

            if (responsevisit.IsSuccessStatusCode)
            {
                var content = await responsevisit.Content.ReadAsStringAsync();

                response = JsonConvert.DeserializeObject<EN_Response<EN_Tickets>>(content);
            }

            return response;
        }
    }
}
