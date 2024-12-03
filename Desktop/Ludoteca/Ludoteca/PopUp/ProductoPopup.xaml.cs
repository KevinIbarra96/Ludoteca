using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class ProductoPopup
{

    UpdateInventarioData _updateInventarioData;

    //Constructor destinado para actualizar la informacion del producto
    public ProductoPopup(EN_Producto _procuto, UpdateInventarioData updateInventarioData)
    {
        InitializeComponent();

        //LLenar los valores de la lista
        ProductNamelbl.Text = _procuto.ProductoName;
        IdProductEntry.Text = _procuto.id.ToString();
        ProductNameEntry.Text = _procuto.ProductoName;
        PrecioProduct.Text = _procuto.Precio.ToString();
        ProductCantidadeEntry.Text = _procuto.Cantidad.ToString();

        BtnGuardar.Clicked += GuardarActuzalizar_Clicked;//Agregar el eevnto al boton

        _updateInventarioData = updateInventarioData;//Inizialzacion del delegado
    }

    //Contructor destinado para la creacion de un nuevo producto
    public ProductoPopup(UpdateInventarioData updateInventarioData)
    {
        InitializeComponent();
        _updateInventarioData = updateInventarioData; //Inizialzacion del delegado

        //Agregar Valor a la vista
        ProductNamelbl.Text = "Nuevo Producto";

        BtnGuardar.Clicked += GuardarNuevo_Clicked;//Agregar el evento correspondiente al boton
    }
    protected override void OnAppearing()
    {
        ProductNameEntry.Focus();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private async void GuardarActuzalizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var producto = new EN_Producto() { id = int.Parse(IdProductEntry.Text), ProductoName = ProductNameEntry.Text, Cantidad = int.Parse(ProductCantidadeEntry.Text), Precio = int.Parse(PrecioProduct.Text) };
            await RN_Producto.RN_UpdateProducto(producto);

            //Excecute the delegate to load the data on inventory
            _updateInventarioData(GlobalEnum.Action.ACTUALIZAR, producto);

            var toast = Toast.Make("Actualizacion de " + producto.ProductoName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAsync();
        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "OK");
        }
        finally
        {

        }
    }
    private async void GuardarNuevo_Clicked(object sender, EventArgs e)
    {
        try
        {
            var producto = new EN_Producto() { ProductoName = ProductNameEntry.Text, Precio = int.Parse(PrecioProduct.Text) };
            EN_Response<EN_Producto> resp = await RN_Producto.RN_AddNewProducto(producto);

            producto.id = resp.Rbody.First().id;

            //Excecute the delegate to load the data on inventory
            _updateInventarioData(GlobalEnum.Action.CREAR_NUEVO, producto);

            var toast = Toast.Make("Se agregó el " + producto.ProductoName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al agregar un nuevo producto\nDetalle: " + ex.Message, "OK");
        }
        finally
        {
            await MopupService.Instance.PopAsync();
        }
    }
}