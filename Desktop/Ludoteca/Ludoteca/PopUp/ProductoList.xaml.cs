using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ProductoList
{

    AddProductoToVisita _addProductoToVisita;
    int _visitaId;
    EN_ProductosVisita _producto = new EN_ProductosVisita();

	public ProductoList(AddProductoToVisita addProductoToVisita,int visitaId)
	{
		InitializeComponent();

        getAllProductos();

        _addProductoToVisita = addProductoToVisita;
        _visitaId = visitaId;
    }

    private async void getAllProductos()
    {
        try
        {
            List<EN_Producto> prod = await RN_Producto.RN_GetAllProductos();
            ProductosCollectionView.ItemsSource = await RN_Producto.RN_GetAllProductos();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            _addProductoToVisita(_producto, _visitaId);

        }catch (Exception ex)
        {
            await DisplayAlert("Error","Ah ocurrido un error\nDetalle: "+ex.Message,"Ok");
        }
    }

    private async void Productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try 
        { 
            foreach (EN_Producto prod in e.CurrentSelection)
            {

                _producto.id_Producto = prod.id;
                _producto.ProductoName = prod.ProductoName;
                _producto.precioProductoVisita = prod.Precio;
                _producto.CantidadProductoVisita = 1;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "Ok");
        }

    }
}