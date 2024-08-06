using Entidad;
using Negocio;
using Resources.Properties;
using CommunityToolkit.Maui.Core;
//using CommunityToolkit.Maui.Markup;


namespace Ludoteca.View;

public partial class ConfiguracionView : ContentPage
{

	private EN_Configuracion precioConfiguracion = null;

	public ConfiguracionView()
	{
		//Agregar inserciones a la base de datos para asegurarce que los identificadores sea el mismo y no traer una configuracion diferemte o buscar una forma para asegurarse
		//Considerar que cuando hay visitas activas no sea posible realizar cambios en el precio por minuto
		InitializeComponent();

		EntryPrecioxMinuto.Text = ApplicationProperties.precioXMinute.ToString();
        
    }

    // Método para manejar el evento de clic
    private void OnButtonClicked(object sender, EventArgs e)
    {
        DisplayAlert("Alerta", "Botón clicado", "OK");
    }

    private async void EntryPrecioxMinuto_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
			//Actualizar el precio
			EN_Response<EN_Configuracion> responseConfig = await RN_Configuracion.getConfigurationById(1);
			precioConfiguracion = responseConfig.Rbody[0];
			precioConfiguracion.ConfigDecimalValue = double.Parse(EntryPrecioxMinuto.Text);
			EN_Response<EN_Configuracion> response = await RN_Configuracion.updatePrecioConfiguration(precioConfiguracion);

		}catch (Exception ex)
		{
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
}