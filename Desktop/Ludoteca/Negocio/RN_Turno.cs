using Data;
using Entidad;

namespace Negocio
{
    public class RN_Turno
    {
        public static async Task<EN_Response<EN_Turno>> RN_GetAllActiveTurno()
        {
            return await DB_Turno.getAllActiveTurno();
        }
    }
}
