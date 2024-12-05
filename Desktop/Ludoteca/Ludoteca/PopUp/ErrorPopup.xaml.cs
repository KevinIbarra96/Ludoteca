using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ErrorPopup : Mopups.Pages.PopupPage
{
    private int failConfigId;

    public ErrorPopup(string title, string message, int configId)
    {
        InitializeComponent();

        TitleErrorLabel.Text = title;
        ErrorDetailLabel.Text = message;
        failConfigId = configId;

    }
    private async void BtnOk_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PopAsync();
    }

    // Evento al presionar el botón Intentar de Nuevo
    private async void BtnIntentarDeNuevo_Clicked(object sender, EventArgs e)
    {
        // Lógica para reintentar la operación que causó el error
        try
        {
            // Usar el failConfigId para reintentar la configuración fallida
            await RN_Configuracion.getConfigurationById(failConfigId);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al intentar de nuevo\nDetalle: " + ex.Message, "OK");
        }

    }

    // Evento al presionar el botón Cancelar
    private async void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PopAsync();
    }
}