using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

using Ludoteca.Resources;

namespace Ludoteca.PopUp;

public partial class ProductoPopup
{
    EN_Producto prod;

    UpdateInventarioData _updateInventarioData;

    //Constructor destinado para actualizar la informacion del producto
    public ProductoPopup(EN_Producto _procuto, UpdateInventarioData updateInventarioData)
    {
        InitializeComponent();

        //LLenar los valores de la lista 
        this.prod = _procuto;
        ProductNamelbl.Text = prod.ProductoName;
        IdProductEntry.Text = prod.id.ToString();
        ProductNameEntry.Text = prod.ProductoName;
        PrecioProduct.Text = prod.Precio.ToString();
        ProductCantidadeEntry.Text = prod.Cantidad.ToString();

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
        //Navigation.PopModalAsync();
        this.prod = null;
    }

    private async void GuardarActuzalizar_Clicked(object sender, EventArgs e)
    {
        var producto = new EN_Producto() { id = int.Parse(IdProductEntry.Text), ProductoName = ProductNameEntry.Text, Cantidad = int.Parse(ProductCantidadeEntry.Text), Precio = int.Parse(PrecioProduct.Text) };
        await RN_Producto.RN_UpdateProducto(producto);

        //Excecute the delegate to load the data on inventory
        _updateInventarioData(GlobalEnum.Action.ACTUALIZAR, producto);
        await MopupService.Instance.PopAsync();
    }
    private async void GuardarNuevo_Clicked(object sender, EventArgs e)
    {
        var producto = new EN_Producto() { ProductoName = ProductNameEntry.Text, Precio = int.Parse(PrecioProduct.Text) };
        EN_Response<EN_Producto> resp = await RN_Producto.RN_AddNewProducto(producto);
        
        producto.id = resp.Rbody[0].id;

        //Excecute the delegate to load the data on inventory
        _updateInventarioData(GlobalEnum.Action.CREAR_NUEVO, producto);
        await MopupService.Instance.PopAsync();
    }
}