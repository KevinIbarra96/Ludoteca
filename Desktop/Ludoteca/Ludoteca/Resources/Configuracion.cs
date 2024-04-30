using Microsoft.Win32;


namespace Ludoteca.Resources
{
    public class Configuracion
    {
        private const string claveRegistro = @"SOFTWARE\Ludoteca";
       


        public static void ObtenerRutaProyecto()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Ludoteca");
 
            if (key != null)
            {
                Console.WriteLine(key.GetValue("RutaProyecto"));
                Console.WriteLine(key.GetValue("Setting2"));
                key.Close();
            }
        }

        public static void CreateSubKey()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("AppName");
            key = key.OpenSubKey("AppName", true);


            key.CreateSubKey("AppVersion");
            key = key.OpenSubKey("AppVersion", true);

            key.SetValue("yourkey", "yourvalue");
            key.Close();

            /**RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\OurSettings");

            //storing the values  
            key.SetValue("Setting1", "This is our setting 1");
            key.SetValue("Setting2", "This is our setting 2");
            key.Close();**/


        }
    }
}