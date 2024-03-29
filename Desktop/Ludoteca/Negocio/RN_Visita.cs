using Data;
using Entidad;

namespace Negocio
{
    public class RN_Visita
    {
        public static async Task<EN_Response<EN_Visita>> ingresarNuevaVisita(EN_Visita visita)
        {
            return await DB_Visita.ingresarNuevaVisita(visita);
        }
        public static async Task<EN_Response<EN_Visita>> RN_getAllVisitasActivas()
        {
            return await DB_Visita.getAllVisitasActivas();
        }
        public static async Task<List<EN_Visita>> RN_GetAllVisitas()
        {
            return await DB_Visita.getAllVisitas();
        }
        public static async Task<List<EN_Visita>> RN_GetVisitaByID(int _id)
        {
            return await DB_Visita.getVisitaById(_id);
        }
        public static async Task<List<EN_Visita>> RN_DeleteVisita(int _ide)
        {
            return await DB_Visita.deleteVisita(_ide);
        }
        public static async Task<List<EN_Visita>> RN_UpdateVisita(EN_Visita eN_Visita)
        {
            return await DB_Visita.updateVisita(eN_Visita);
        }
        public static async Task<List<EN_Visita>> RN_AddNewVisita(EN_Visita eN_Visita)
        {
            return await DB_Visita.addNewVisita(eN_Visita);
        }
    }
}
