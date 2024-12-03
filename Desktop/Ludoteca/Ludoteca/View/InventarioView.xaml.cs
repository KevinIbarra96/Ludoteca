using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;
using Resources.Properties;

namespace Ludoteca.View;

public partial class InventarioView : ContentPage
{

    int count = 0;

    InventarioViewModel viewModel;

    UpdateInventarioData _updateInventarioData;

    public InventarioView()
    {
        InitializeComponent();

        viewModel = new InventarioViewModel();
        BindingContext = viewModel;

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

    private async void IngresarProducto_Clicked(object sender, EventArgs e)
    {
        EN_Response<EN_Producto> resp;

        try
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter is EN_Producto producto)
            {

                string responseEntry = await DisplayPromptAsync("Producto", "Ingresa la cantidad de producto: ", "Igresar", "Cancelar", "Cantidad", 4, Keyboard.Numeric);
                if (responseEntry == "" && responseEntry != null) { await DisplayAlert("Error", "Valor no puede ser vacío", "ok"); return; } //Validar que el valor enviado no se vacío

                if (responseEntry != null)
                {
                    resp = await RN_Producto.RN_increaseCantidadProducto(producto.id, int.Parse(responseEntry));


                    if (resp.RerrorCode == "0") //0 significa que no hubo ningun error, 0 es el valor por defaul que se recibe de la WebAPi
                    {

                        //Increase Cantidad property with Entry Value
                        producto.Cantidad += int.Parse(responseEntry);

                        _updateInventarioData(GlobalEnum.Action.ACTUALIZAR, producto);

                        var toast = Toast.Make("Se agregaron " + responseEntry + " " + producto.ProductoName, CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
                        await toast.Show();
                    }
                    else
                        await DisplayAlert("Mensaje", resp.Rmessage, "ok");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "ok");
        }
    }

    private async void EditarProducto_Clicked(object sender, EventArgs e)
    {
        if (Session.RolId != ApplicationProperties.IdAdministratorRol)
            return;

        var btn = sender as Button;
        await MopupService.Instance.PushAsync(new PopUp.ProductoPopup((EN_Producto)btn.CommandParameter, _updateInventarioData));
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.ProductoPopup(_updateInventarioData));
    }
}