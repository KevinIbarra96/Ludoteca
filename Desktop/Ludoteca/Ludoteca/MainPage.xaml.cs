using Entidad;
using Negocio;
using Ludoteca.ViewModel;
using System.Collections.ObjectModel;
using Mopups.Services;
using Ludoteca.Resources;
using CommunityToolkit.Maui.Alerts;

namespace Ludoteca
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
        }
        public async void OnCerrarSesionClicked(object sender, EventArgs e)
        {
            AccionesSession.CerrarSession();

            string sessionMessage = $"Usuario {Session.UserName} desconectado";
            var toastMessage = Toast.Make(sessionMessage, CommunityToolkit.Maui.Core.ToastDuration.Short, 13);
            await toastMessage.Show();

            // Redirigir a la página principal de la aplicación
            App.Current.MainPage = new Login();
        }

    

    

    }
}
