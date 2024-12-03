using Data;
using Entidad;

namespace Negocio
{
    public class RN_TipoServicio
    {
        public static async Task<EN_Response<EN_TipoServicio>> RN_GetAllActiveTipoServicio()
        {
            return await DB_TipoServicio.getAllActiveTipoServicio();
        }
    }
}
