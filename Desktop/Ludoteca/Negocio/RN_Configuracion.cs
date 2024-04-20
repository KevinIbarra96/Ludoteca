
using Entidad;
using Data;

namespace Negocio
{
    public class RN_Configuracion
    {
        public static async Task<EN_Response<EN_Configuracion>> getAllConfiguracion()
        {
            return await DB_Configuracion.getAllConfiguracion();
        }
        public static async Task<EN_Response<EN_Configuracion>> getConfigurationById(int _id)
        {
            return await DB_Configuracion.getConfigurationById(_id);
        }
        public static async Task<EN_Response<EN_Configuracion>> updatePrecioConfiguration(EN_Configuracion _configuration) { 
            return await DB_Configuracion.updatePrecioConfiguration(_configuration);
        }
    }
}
