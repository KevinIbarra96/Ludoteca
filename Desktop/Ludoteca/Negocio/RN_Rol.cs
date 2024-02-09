using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class RN_Rol
    {
        public static async Task<List<EN_Rol>> RN_GetAllRols()
        {
            return await DB_Rol.getAllRol();
        }
        public static async Task<List<EN_Rol>> RN_GetRolByID(int _id)
        {
            return await DB_Rol.getRolById(_id);
        }
        public static async Task<List<EN_Rol>> RN_DeleteRol(int _ide)
        {
            return await DB_Rol.deleteRol(_ide);
        }
        public static async Task<List<EN_Rol>> RN_UpdateRol(EN_Rol eN_Rol)
        {
            return await DB_Rol.updateRol(eN_Rol);
        }
        public static async Task<List<EN_Rol>> RN_AddNewRol(EN_Rol eN_Rol)
        {
            return await DB_Rol.addNewRol(eN_Rol);
        }
    }
}
