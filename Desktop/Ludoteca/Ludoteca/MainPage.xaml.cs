using Entidad;
using Negocio;
using Resources.Properties;

namespace Ludoteca
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            getPrecioTreintaMin();
            getPrecioSesentaMin();
            getPrecioDespuesServicioMin();
            getPrecioNiñoAdicional();
            getEdadMinima();
            getEdadMaxima();
            GetRutaTicketAsync();
        }

        private async void getPrecioTreintaMin()
        {
            try
            {
                //Actualizar el precio
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdPrecioMinutoTreintaMin);
                ApplicationProperties.PrecioMinutoTreintaMin = response.Rbody[0];
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");

            }
        }
        private async void getPrecioNiñoAdicional()
        {
            try
            {
                //Actualizar el precio
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdPrecioNiñoAdicional);
                ApplicationProperties.PrecioNiñoAdicional = response.Rbody[0];
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");

            }
        }
        private async void getPrecioSesentaMin()
        {
            try
            {
                //Actualizar el precio
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdPrecioMinutoSesentaMin);
                ApplicationProperties.PrecioMinutoSesentaMin = response.Rbody[0];
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");

            }
        }
        private async void getPrecioDespuesServicioMin()
        {
            try
            {
                //Actualizar el precio
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdPrecioMinutoDespuesServicio);
                ApplicationProperties.PrecioMinutoDespuesServicio = response.Rbody[0];
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
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdedadMinima);
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
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdedadMaxima);
                ApplicationProperties.edadMaxima = response.Rbody[0];
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
            }
        }
        private async Task GetRutaTicketAsync()
        {
            try
            {
                // Obtener la configuración con id = 4 que contiene la ruta
                EN_Response<EN_Configuracion> response = await RN_Configuracion.getConfigurationById(ApplicationProperties.IdrutaTickets);
                ApplicationProperties.rutaTickets = response.Rbody[0];


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ha ocurrido un error\nDetalle: {ex.Message}", "OK");
            }
        }



    }
}
