using Mopups.Services;
using Ludoteca.ViewModel;
using Entidad;
using Negocio;
using Ludoteca.Resources;
using CommunityToolkit.Maui.Alerts;

namespace Ludoteca.PopUp;

public partial class ServicioPopup 
{    
    UpdateServiciosTable _UpdateServiciosTable;

    //Constructor destinado para actualizar la informacion del producto
    public ServicioPopup(EN_Servicio servicio,UpdateServiciosTable updateServiciosTable)
	{
		InitializeComponent();

        //Llenar el formulario
        IdServicioEntry.Text = servicio.id.ToString();
        ServicioNamelbl.Text = servicio.ServicioName;
        ServicioNameEntry.Text = servicio.ServicioName;
        PrecioServicio.Text = servicio.Precio.ToString();
        DescripcionEditor.Text = servicio.Descripcion;        
        ServicioTiempoEntry.Text = servicio.Tiempo.ToString();

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
    }

    private async void BtnGuardarActualizar_Clicked(object? sender, EventArgs e)
    {
        try
        {
            var servicio = new EN_Servicio() {id=int.Parse(IdServicioEntry.Text),ServicioName=ServicioNameEntry.Text,Descripcion = DescripcionEditor.Text,Tiempo = int.Parse(ServicioTiempoEntry.Text),Precio = int.Parse(PrecioServicio.Text) };
            await RN_Servicio.RN_UpdateServicio(servicio);

            //Ejecuta el delegado 
            _UpdateServiciosTable(GlobalEnum.Action.ACTUALIZAR,servicio);

            var toast = Toast.Make("Actualizacion de " + servicio.ServicioName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: "+ex.Message, "Ok");
        }
        finally
        {
           await MopupService.Instance.PopAllAsync();
        }
    }

    private async void BtnGuardarNuevo_Clicked(object? sender, EventArgs e)
    {
        try
        {
            var servicio = new EN_Servicio() { ServicioName = ServicioNameEntry.Text, Descripcion = DescripcionEditor.Text, Tiempo = int.Parse(ServicioTiempoEntry.Text), Precio = int.Parse(PrecioServicio.Text) };
            await RN_Servicio.RN_AddNewServicio(servicio);

            //Ejecuta el delegado para agregar el nuevo servicio
            _UpdateServiciosTable(GlobalEnum.Action.CREAR_NUEVO,servicio);

            var toast = Toast.Make("Se agregó el " + servicio.ServicioName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

        }
        catch(Exception ex)
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
}