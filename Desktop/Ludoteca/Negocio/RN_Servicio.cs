using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RN_Servicio
    {
        public static async Task<EN_Response<EN_Servicio>> RN_setNewPrecio(int id,int precio)
        {
            return await DB_Servicio.setNewPrecio(id, precio);
        }
        public static async Task<List<EN_Servicio>> RN_GetAllServicios()
        {
            return await DB_Servicio.getAllServicios();
        }
        public static async Task<List<EN_Servicio>> RN_GetAllActiveServicios()
        {
            return await DB_Servicio.getAllActiveServicios();
        }
        public static async Task<List<EN_Servicio>> RN_GetServicioByID(int _id)
        {
            return await DB_Servicio.getServiciosById(_id);
        }
        public static async Task<List<EN_Servicio>> RN_DeleteServicio(int _ide)
        {
            return await DB_Servicio.deleteServicios(_ide);
        }
        public static async Task RN_UpdateServicio(EN_Servicio eN_Servicio)
        {
            await DB_Servicio.updateServicio(eN_Servicio);
        }
        public static async Task<EN_Response<EN_Servicio>> RN_AddNewServicio(EN_Servicio eN_Servicio)
        {
            return await DB_Servicio.addNewServicios(eN_Servicio);
        }
    }
}
