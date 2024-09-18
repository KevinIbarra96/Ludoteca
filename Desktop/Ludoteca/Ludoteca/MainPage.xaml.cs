using Entidad;
using Negocio;
using Ludoteca.ViewModel;
using System.Collections.ObjectModel;
using Mopups.Services;
using Ludoteca.Resources;
using CommunityToolkit.Maui.Alerts;
using Resources.Properties;

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
                ApplicationProperties.precioXMinute = double.Parse(response.Rbody[0].ConfigDecimalValue.ToString());
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
                ApplicationProperties.edadMinima = response.Rbody[0].ConfigIntValue;
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
                ApplicationProperties.edadMaxima = response.Rbody[0].ConfigIntValue;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
            }
        }



    }
}
