using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RN_Turno
    {
        public static async Task<EN_Response<EN_Turno>> RN_GetAllActiveTurno()
        {
            return await DB_Turno.getAllActiveTurno();
        }
    }
}
