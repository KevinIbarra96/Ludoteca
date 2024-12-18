using Entidad;
using Ludoteca.ViewModel;
using Negocio;
using Resources.Properties;
using Windows.Storage.Pickers;

namespace Ludoteca.View;

public partial class ConfiguracionView : ContentPage
{

    private EN_Configuracion precioTreintaMin, precioSesentaMin, precioDespuesServicio, PrecioNiñoAdicional, edadMinimaConfiguracion, edadMaximaConfiguracion, rutaConfig;
    private ConfiguracionViewModel viewModel;

    public ConfiguracionView()
    {
        //Agregar inserciones a la base de datos para asegurarce que los identificadores sea el mismo y no traer una configuracion diferemte o buscar una forma para asegurarse
        //Considerar que cuando hay visitas activas no sea posible realizar cambios en el precio por minuto
        InitializeComponent();

        viewModel = new ConfiguracionViewModel();
        BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        loadConfiguraciones();

    }

    private void loadConfiguraciones()
    {
        precioTreintaMin = ApplicationProperties.PrecioMinutoTreintaMin;
        precioSesentaMin = ApplicationProperties.PrecioMinutoSesentaMin;
        precioDespuesServicio = ApplicationProperties.PrecioMinutoDespuesServicio;
        PrecioNiñoAdicional = ApplicationProperties.PrecioNiñoAdicional;
        edadMinimaConfiguracion = ApplicationProperties.edadMinima;
        edadMaximaConfiguracion = ApplicationProperties.edadMaxima;
        rutaConfig = ApplicationProperties.rutaTickets;

        loadConfigCampos();
    }
    private void loadConfigCampos()
    {
        EntryPrecioMinutoTreintaMin.Text = ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue.ToString();
        EntryPrecioMinutoSesentaMin.Text = ApplicationProperties.PrecioMinutoSesentaMin.ConfigDecimalValue.ToString();
        EntryPrecioMinutoDespuesServicio.Text = ApplicationProperties.PrecioMinutoDespuesServicio.ConfigDecimalValue.ToString();
        EntryPrecioNiñoAdicional.Text = ApplicationProperties.PrecioNiñoAdicional.ConfigDecimalValue.ToString();
        EntryEdadMinima.Text = ApplicationProperties.edadMinima.ConfigIntValue.ToString();
        EntryEdadMaxima.Text = ApplicationProperties.edadMaxima.ConfigIntValue.ToString();
        //labelRutaTickets.Text = ApplicationProperties.rutaTickets.ConfigStringValue.ToString();
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
            if (string.IsNullOrEmpty(EntryPrecioMinutoTreintaMin.Text))
                return; // No hacer nada si está vacío

            if (!double.TryParse(EntryPrecioMinutoTreintaMin.Text, out double precioxminuto))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
            //Actualizar el precio
            precioTreintaMin.ConfigDecimalValue = double.Parse(EntryPrecioMinutoTreintaMin.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(precioTreintaMin);

        }
        catch (Exception ex)
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
            edadMinimaConfiguracion.ConfigIntValue = int.Parse(EntryEdadMinima.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(edadMinimaConfiguracion);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async void EntryPrecioMinutoSesentaMin_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(EntryPrecioMinutoSesentaMin.Text))
                return; // No hacer nada si está vacío
                        // 
            if (!double.TryParse(EntryPrecioMinutoSesentaMin.Text, out double precioSesentaMins))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
            precioSesentaMin.ConfigDecimalValue = double.Parse(EntryPrecioMinutoSesentaMin.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(precioSesentaMin);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async void EntryPrecioNiñoAdicional_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(EntryPrecioNiñoAdicional.Text))
                return; // No hacer nada si está vacío
                        // 
            if (!double.TryParse(EntryPrecioNiñoAdicional.Text, out double precioSesentaMins))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
            PrecioNiñoAdicional.ConfigDecimalValue = double.Parse(EntryPrecioNiñoAdicional.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(PrecioNiñoAdicional);

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async void EntryPrecioMinutoDespuesServicio_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(EntryPrecioMinutoDespuesServicio.Text))
                return; // No hacer nada si está vacío
                        // 
            if (!double.TryParse(EntryPrecioMinutoDespuesServicio.Text, out double PrecioMinDespServicio))
            {
                await DisplayAlert("Error", "Por favor, ingrese un valor numérico válido.", "OK");
                return; // Salir si no es un número válido
            }
            precioDespuesServicio.ConfigDecimalValue = double.Parse(EntryPrecioMinutoDespuesServicio.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(precioDespuesServicio);

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
            edadMaximaConfiguracion.ConfigIntValue = int.Parse(EntryEdadMaxima.Text);
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(edadMaximaConfiguracion);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async void AbrirRutaArchivo_Tapped(object sender, TappedEventArgs e)
    {
        var folderPicker = new Windows.Storage.Pickers.FolderPicker();
        var hwnd = ((MauiWinUIWindow)Application.Current.Windows[0].Handler.PlatformView).WindowHandle;
        WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

        folderPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
        folderPicker.FileTypeFilter.Add("*");

        // Abre el picker
        var folder = await folderPicker.PickSingleFolderAsync();
        if (folder != null)
        {
            string selectedFolderPath = folder.Path;
            string newFolderPath = Path.Combine(selectedFolderPath, "Casita de Molly");

            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }

            await GuardarRutaEnBD(newFolderPath);

            //labelRutaTickets.Text = newFolderPath;
            await DisplayAlert("Éxito", "La ruta ha sido actualizada.", "OK");

        }
        else
        {
            await DisplayAlert("Error", "No se seleccionó ninguna carpeta", "OK");
        }


    }


    private async Task GuardarRutaEnBD(string ruta)
    {
        try
        {
            rutaConfig.ConfigStringValue = ruta;
            EN_Response<EN_Configuracion> response = await RN_Configuracion.updateConfigurationValues(rutaConfig);

            // Actualizar la propiedad global
            //ApplicationProperties.rutaTickets = ruta;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error al actualizar la ruta en la base de datos\nDetalle: " + ex.Message, "OK");
        }
    }



    private void AgregarGafete_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void HabilitarYDesHabilitarGafete_Tapped(object sender, TappedEventArgs e)
    {

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.SuppressFinalize(this);
    }
}