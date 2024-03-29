using Entidad;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ServicioList
{
	public ServicioList()
	{
		InitializeComponent();


        getAllServicios();
    }


    private async void getAllServicios()
    {
        try
        {
            List<EN_Servicio> Serv = await RN_Servicio.RN_GetAllServicios();
            ServicioCollectionView.ItemsSource = await RN_Servicio.RN_GetAllServicios();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}