using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class NuevaVentaPoup
{

    double _Total = 0,_TotalProducto =0 ;
    bool _PrimerProductoSelec = true;

    UpdateVentasTable _updateVentasTable;

    private TicketPrinter ticket;

    public NuevaVentaPoup(UpdateVentasTable updateVentasTable)
	{
		InitializeComponent();

        _updateVentasTable = updateVentasTable;

        getAllProductos();

        calcularTotal();
      
    }

    private async void getAllProductos()
    {
        try
        {
            List<EN_Producto> prod = await RN_Producto.RN_GetAllActiveProductos();
            ProductosCollectionView.ItemsSource = await RN_Producto.RN_GetAllActiveProductos();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            EN_Ventas nuevaVenta = new EN_Ventas();
            nuevaVenta.Total = _Total;
            nuevaVenta.Fecha = DateTime.Now;
            nuevaVenta.Productos = ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList();

            var ventaResponse = await RN_Ventas.addNewProducto(nuevaVenta);

            if (ventaResponse.Rcode != 200)
                throw new Exception(ventaResponse.Rmessage);

            nuevaVenta.id = ventaResponse.Rbody.First().id;

            _updateVentasTable(GlobalEnum.Action.CREAR_NUEVO,nuevaVenta);

            await ImprimirTicket(nuevaVenta);

            await MopupService.Instance.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "Ok");
        }


    }

    private async Task ImprimirTicket(EN_Ventas venta)
    {

        ticket = new TicketPrinter(venta);
        string action = await Application.Current.MainPage.DisplayActionSheet("Selecciona una impresora ", "No Imprimir", null, ticket.ListPrinters());

        if (action == "No Imprimir")
        {
            //await DisplayAlert("Atencion", "No se seleccionó ninguna impresora, se cancelará el proceso", "OK");
            //throw new Exception("No se seleccionó ninguna impresora, se cancelará el proceso");
            //await DisplayAlert("Atencion", "No se seleccionó ninguna impresora, se cancelará el proceso de cobro", "OK");
            bool answer = await Application.Current.MainPage.DisplayAlert("Atencion", "¿Seguro que no quieres imprimir?", "Si", "No");
            if (!answer)
            {
                string action2 = await Application.Current.MainPage.DisplayActionSheet("Selecciona una impresora ", "Cancelar", null, ticket.ListPrinters());
                if (action2 != "Cancelar")
                {
                    await ticket.PrintTicket(action2);
                    bool answer1 = await DisplayAlert("Atencion", "¿Quieres imprimir otro ticket?", "Si", "No");
                    if (answer1)
                        await ticket.PrintTicket(action2);
                }
            }
        }
        else
        {
            await ticket.PrintTicket(action);

            bool answer = await DisplayAlert("Atencion", "¿Quieres imprimir otro ticket?", "Si", "No");
            if (answer)
                await ticket.PrintTicket(action);
        }

    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }


    private async void Productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            DesactivarProductoVisitaEntry();
            _TotalProducto = 0;
            foreach (EN_Producto prod in ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList())
            {
                if (prod.CantidadVisita == 0 || prod.CantidadVisita == null)
                {
                    prod.CantidadVisita = 1; _PrimerProductoSelec = false;
                }
                else
                    _PrimerProductoSelec = true;

                if (_PrimerProductoSelec)
                {
                    double total = prod.Precio * prod.CantidadVisita;
                    _TotalProducto += Math.Round(total, 2);
                }

                prod.IsEnable = true;
            }
            calcularTotal();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "Ok");
        }
    }

    private void EntryCantidadProducto_TextChanged(object sender, TextChangedEventArgs e)
    {
        _TotalProducto = 0;
        foreach (EN_Producto prod in ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList())
        {
            int cantidadV = prod.CantidadVisita;
            if (e.NewTextValue == "")
                cantidadV = 0;

            double total = prod.Precio * cantidadV;
            _TotalProducto += Math.Round(total, 2);
        }
        calcularTotal();
    }

    private void DesactivarProductoVisitaEntry()
    {
        foreach (EN_Producto prod in ProductosCollectionView.ItemsSource)
        {
            prod.IsEnable = false;
        }
    }

    private void calcularTotal()
    {
        _Total = 0;
        _Total = _TotalProducto;

        TotalFiesta.Text = "";
        TotalFiesta.Text = "<strong style=\"color:red\"> Total: </strong>" + _Total + "$";
    }

}