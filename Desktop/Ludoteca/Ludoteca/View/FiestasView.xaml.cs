using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;
using System.Diagnostics;

namespace Ludoteca.View;

public partial class FiestasView : ContentPage
{
    FiestaViewModel viewModel;

    UpdateFiestasTable _updateFiestasTable;
    LoadFiestasTable _loadFiestasTable;

    public FiestasView()
    {
        viewModel = new FiestaViewModel();
        BindingContext = viewModel;

        _updateFiestasTable = viewModel._UpdateFiestasTable;
        _loadFiestasTable = viewModel._loadFiestasTable;

        InitializeComponent();
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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _loadFiestasTable();

        UpdateListView();

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.SuppressFinalize(this);

    }

}