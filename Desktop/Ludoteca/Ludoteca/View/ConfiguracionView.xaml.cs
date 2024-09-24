using Entidad;
using Negocio;
using Resources.Properties;
using Ludoteca.ViewModel;
//using CommunityToolkit.Maui.Markup;


namespace Ludoteca.View;

public partial class ConfiguracionView : ContentPage
{

	private EN_Configuracion precioConfiguracion = null, edadMinimaConfiguracion, edadMaximaConfiguracion;
	private ConfiguracionViewModel viewModel;

	public ConfiguracionView()
	{
		//Agregar inserciones a la base de datos para asegurarce que los identificadores sea el mismo y no traer una configuracion diferemte o buscar una forma para asegurarse
		//Considerar que cuando hay visitas activas no sea posible realizar cambios en el precio por minuto
		InitializeComponent();

		viewModel = new ConfiguracionViewModel();
		BindingContext = viewModel;	

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
            if (string.IsNullOrEmpty(EntryPrecioxMinuto.Text))
            {
                return; // No hacer nada si está vacío
            }
            if (!double.TryParse(EntryPrecioxMinuto.Text, out double precioxminuto))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
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
    private async void EntryEdadMinima_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(EntryEdadMinima.Text))
            {
                return; // No hacer nada si está vacío
            }
            if (!int.TryParse(EntryEdadMinima.Text, out int edadMinima))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
            EN_Response<EN_Configuracion> responseConfig = await RN_Configuracion.getConfigurationById(2);
            edadMinimaConfiguracion = responseConfig.Rbody[0];
            edadMinimaConfiguracion.ConfigIntValue = int.Parse(EntryEdadMinima.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(edadMinimaConfiguracion);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
    private async void EntryEdadMaxima_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(EntryEdadMaxima.Text))
            {
                return; // No hacer nada si está vacío
            }
            if (!int.TryParse(EntryEdadMaxima.Text, out int edadMaxima))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
            EN_Response<EN_Configuracion> responseConfig = await RN_Configuracion.getConfigurationById(3);
            edadMaximaConfiguracion = responseConfig.Rbody[0];
            edadMaximaConfiguracion.ConfigIntValue = int.Parse(EntryEdadMaxima.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(edadMaximaConfiguracion);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private void AgregarGafete_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void HabilitarYDesHabilitarGafete_Tapped(object sender, TappedEventArgs e)
    {

    }
}