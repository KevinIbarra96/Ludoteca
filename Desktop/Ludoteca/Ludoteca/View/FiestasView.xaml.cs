using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;
using System.Diagnostics;

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

        UpdateListView();
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.FiestasPopup(_updateFiestasTable));
        Debug.WriteLine($"BindingContext actual: {BindingContext?.GetType().Name}");
    }

    private void UpdateListView()
    {
        FiestasListView.ItemsSource = null;
        FiestasListView.ItemsSource = viewModel.fiestas;
    }

    private async void Edicion_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        await MopupService.Instance.PushAsync(new PopUp.FiestasPopup(_updateFiestasTable, (EN_Fiesta)button.CommandParameter));

    }
}