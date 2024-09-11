using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;
using Ludoteca.Resources;
using CommunityToolkit.Maui.Alerts;

namespace Ludoteca.PopUp;

public partial class ServicioList
{
    public AddServicioToVisita _addServicioToVisita;
    public int _visitaId;

	public ServicioList(AddServicioToVisita addServicioToVisita,int visitaId)
	{
		InitializeComponent();
        _addServicioToVisita = addServicioToVisita;
        _visitaId = visitaId;

        getAllServicios();
    }


    private async void getAllServicios()
    {
        try
        {
            EN_Response<EN_Servicio> Serv = await RN_Servicio.RN_GetallServiciosByTipoServicio(1);
            ServicioCollectionView.ItemsSource = Serv.Rbody;
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

    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        string mensaje = "";

        try
        {
            if ((EN_Servicio)ServicioCollectionView.SelectedItem != null)
            {
                EN_ServiciosVisita serv = ConvertClass.convertEN_ServicionToEN_ServicioVisita((EN_Servicio)ServicioCollectionView.SelectedItem).FirstOrDefault();
                List<EN_ServiciosVisita> servList = new List<EN_ServiciosVisita>();
                servList.Add(serv);

                _addServicioToVisita(serv, _visitaId);
                EN_Response<EN_Visita> response = await RN_Visita.addServicioToVisita(_visitaId, servList);

                var toast = Toast.Make(response.Rmessage, CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
                await toast.Show();

                await MopupService.Instance.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Por favor selecciona el servicio a agregar", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}