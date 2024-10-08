using Entidad;
using Negocio;
using Ludoteca.ViewModel;
using System.Collections.ObjectModel;
using Mopups.Services;
using Ludoteca.Resources;
using CommunityToolkit.Maui.Alerts;
using Resources.Properties;
#if WINDOWS
using Windows.Storage.Pickers;
using Microsoft.UI.Xaml.Controls;
#endif

namespace Ludoteca
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            getPrecioXMinute();
            getEdadMinima();
            getEdadMaxima();
            GetRutaAsync();
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

        private async void getPrecioXMinute()
        {
            try
            {
                //Actualizar el precio
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(1);
                ApplicationProperties.precioXMinute = response.Rbody[0];
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");

            }
        }
        private async void getEdadMinima()
        {
            try
            {
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(2);
                ApplicationProperties.edadMinima = response.Rbody[0];
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
            }
        }
        private async void getEdadMaxima()
        {
            try
            {
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(3);
                ApplicationProperties.edadMaxima = response.Rbody[0];
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
            }
        }
        private async Task GetRutaAsync()
        {
            try
            {
                // Obtener la configuración con id = 4 que contiene la ruta
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(4);
                ApplicationProperties.rutaTickets = response.Rbody[0];

                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ha ocurrido un error\nDetalle: {ex.Message}", "OK");
            }
        }
        
      

    }
}
