using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View;

public partial class OfertasView : ContentPage
{

    UpdateOfertasTable _UpdateOfertaTable;

    OfertaViewModel viewModel;

    public OfertasView()
    {
        InitializeComponent();

        viewModel = new OfertaViewModel();
        BindingContext = viewModel;

        _UpdateOfertaTable = viewModel._UpdateOfertasTable;
    }

    private async void EditarOferta_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await MopupService.Instance.PushAsync(new PopUp.OfertaPopup(_UpdateOfertaTable, (EN_Oferta)btn.CommandParameter));
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.OfertaPopup(_UpdateOfertaTable));
    }
}