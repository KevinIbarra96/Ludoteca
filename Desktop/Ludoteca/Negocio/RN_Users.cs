﻿using Data;
using Entidad;

namespace Negocio
{
    public class RN_Users
    {
        public static async Task<List<EN_User>> RN_AddNewUser(EN_User eN_User)
        {
            return await DB_Users.addNewUser(eN_User);
        }

        public static async Task<List<EN_User>> RN_GetAllUsers()
        {
            return await DB_Users.getAllUsers();
        }

        public static async Task<List<EN_User>> RN_GetUserByID(int _id)
        {
            return await DB_Users.getUserByID(_id);
        }
    }
}
