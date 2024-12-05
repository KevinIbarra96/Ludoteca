using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ServicioPopup
{
    UpdateServiciosTable _UpdateServiciosTable;
    List<EN_TipoServicio> tiposServicioList;


    //Constructor destinado para actualizar la informacion del producto
    public ServicioPopup(EN_Servicio servicio, UpdateServiciosTable updateServiciosTable)
    {
        InitializeComponent();
        getTipoServicio(GlobalEnum.Action.ACTUALIZAR, servicio.IdTipoServicio);

        //Llenar el formulario
        IdServicioEntry.Text = servicio.id.ToString();
        ServicioNamelbl.Text = servicio.ServicioName;
        ServicioNameEntry.Text = servicio.ServicioName;
        PrecioServicio.Text = servicio.Precio.ToString();
        DescripcionEditor.Text = servicio.Descripcion;
        ServicioTiempoEntry.Text = servicio.Tiempo.ToString();
        //picker.SelectedItem = tiposServicioList.FirstOrDefault(x => x.id == servicio.IdTipoServicio);

        BtnGuardar.Clicked += BtnGuardarActualizar_Clicked;
        _UpdateServiciosTable = updateServiciosTable;

    }

    //Contructor destinado para la creacion de un nuevo producto
    public ServicioPopup(UpdateServiciosTable updateServiciosTable)
    {
        InitializeComponent();

        BtnGuardar.Clicked += BtnGuardarNuevo_Clicked;

        ServicioNamelbl.Text = "Nuevo Servicio";

        _UpdateServiciosTable = updateServiciosTable;

        getTipoServicio(GlobalEnum.Action.CREAR_NUEVO, 0);
    }

    private async void BtnGuardarActualizar_Clicked(object? sender, EventArgs e)
    {
        try
        {
            var pick = (EN_TipoServicio)picker.SelectedItem;

            var servicio = new EN_Servicio() { id = int.Parse(IdServicioEntry.Text), ServicioName = ServicioNameEntry.Text, Descripcion = DescripcionEditor.Text, Tiempo = int.Parse(ServicioTiempoEntry.Text), Precio = int.Parse(PrecioServicio.Text), IdTipoServicio = pick.id, TipoServicio = pick.Nombre };
            await RN_Servicio.RN_UpdateServicio(servicio);

            //Ejecuta el delegado 
            _UpdateServiciosTable(GlobalEnum.Action.ACTUALIZAR, servicio);

            var toast = Toast.Make("Actualizacion de " + servicio.ServicioName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAllAsync();

        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
        }
    }

    private async void BtnGuardarNuevo_Clicked(object? sender, EventArgs e)
    {
        try
        {
            var pick = (EN_TipoServicio)picker.SelectedItem;
            var servicio = new EN_Servicio() { ServicioName = ServicioNameEntry.Text, Descripcion = DescripcionEditor.Text, Tiempo = int.Parse(ServicioTiempoEntry.Text), Precio = int.Parse(PrecioServicio.Text), IdTipoServicio = pick.id, TipoServicio = pick.Nombre };
            EN_Response<EN_Servicio> resp = await RN_Servicio.RN_AddNewServicio(servicio);

            servicio.id = resp.Rbody.First().id;
            //Ejecuta el delegado para agregar el nuevo servicio
            _UpdateServiciosTable(GlobalEnum.Action.CREAR_NUEVO, servicio);

            var toast = Toast.Make("Se agregó el " + servicio.ServicioName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error en el proceso de guardado\nDetalle: " + ex.Message, "Ok");
        }
        finally
        {
            await MopupService.Instance.PopAllAsync();
        }
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ServicioNameEntry.Focus();
    }
    private async void getTipoServicio(GlobalEnum.Action action, int idTipoServicio)
    {
        EN_Response<EN_TipoServicio> tiposServicioRespon = await RN_TipoServicio.RN_GetAllActiveTipoServicio();
        tiposServicioList = tiposServicioRespon.Rbody;

        picker.ItemsSource = tiposServicioList;
        picker.ItemDisplayBinding = new Binding("Nombre");

        if (GlobalEnum.Action.ACTUALIZAR == action)
            picker.SelectedItem = tiposServicioList.FirstOrDefault(x => x.id == idTipoServicio);

    }
}