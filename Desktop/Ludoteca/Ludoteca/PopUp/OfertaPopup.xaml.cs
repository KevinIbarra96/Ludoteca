using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class OfertaPopup
{

    UpdateOfertasTable _UpdateOfertaTable;

    public OfertaPopup(UpdateOfertasTable updateOfertasTable)
    {
        InitializeComponent();

        OfertaNamelbl.Text = "Nueva Oferta";

        _UpdateOfertaTable = updateOfertasTable;

        BtnGuardar.Clicked += BtnGuardarNuevo_Clicked;
    }

    public OfertaPopup(UpdateOfertasTable updateOfertasTable, EN_Oferta oferta)
    {
        InitializeComponent();

        OfertaNamelbl.Text = oferta.OfertaName;
        IdOfertaEntry.Text = oferta.id.ToString();
        OfertaNameEntry.Text = oferta.OfertaName;
        DescripcionEditor.Text = oferta.Descripcion;
        PrecioOferta.Text = oferta.totalDescuento.ToString();
        OfertaTiempoEntry.Text = oferta.Tiempo.ToString();

        _UpdateOfertaTable = updateOfertasTable;
        BtnGuardar.Clicked += BtnGuardarActualizar_Clicked;
    }



    public OfertaPopup()
    {
        InitializeComponent();
    }

    private async void BtnGuardarNuevo_Clicked(object? sender, EventArgs e)
    {
        try
        {
            var oferta = new EN_Oferta()
            {
                OfertaName = OfertaNameEntry.Text,
                Descripcion = DescripcionEditor.Text,
                Tiempo = int.Parse(OfertaTiempoEntry.Text),
                totalDescuento = double.Parse(PrecioOferta.Text)
            };

            EN_Response<EN_Oferta> resp = await RN_Oferta.RN_AddNewOferta(oferta);

            oferta.id = resp.Rbody.First().id;

            _UpdateOfertaTable(GlobalEnum.Action.CREAR_NUEVO, oferta);

            var toast = Toast.Make("Se agregó el " + oferta.OfertaName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAllAsync();

        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error en el proceso de guardado\nDetalle: " + ex.Message, "Ok");
        }
    }

    private async void BtnGuardarActualizar_Clicked(object? sender, EventArgs e)
    {
        try
        {
            var oferta = new EN_Oferta()
            {
                id = int.Parse(IdOfertaEntry.Text),
                OfertaName = OfertaNameEntry.Text,
                Descripcion = DescripcionEditor.Text,
                Tiempo = int.Parse(OfertaTiempoEntry.Text),
                totalDescuento = double.Parse(PrecioOferta.Text)
            };
            await RN_Oferta.RN_UpdateOferta(oferta);

            //Ejecuta el delegado 
            _UpdateOfertaTable(GlobalEnum.Action.ACTUALIZAR, oferta);

            var toast = Toast.Make("Actualizacion de " + oferta.OfertaName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
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
}