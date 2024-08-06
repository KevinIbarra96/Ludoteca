using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ProductoList
{

    AddProductoToVisita _addProductoToVisita;
    int _visitaId;

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

            var prodVisita = ConvertClass.convertEN_ProductosToEN_ProductosVisita(ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList());

            foreach (EN_ProductosVisita prod in prodVisita)
            {
                _addProductoToVisita(prod, _visitaId);               
            }

            EN_Response<EN_Visita> response = await RN_Visita.addProductosToVisita(_visitaId, prodVisita.ToList());

            var toast = Toast.Make(response.Rmessage, CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAsync();

            MopupService.Instance.PopAsync();

        }catch (Exception ex)
        {
            DisplayAlert("Error","Ah ocurrido un error\nDetalle: "+ex.Message,"Ok");
        }
    }

    private async void Productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try 
        {
            DesactivarProductoVisitaEntry();
            //foreach (EN_Producto prod in e.CurrentSelection)
            foreach (EN_Producto prod in ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList())
            {
                if (prod.CantidadVisita == 0 || prod.CantidadVisita == null)
                    prod.CantidadVisita = 1;
                
                prod.IsEnable = true;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "Ok");
        }

    }

    private void EntryCantidadProducto_TextChanged(object sender, TextChangedEventArgs e)
    {

        foreach (EN_Producto prod in ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList())
        {
            int cantidadV = prod.CantidadVisita;
            if (e.NewTextValue == "")
                cantidadV = 0;

        }        
    }

    private void DesactivarProductoVisitaEntry()
    {
        foreach (EN_Producto prod in ProductosCollectionView.ItemsSource)
        {
            prod.IsEnable = false;
        }
    }
}