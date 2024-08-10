using Entidad;
using Ludoteca.Resources;
using Negocio;
using Resources.Properties;

namespace Ludoteca
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //string rutaProyecto = Configuracion.ObtenerRutaProyecto();
            //if(string.IsNullOrEmpty(rutaProyecto))
            //{
                string rutaProyecto = @"C:\MiProyecto";
            Configuracion.CreateSubKey();
                //Configuracion.GuardarRutaProyecto(rutaProyecto);
            //}


            //Initialize the application properties
            ApiRest_Properties apiRest_Properties = new ApiRest_Properties();

            InitializeAppAsync();
            getPrecioXMinute();
            getEdadMinima();
            getEdadMaxima();
        }
        private async void InitializeAppAsync()
        {
            try
            {
                 VerificarSession();
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error o registrarla)
                Console.WriteLine($"Error al verificar sesión y navegar: {ex.Message}");
            }
        }
       
        private void  VerificarSession()
        {
            AccionesSession.VerificarSession();
        }

        private async void getPrecioXMinute()
        {
            try
            {
                //Actualizar el precio
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(1);
                ApplicationProperties.precioXMinute = double.Parse(response.Rbody[0].ConfigDecimalValue.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message );
            }
        }
        private async void getEdadMinima()
        {
            try
            {
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(2);
                ApplicationProperties.edadMinima = response.Rbody[0].ConfigIntValue;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }
        private async void getEdadMaxima()
        {
            try
            {
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(3);
                ApplicationProperties.edadMaxima = response.Rbody[0].ConfigIntValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
