using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.Resources
{
    public class GlobalEnum
    {
        public enum Action
        {
            CREAR_NUEVO,
            ACTUALIZAR
        }

        public enum ErrorCode
        {
            SUCCESS = 0,
            NOT_FOUND = 402
        }

    }
}
