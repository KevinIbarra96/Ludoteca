using Microsoft.Win32;

namespace Ludoteca.Resources
{
    public class Configuracion
    {
        private const string claveRegistro = @"SOFTWARE\Ludoteca";

        public static void GuardarRutaProyecto(string ruta)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(claveRegistro);
            
            key.SetValue("RutaProyecto", ruta);
        }

        public static string ObtenerRutaProyecto()
        {
            Registry.CurrentUser.OpenSubKey(claveRegistro);
            return Registry.GetValue($"HKEY_CURRENT_USER\\{claveRegistro}", "RutaProyecto", null)?.ToString();

        }

        public static void CreateSubKey()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Ludoteca");
            key.SetValue("RutaProyecto", "Test");
            key.Close();
        }
    }
}