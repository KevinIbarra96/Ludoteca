using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class RN_Hijo
    {
        public static async Task<List<EN_Hijo>> RN_GetAllHijos()
        {
            return await DB_Hijo.getAllHijos();
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
        public static async Task<List<EN_Hijo>> RN_AddNewHijo(EN_Hijo eN_Hijo)
        {
            return await DB_Hijo.addNewHijo(eN_Hijo);
        }
    }
}
