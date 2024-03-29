using Entidad;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ProductoList
{
	public ProductoList()
	{
		InitializeComponent();

        getAllProductos();
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
}