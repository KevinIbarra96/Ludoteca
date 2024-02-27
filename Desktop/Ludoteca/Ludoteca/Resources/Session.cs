using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System;

namespace Ludoteca.Resources
{
    class Session
    {
        public static int UserId = 1;
        public static string UserName = "Administrador";
        public static string RolName ="Administrador";
        public static int RolId = 1;
        public static string GetSessionId()
        {
            return Preferences.Get("SessionId", string.Empty);
        }

        public static void SetSessionId(string sessionId)
        {
            Preferences.Set("SessionId", sessionId);
        }

        public static bool IsSessionActive()
        {
            return !string.IsNullOrEmpty(GetSessionId());
        }

        public static void ClearSession()
        {
            Preferences.Remove("SessionId");
        }
    }

}
