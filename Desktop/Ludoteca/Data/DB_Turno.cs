using Entidad;
using Newtonsoft.Json;

namespace Data
{
    public class DB_Turno : ApiRest_Properties
    {

        private static string _apiPath = ApiRest_Properties.cliente.BaseAddress + "/Turno"; //Adding ControllerName to Path
        private static EN_Response<EN_Turno> TurnoResponse = null;

        public static async Task<EN_Response<EN_Turno>> getAllActiveTurno()
        {
            TurnoResponse = null;
            string _enPoint = _apiPath + "/getAllActiveTurno"; //Adding endpoint to path

            using HttpResponseMessage response = await ApiRest_Properties.cliente.GetAsync(_enPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                TurnoResponse = JsonConvert.DeserializeObject<EN_Response<EN_Turno>>(content);

            }
            return TurnoResponse;
        }


    }
}
