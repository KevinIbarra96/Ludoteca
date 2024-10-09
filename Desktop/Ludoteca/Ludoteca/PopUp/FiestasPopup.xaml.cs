namespace Ludoteca.PopUp;

using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;
using Ludoteca.Resources;
using static Microsoft.Maui.ApplicationModel.Permissions;

public partial class FiestasPopup
{

	UpdateFiestasTable _updateFiestaTable;

    EN_Padre padre;
    EN_Servicio _Servicio;
    List<DateTime> FechasProgramadas;

    bool isResetting = false;

    public FiestasPopup(UpdateFiestasTable updateFiestasTable)
	{
		InitializeComponent();

		_updateFiestaTable = updateFiestasTable;
        
        calcularTotal();
        GetServiciosFiestas();
        GetFiestasProgramadas();        

    }

    private async void GetFiestasProgramadas()
    {
        try 
        { 
            var Response = await RN_Fiesta.RN_FechasProgramadas();
            FechasProgramadas = Response.Rbody;
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
            MopupService.Instance.PopAsync();
        }
    }

    private void BuscarHijos_Clicked(object sender, EventArgs e)
    {
        getPadresEHijos(NumTelefonoEntry.Text);
    }

    private async void GetServiciosFiestas()
    {
        try { 
        EN_Response<EN_Servicio> responseServicio = await RN_Servicio.RN_GetallServiciosByTipoServicio(2);
        ServiciosPicker.ItemsSource = responseServicio.Rbody;
        ServiciosPicker.ItemDisplayBinding = new Binding("ServicioName");
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
            MopupService.Instance.PopAsync();
        }
    }

    private void calcularTotal()
    {
        TotalFiesta.Text = "";
        TotalFiesta.Text = "<strong style=\"color:red\"> Total: </strong>"+ 152+ "$";
    }

    private void Hijos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (EN_Hijo hijo in e.PreviousSelection)
        {
            hijo.SelectedBackgroundColor = "White";
        }

        foreach (EN_Hijo hijo in e.CurrentSelection)
        {
            hijo.SelectedBackgroundColor = "LightSkyBlue";
        }
    }

    private async void getPadresEHijos(string _phone)
    {
        try
        {
            padre = await RN_Padre.getPadreByPhone(_phone);
            List<EN_Hijo> hijo = await RN_Hijo.getHijosByPadresId(padre.id);
            Padrelabl.Text = padre.PadreName;
            HijosCollectionView.ItemsSource = hijo;
        }
        catch (Exception ex)
        {
            Padrelabl.Text = "";
            HijosCollectionView.ItemsSource = new List<EN_Hijo>();
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private void ServiciosPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var pick = (Picker)sender;
        EN_Servicio serv = (EN_Servicio)pick.SelectedItem;
        _Servicio = serv;
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {

        EN_Hijo hijo = (EN_Hijo)HijosCollectionView.SelectedItem;

        try
        {
            EN_Fiesta nuevaFiesta = new EN_Fiesta();
            nuevaFiesta.Fecha = FechaFiesta.Date;
            nuevaFiesta.IdServicio = _Servicio.id;
            nuevaFiesta.IdHijo = hijo.id;
            nuevaFiesta.Anticipo = double.Parse(AnticipoEntry.Text);
            nuevaFiesta.Total = 10.00;

            RN_Fiesta.RN_AddNewFiesta(nuevaFiesta);

            _updateFiestaTable(GlobalEnum.Action.CREAR_NUEVO, nuevaFiesta);

            var toast = Toast.Make("Nueva fiesta programada correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAsync();

        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }

    }

    private async void FechaFiesta_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (isResetting)
            return;

        if (FechasProgramadas.Contains(e.NewDate.Date))
        {
            isResetting = true;

            await DisplayAlert("Alerta", "Ya hay una fiesta programada en esta fecha", "OK");

            ((DatePicker)sender).Date = e.OldDate;

            isResetting = false;
        }
            
    }
}