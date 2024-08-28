using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RN_TipoServicio
    {
        public static async Task<EN_Response<EN_TipoServicio>> RN_GetAllActiveTipoServicio()
        {
            return await DB_TipoServicio.getAllActiveTipoServicio();
        }
    }
}
