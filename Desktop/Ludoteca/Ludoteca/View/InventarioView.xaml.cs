using Entidad;
using Negocio;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View;

public partial class InventarioView : ContentPage
{

    int count = 0;

    InventarioViewModel viewModel;

    LoadInventarioData _loadInventarioData;
    UpdateInventarioData _updateInventarioData;

    public InventarioView()
	{
		InitializeComponent();

        viewModel = new InventarioViewModel();
        BindingContext = viewModel;

        _loadInventarioData = viewModel._loadInventarioData;
        _updateInventarioData = viewModel._UpdateInventarioData;

        searchBar.TextChanged += SearchBar_TextChanged;

    }

    private void SearchBar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string searchText = searchBar.Text;

        // Filtrar la ObservableCollection en función del texto de búsqueda
        var filteredProducts = viewModel.ProductInmutable
            .Where(p => p.ProductoName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        viewModel.Productos.Clear();

        foreach (var product in filteredProducts)
        {
            viewModel.Productos.Add(product); // Agregar los productos filtrados de nuevo
        }
    }

    private async void AgregarProducto_Clicked(object sender, EventArgs e)
    {
        int idProducto = 0;
        EN_Response<EN_Producto> resp;

        var button = sender as Button;
        if (button != null && button.CommandParameter is int id)
            idProducto = id;
        try
        {
            string responseEntry = await DisplayPromptAsync("Producto", "Ingresa la cantidad de producto: ", "Igresar", "Cancelar", "Cantidad", 4, Keyboard.Numeric);
            if (responseEntry == "" && responseEntry != null) { await DisplayAlert("Error", "Valor no puede ser vacío", "ok"); return; } //Valir que el valor enviado no se vacío

            if (responseEntry != null)
            {
                resp = await RN_Producto.RN_increaseCantidadProducto(idProducto, int.Parse(responseEntry));

                if (resp.RerrorCode == "0")
                {
                    await DisplayAlert("Mensaje", resp.Rmessage, "ok");
                    _loadInventarioData(); //Excecute the delegate to load data to the inventory
                }
                else
                    await DisplayAlert("Mensaje", resp.Rmessage, "ok");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "ok");
        }
    }

    private async void EditarProducto_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await MopupService.Instance.PushAsync(new PopUp.ProductoPopup((EN_Producto) btn.CommandParameter,_updateInventarioData ));
    }

    private async void Ingresar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.ProductoPopup(_updateInventarioData));

        
        EN_Producto pro = new EN_Producto() { id = 21 , ProductoName="Prueba",Cantidad = 12,Precio = 12 };

    }
}