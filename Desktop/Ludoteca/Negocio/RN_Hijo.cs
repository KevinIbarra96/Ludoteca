﻿using Data;
using Entidad;

namespace Negocio
{
    public class RN_Hijo
    {
        public static async Task<List<EN_Hijo>> getHijosByPadresId(int _padreId)
        {
            return await DB_Hijo.getHijoByPadreId(_padreId);
        }
        public static async Task<List<EN_Hijo>> RN_GetAllHijos()
        {
            return await DB_Hijo.getAllHijos();
        }
        public static async Task<List<EN_Hijo>> getAllActiveHijos()
        {
            return await DB_Hijo.getAllActiveHijos();
        }
        public static async Task<List<EN_Hijo>> RN_GetHijoByID(int _id)
        {
            return await DB_Hijo.getHijoById(_id);
        }
        public static async Task<List<EN_Hijo>> RN_DeleteHijo(int _ide)
        {
            return await DB_Hijo.deleteHijo(_ide);
        }
        public static async Task<List<EN_Hijo>> RN_UpdateHijo(EN_Hijo eN_Hijo)
        {
            return await DB_Hijo.updateHijo(eN_Hijo);
        }
        public static async Task<EN_Response<EN_Hijo>> RN_AddNewHijo(EN_Hijo eN_Hijo)
        {
            return await DB_Hijo.addNewHijo(eN_Hijo);
        }
    }
}
