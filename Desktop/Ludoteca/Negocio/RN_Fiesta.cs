using Data;
using Entidad;

namespace Negocio
{
    public class RN_Fiesta
    {
        public static async Task<EN_Response<DateTime>> RN_FechasProgramadas()
        {
            return await DB_Fiesta.getFechasProgramadas();
        }
        public static async Task<EN_Response<EN_Fiesta>> RN_GetAllFiesta()
        {
            return await DB_Fiesta.getAllFiesta();
        }
        public static async Task<EN_Response<EN_Fiesta>> RN_GetAllActiveFiestas()
        {
            return await DB_Fiesta.getAllActiveFiesta();
        }
        public static async Task<EN_Response<EN_Fiesta>> RN_GetFiestaByID(int _id)
        {
            return await DB_Fiesta.getFiestaById(_id);
        }
        public static async Task<EN_Response<EN_Fiesta>> RN_DeleteFiesta(int _ide)
        {
            return await DB_Fiesta.deleteFiesta(_ide);
        }
        public static async Task<EN_Response<EN_Fiesta>> RN_UpdateFiesta(EN_Fiesta eN_Fiesta)
        {
            return await DB_Fiesta.updateFiesta(eN_Fiesta);
        }
        public static async Task<EN_Response<EN_Fiesta>> RN_AddNewFiesta(EN_Fiesta eN_Fiesta)
        {
            return await DB_Fiesta.addNewFiesta(eN_Fiesta);
        }
    }
}
