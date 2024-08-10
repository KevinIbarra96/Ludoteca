using Entidad;
using Negocio;
using Resources.Properties;
using CommunityToolkit.Maui.Core;
//using CommunityToolkit.Maui.Markup;


namespace Ludoteca.View;

public partial class ConfiguracionView : ContentPage
{

	private EN_Configuracion precioConfiguracion = null, edadminimaConfiguration = null, edadMaximaConfiguration = null;

	public ConfiguracionView()
	{
		//Agregar inserciones a la base de datos para asegurarce que los identificadores sea el mismo y no traer una configuracion diferemte o buscar una forma para asegurarse
		//Considerar que cuando hay visitas activas no sea posible realizar cambios en el precio por minuto
		InitializeComponent();

		EntryPrecioxMinuto.Text = ApplicationProperties.precioXMinute.ToString();
		EntryEdadMinima.Text = ApplicationProperties.edadMinima.ToString();
		EntryEdadMaxima.Text = ApplicationProperties.edadMaxima.ToString();
        
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
			EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(precioConfiguracion);

		}catch (Exception ex)
		{
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
	private async void EntryEdadMinima_event(object sender,TextChangedEventArgs e)
	{
		try
		{
            EN_Response<EN_Configuracion> responseConfig = await RN_Configuracion.getConfigurationById(2);
            edadminimaConfiguration = responseConfig.Rbody[0];
            edadminimaConfiguration.ConfigIntValue = int.Parse(EntryEdadMinima.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(edadminimaConfiguration);
        } catch (Exception ex)
		{
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");

        }



    }
	private async void EntryEdadMaxima_event(object sender, TextChangedEventArgs e)
	{
        try
        {
            EN_Response<EN_Configuracion> responseConfig = await RN_Configuracion.getConfigurationById(3);
            edadMaximaConfiguration = responseConfig.Rbody[0];
            edadMaximaConfiguration.ConfigIntValue = int.Parse(EntryEdadMaxima.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(edadMaximaConfiguration);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");

        }
    }
}