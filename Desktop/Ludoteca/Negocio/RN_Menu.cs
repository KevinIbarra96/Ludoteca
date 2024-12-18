﻿using Data;
using Entidad;

namespace Negocio
{
    public class RN_Menu
    {
        public static async Task<EN_Response<EN_Menu>> RN_GetMenuByRol(int _idRol)
        {
            return await DB_Menu.getMenuByRol(_idRol);
        }

        public static async Task<List<EN_Menu>> RN_GetAllMenus()
        {
            return await DB_Menu.getAllMenu();
        }
        public static async Task<EN_Response<EN_Menu>> getAllActiveMenu()
        {
            return await DB_Menu.getAllActiveMenu();
        }
        public static async Task<List<EN_Menu>> RN_GetMenuByID(int _id)
        {
            return await DB_Menu.getMenuById(_id);
        }
        public static async Task<List<EN_Menu>> RN_DeleteMenu(int _ide)
        {
            return await DB_Menu.deleteMenu(_ide);
        }
        public static async Task<List<EN_Menu>> RN_UpdateMenu(EN_Menu eN_Menu)
        {
            return await DB_Menu.updateMenu(eN_Menu);
        }
        public static async Task<List<EN_Menu>> RN_AddNewMenu(EN_Menu eN_Menu)
        {
            return await DB_Menu.addNewMenu(eN_Menu);
        }
    }
}
