
using Entidad;
using Data;

namespace Negocio
{
    public class RN_Gafete
    {
        public static async Task<EN_Response<EN_Gafete>> getGafeteNoAsignado()
        {
            return await DB_Gafete.getGafeteNoAsignado();
        }
        
        public static async Task<EN_Response<EN_Gafete>> getAllGafete()
        {
            return await DB_Gafete.getAllGafete();
        }
        public static async Task<EN_Response<EN_Gafete>> getAllActiveGafete()
        {
            return await DB_Gafete.getAllActiveGafete();
        }
    }
}
