namespace Ludoteca.View;


using Ludoteca.ViewModel;
using Mopups.Services;
using System.ComponentModel;

public partial class VisitView : ContentPage
{

    VisitViewModel viewModel;

    UpdateVisitasTable _updateVisitasTable;

    public VisitView()
	{
		InitializeComponent();

        viewModel = new VisitViewModel();
        BindingContext = viewModel;

        _updateVisitasTable = viewModel._UpdateVisitasTable;

        searchBar.TextChanged += SearchBar_TextChanged;

    }

    private void SearchBar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string searchText = searchBar.Text;

        // Filtrar la ObservableCollection en función del texto de búsqueda
        var filteredProducts = viewModel.VisitasInmutable
            .Where(visita => visita.Hijos != null &&
                             visita.Hijos.Any(hijo =>
                             hijo.NombreHijo.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                             
                             visita.Padres != null &&
                             visita.Padres.Any(padre =>
                             padre.PadreName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                ).ToList();

        viewModel.Visitas.Clear();

        foreach (var product in filteredProducts)
        {
            viewModel.Visitas.Add(product); // Agregar los productos filtrados de nuevo
        }
    }    
    private async void NuevaVisita_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.NuevaVisitaPopUp(_updateVisitasTable));
    }
}