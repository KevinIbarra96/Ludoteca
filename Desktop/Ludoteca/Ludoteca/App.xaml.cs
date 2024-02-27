using Entidad;
using Ludoteca.Resources;

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
                await CheckSessionAndNavigate();
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error o registrarla)
                Console.WriteLine($"Error al verificar sesión y navegar: {ex.Message}");
            }
        }
        private async Task CheckSessionAndNavigate()
        {
            if (Session.IsSessionActive())
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new Login();
            }

        }
    }
}
