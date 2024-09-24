using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View;

public partial class OfertasView : ContentPage
{

    UpdateOfertasTable _UpdateOfertaTable;

    public OfertasView()
	{
		InitializeComponent();
	}

    private void EditarOferta_Clicked(object sender, EventArgs e)
    {

    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.OfertaPopup(_UpdateOfertaTable));
    }
}