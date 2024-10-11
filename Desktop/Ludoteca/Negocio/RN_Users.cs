using Data;
using Entidad;

namespace Negocio
{
    public class RN_Users
    {
        public static async Task<EN_Response<EN_User>> RN_Login(string UserName,string Password)
        {
            
            return await DB_Users.login(UserName, Password);
        }
        public static async Task<List<EN_User>> RN_GetAllUsers()
        {
            return await DB_Users.getAllUsers();
        }
        public static async Task<EN_Response<EN_User>> RN_GetUsersAndRol()
        {
            return await DB_Users.getUsersAndRol();
        }
        public static async Task<List<EN_User>> RN_GetAllActiveUsers()
        {
            return await DB_Users.getAllActiveUsers();
        }
        public static async Task<List<EN_User>> RN_GetUserByID(int _id)
        {
            return await DB_Users.getUserByID(_id);
        }
        public static async Task<List<EN_User>> RN_DeleteUser(int _ide)
        {
            return await DB_Users.deleteUser(_ide);
        }
        public static async Task<List<EN_User>> RN_UpdateUser(EN_User eN_User)
        {
            return await DB_Users.updateUser(eN_User);
        }
        public static async Task<List<EN_User>> RN_AddNewUser(EN_User eN_User)
        {
            return await DB_Users.addNewUser(eN_User);
        }
    }
}
