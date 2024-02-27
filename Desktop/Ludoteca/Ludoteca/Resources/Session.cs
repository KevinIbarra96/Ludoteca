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
        public static int UserId;
        public static string UserName;
        public static string RolName;
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
