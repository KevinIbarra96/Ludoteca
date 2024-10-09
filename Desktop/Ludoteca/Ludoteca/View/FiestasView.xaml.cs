using Entidad;
using Ludoteca.PopUp;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View;

public partial class FiestasView : ContentPage
{
    FiestaViewModel viewModel;

    UpdateFiestasTable _updateFiestasTable;

    public FiestasView()
	{
        viewModel = new FiestaViewModel();
        BindingContext = viewModel;

        _updateFiestasTable = viewModel._UpdateFiestasTable;

        InitializeComponent();
	}

    private void Agregar_Clicked(object sender, EventArgs e)
    {
		MopupService.Instance.PushAsync(new PopUp.FiestasPopup(_updateFiestasTable) );
    }
}