using Data;
using Entidad;

namespace Negocio
{
    public class RN_Rol
    {
        public static async Task<EN_Response<EN_Rol>> RN_GetAllRols()
        {
            return await DB_Rol.getAllRol();
        }
        public static async Task<EN_Response<EN_Rol>> RN_GetAllActiveRols()
        {
            return await DB_Rol.getAllActiveRol();
        }
        public static async Task<List<EN_Rol>> RN_GetRolByID(int _id)
        {
            return await DB_Rol.getRolById(_id);
        }
        public static async Task<List<EN_Rol>> RN_DeleteRol(int _ide)
        {
            return await DB_Rol.deleteRol(_ide);
        }
        public static async Task<EN_Response<EN_Rol>> RN_UpdateRol(EN_Rol eN_Rol, List<EN_Menu> MenuList)
        {
            return await DB_Rol.updateRol(eN_Rol, MenuList);
        }
        public static async Task<EN_Response<EN_Rol>> RN_AddNewRol(EN_Rol eN_Rol, List<EN_Menu> MenuList)
        {
            return await DB_Rol.addNewRol(eN_Rol, MenuList);
        }
    }
}
