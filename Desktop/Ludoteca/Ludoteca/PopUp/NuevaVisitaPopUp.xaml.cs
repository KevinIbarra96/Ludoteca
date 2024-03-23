namespace Ludoteca.PopUp;

using Entidad;
using Negocio;
using Ludoteca.ViewModel;
using System.Collections.ObjectModel;

public partial class NuevaVisitaPopUp
{

	UpdateVisitasTable _updateVisitasTable;

    ObservableCollection<EN_Hijo> Hijos;

    int _totalProducto = 0;
    int _totalServicio = 0;

    EN_Padre padre;


    public NuevaVisitaPopUp(UpdateVisitasTable updateVisitasTable)
	{
		InitializeComponent();

        Hijos = new ObservableCollection<EN_Hijo>();
        
        getAllProductos();
        getAllServicios();

        calcularTotal();



        _updateVisitasTable = updateVisitasTable;
	}

    private void Hijos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       // Cambiar el color de fondo del elemento seleccionado
            foreach (EN_Hijo hijo in e.PreviousSelection)
            {
                hijo.SelectedBackgroundColor = "White";
            }

            foreach (EN_Hijo hijo in e.CurrentSelection)
            {
                hijo.SelectedBackgroundColor = "LightSkyBlue";
            }
    }

    private void calcularTotal() {
        TotalVisita.Text = "";
        TotalVisita.Text = "<strong style=\"color:red\"> Total: </strong>" + (_totalProducto + _totalServicio) + "$";
    }

    #region Events

    private async void Ingresar_Clicked(object sender, EventArgs e)
    {
        List<EN_Padre> lisPadre = new List<EN_Padre>();
        lisPadre.Add(padre);
        try
        {

            EN_Visita nuevaVisita = new EN_Visita();
            nuevaVisita.Total = (_totalProducto + _totalServicio);
            nuevaVisita.HoraEntrada = new DateTime();
            nuevaVisita.Oferta = 1;
            nuevaVisita.Hijos = (List<EN_Hijo>)HijosCollectionView.ItemsSource;
            nuevaVisita.Padres = lisPadre;
            nuevaVisita.Servicios = convertEN_ServicionToEN_ServicioVisita( (List<EN_Servicio>)ServicioCollectionView.ItemsSource);
            nuevaVisita.Productos = convertEN_ProductosToEN_ProductosVisita((List<EN_Producto>)ProductosCollectionView.ItemsSource);
            await RN_Visita.ingresarNuevaVisita(nuevaVisita);
        }catch(InvalidCastException invalidCastException)
        {
            await DisplayAlert("Error", "Por favor verifica que todos los datos esten correctos", "OK");
        }catch (Exception ex)
        {
            await DisplayAlert("Error","Ah ocurrido un error\nDetalle: "+ex.Message,"OK");
        }
    }

    private void BuscarHijos_Clicked(object sender, EventArgs e)
    {
        getPadresEHijos(NumTelefonoEntry.Text);
    }

    private void Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _totalProducto = 0;
        foreach (EN_Producto prod in e.CurrentSelection)
        {
            _totalProducto += prod.Precio;
        }
        calcularTotal();
    }

    private void Servicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _totalServicio = 0;
        foreach (EN_Servicio serv in e.CurrentSelection)
        {
            _totalServicio += serv.Precio;
        }
        calcularTotal();
    }
    #endregion

#region GetData
    private async void getPadresEHijos(string _phone)
    {
        try
        {
            padre = await RN_Padre.getPadreByPhone(_phone);
            List<EN_Hijo> hijo = await RN_Hijo.getHijosByPadresId(padre.id);
            Padrelabl.Text = padre.PadreName;
            HijosCollectionView.ItemsSource = hijo;
        }catch (Exception ex)
        {
            Padrelabl.Text = "";
            HijosCollectionView.ItemsSource = new List<EN_Hijo>();
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message,"OK");
        }
    }

    private async void getAllProductos()
    {
        try { 
            List<EN_Producto> prod= await RN_Producto.RN_GetAllProductos();
            ProductosCollectionView.ItemsSource = await RN_Producto.RN_GetAllProductos();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
    private async void getAllServicios()
    {
        try { 
            List<EN_Servicio> Serv = await RN_Servicio.RN_GetAllServicios();
            ServicioCollectionView.ItemsSource = await RN_Servicio.RN_GetAllServicios();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
    #endregion

    #region ConvertData
    private List<EN_ServiciosVisita> convertEN_ServicionToEN_ServicioVisita(List<EN_Servicio> servicio)
    {
        List<EN_ServiciosVisita> servicioVisita = new List<EN_ServiciosVisita>();

        foreach (EN_Servicio s in servicio)
        {
            EN_ServiciosVisita serv = new EN_ServiciosVisita();
            serv.Servicio_Id = s.id;
            serv.ServicioName = s.ServicioName;
            serv.Servicio_Precio = s.Precio;
            serv.Tiempo = s.Tiempo;
        }

        return servicioVisita;
    }

    private List<EN_ProductosVisita> convertEN_ProductosToEN_ProductosVisita(List<EN_Producto> produ)
    {
        List<EN_ProductosVisita> productosVisitas = new List<EN_ProductosVisita>();
        foreach (EN_Producto p in produ)
        {
            EN_ProductosVisita pro = new EN_ProductosVisita();
            pro.id_Producto = p.id;
            pro.ProductoName = p.ProductoName;
            pro.precioProductoVisita = p.Precio;
            pro.CantidadProductoVisita = p.Cantidad;
            productosVisitas.Add(pro);
        }

        return productosVisitas;
    }
    #endregion

}