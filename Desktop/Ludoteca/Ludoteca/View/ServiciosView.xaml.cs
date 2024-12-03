using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View;

public partial class ServiciosView : ContentPage
{
    int count = 0;

    ServiciosViewModel viewModel;

    LoadServiciosTable _loadServiciosTable;
    UpdateServiciosTable _UpdateServiciosTable;

    public ServiciosView()
    {
        InitializeComponent();

        viewModel = new ServiciosViewModel();
        BindingContext = viewModel;

        _loadServiciosTable = viewModel._loadServiciosTable;
        _UpdateServiciosTable = viewModel._UpdateServiciosTable;

        searchBar.TextChanged += SearchBar_TextChanged;
    }

    private void SearchBar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string searchText = searchBar.Text;

        // Filtrar la ObservableCollection en función del texto de búsqueda
        var filteredProducts = viewModel.SsrviciosInmutble
            .Where(p => p.ServicioName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        viewModel.servicios.Clear();

        foreach (var product in filteredProducts)
        {
            viewModel.servicios.Add(product); // Agregar los productos filtrados de nuevo
        }
    }

    private async void EditarServicios_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await MopupService.Instance.PushAsync(new PopUp.ServicioPopup((EN_Servicio)btn.CommandParameter, _UpdateServiciosTable));
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.ServicioPopup(_UpdateServiciosTable));
    }
}