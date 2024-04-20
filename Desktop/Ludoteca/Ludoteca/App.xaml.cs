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

            //Initialize the application properties
            ApiRest_Properties apiRest_Properties = new ApiRest_Properties();

            InitializeAppAsync();
            getPrecioXMinute();
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

    }
}

