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
                LoadSession();
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, mostrar un mensaje de error o registrarla)
                Console.WriteLine($"Error al verificar sesión y navegar: {ex.Message}");
            }
        }
        private async Task CheckSessionAndNavigate()
        {
            //MAnejar propiedades del registry para guardar el path del archivo de session.--Pendiente, por definir
            //Opcion1-Crear un archivo xml donde se guarden las mismas propiedades que session, serializa la propiedades de la session en la clase session, en caso de estar una session activa te mande a app shell en caso de que no te mande a login
            //Opcion2-Agregar a la base de datos en la tabla usuario el campo sesion el cual sea un booleano, y agregar un campo varchar para relacionar el equipo al usuario y comparar si el usuario esta activo en esta compu o esta activo en otra, y si esta activo en la compu actual que inicie sesion, y si no ematchea ambos campos que mande mensaje diciendo que esta activo ya el usuario en otra compu este campo puede ser el numero de serie del dispositivoo la mac, o algun identificador que no se repita, a tu consideracion.
            if (false)
            {
                MainPage = new AppShell();
                
            }
            else
            {
                MainPage = new Login();
            }

        }
        private void LoadSession()
        {
            // Código para cargar la sesión desde el archivo XML
            Session.LoadSession();
        }

      
    }
}
