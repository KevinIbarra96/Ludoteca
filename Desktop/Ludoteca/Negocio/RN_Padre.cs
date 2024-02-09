﻿using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class RN_Padre
    {
        public static async Task<List<EN_Padre>> RN_GetAllPadres()
        {
            return await DB_Padre.getAllPadres();
        }
        public static async Task<List<EN_Padre>> RN_GetPadreByID(int _id)
        {
            return await DB_Padre.getPadreById(_id);
        }
        public static async Task<List<EN_Padre>> RN_DeletePadre(int _ide)
        {
            return await DB_Padre.deletePadre(_ide);
        }
        public static async Task<List<EN_Padre>> RN_UpdatePadre(EN_Padre eN_Padre)
        {
            return await DB_Padre.updatePadre(eN_Padre);
        }
        public static async Task<List<EN_Padre>> RN_AddNewPadre(EN_Padre eN_Padre)
        {
            return await DB_Padre.addNewPadre(eN_Padre);
        }
    }
}
