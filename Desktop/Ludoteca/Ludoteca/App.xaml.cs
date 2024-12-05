using Entidad;
using Ludoteca.Resources;
using System.Diagnostics;

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
                Debug.WriteLine($"Error al verificar sesión y navegar: {ex.Message}");
            }
        }

        private void VerificarSession()
        {
            AccionesSession.VerificarSession();
        }

    }
}
