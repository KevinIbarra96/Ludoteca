﻿using Data;
using Entidad;

namespace Negocio
{
    public class RN_Oferta
    {
        public static async Task<EN_Response<EN_Oferta>> RN_GetAllOfertas()
        {
            return await DB_Oferta.getAllOfertas();
        }
        public static async Task<EN_Response<EN_Oferta>> RN_GetAllActiveOfertas()
        {
            return await DB_Oferta.getAllActiveOfertas();
        }
        public static async Task<EN_Response<EN_Oferta>> RN_GetOfertaByID(int _id)
        {
            return await DB_Oferta.getOfertasById(_id);
        }
        public static async Task<EN_Response<EN_Oferta>> RN_DeleteOferta(int _ide)
        {
            return await DB_Oferta.deleteOfertas(_ide);
        }
        public static async Task<EN_Response<EN_Oferta>> RN_UpdateOferta(EN_Oferta eN_Oferta)
        {
            return await DB_Oferta.updateOferta(eN_Oferta);
        }
        public static async Task<EN_Response<EN_Oferta>> RN_AddNewOferta(EN_Oferta eN_Oferta)
        {
            return await DB_Oferta.addNewOfertas(eN_Oferta);
        }
    }
}
