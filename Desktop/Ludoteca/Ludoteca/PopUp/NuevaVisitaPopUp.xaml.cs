namespace Ludoteca.PopUp;

using Entidad;
using Negocio;
using Ludoteca.ViewModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using Mopups.Services;
using Ludoteca.Resources;
using global::Resources.Properties;

public partial class NuevaVisitaPopUp
{

	UpdateVisitasTable _updateVisitasTable;
    CalcularTotalVisita _calcularTotalVisitas;

    ObservableCollection<EN_Hijo> Hijos;

    double _totalProducto = 0;
    double _totalServicio = 0;

    EN_Gafete _Gafete;

    EN_Padre padre;

    public NuevaVisitaPopUp(UpdateVisitasTable updateVisitasTable,CalcularTotalVisita calcularTotalVisita)
	{
		InitializeComponent();

        Hijos = new ObservableCollection<EN_Hijo>();
        
        getAllProductos();
        getAllServicios();

        calcularTotal();
        asignarGafete("Sin asignacion");

        _updateVisitasTable = updateVisitasTable;
        _calcularTotalVisitas = calcularTotalVisita;
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

    private void asignarGafete(string _gafete)
    {
        Gafete.Text = "";
        Gafete.Text = "<strong style=\"color:red\"> Gafete: </strong>"+_gafete;
    }

    #region Events

    private async void AsignarGafete_Clicked(object sender, EventArgs e)
    {
        EN_Response<EN_Gafete> responseGafete = await RN_Gafete.getGafeteNoAsignado();
        string[] Actions = new string[responseGafete.Rbody.Count];
        int count = 0;

        foreach (EN_Gafete gafete in responseGafete.Rbody)
        {
            
            Actions[count] = gafete.Numero.ToString();
            count = count+ 1;
        }

        //string action = await DisplayActionSheet("Selecciona el Gafete", "Cancel", null, Actions);
        string action = await Shell.Current.DisplayActionSheet("Selecciona el Gafete", "Cancel", null, Actions);
        asignarGafete(action);        
        _Gafete = responseGafete.Rbody.Single( s=> s.Numero == int.Parse(action) );
    }

    private async void Ingresar_Clicked(object sender, EventArgs e)
    {
        List<EN_Padre> lisPadre = new List<EN_Padre>();
        lisPadre.Add(padre);
        try
        {
            EN_Visita nuevaVisita = new EN_Visita();
            nuevaVisita.Total = (_totalProducto + _totalServicio);
            nuevaVisita.Oferta = 1;
            nuevaVisita.GafeteId = _Gafete.id;
            nuevaVisita.NumeroGafete = _Gafete.Numero;
            nuevaVisita.Hijos = HijosCollectionView.SelectedItems.OfType<EN_Hijo>().ToList();
            nuevaVisita.Padres = lisPadre;
            nuevaVisita.Servicios = convertEN_ServicionToEN_ServicioVisita( (EN_Servicio) ServicioCollectionView.SelectedItem);
            nuevaVisita.Productos = convertEN_ProductosToEN_ProductosVisita(ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList());            

            EN_Response<EN_Visita> response = await RN_Visita.ingresarNuevaVisita(nuevaVisita);
            nuevaVisita.id = response.Rbody[0].id;
            nuevaVisita.HoraEntrada = response.Rbody[0].HoraEntrada;
            nuevaVisita.OfertaName = "Sin Oferta"; //Por definir que sigue en este caso
            nuevaVisita.Timer = new Timer(TimerCallback, nuevaVisita, 0, 20000);

            _updateVisitasTable(GlobalEnum.Action.CREAR_NUEVO,nuevaVisita);

            var toast = Toast.Make("Nueva visita registrada correctamente" , CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAsync();

        }
        catch(InvalidCastException invalidCastException)
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
            _totalProducto += Math.Round(prod.Precio,2);
        }
        calcularTotal();
    }

    private void Servicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _totalServicio = 0;
        foreach (EN_Servicio serv in e.CurrentSelection)
        {
            _totalServicio += Math.Round(serv.Precio,2);
        }
        calcularTotal();
    }

    private void TimerCallback(object state)
    {
        EN_Visita visita = (EN_Visita)state;

        double PrecioxMinuto = ApplicationProperties.precioXMinute;

        // Actualiza el tiempo restante y realiza otras operaciones según sea necesario
        DateTime now = DateTime.Now;
        TimeSpan TiempoTranscurrido = now - visita.HoraEntrada;

        int totalTiempo = visita.Servicios.Sum(servicio => servicio.Tiempo);

        //Validar si el tiempo transcurrido es menor al tiempo acordado
        if ((int)TiempoTranscurrido.TotalMinutes <= totalTiempo)
        {
            visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
            Console.WriteLine($"Tiempo restante para el elemento {visita.id}: {visita.TiempoTranscurrido} Minutos");
        }
        else
        {
            int tiempoExcedente = (int)TiempoTranscurrido.TotalMinutes - totalTiempo;
            visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
            visita.Total = 0;
            visita.Total += (PrecioxMinuto * tiempoExcedente) + _calcularTotalVisitas(visita);
        }

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
    private List<EN_ServiciosVisita> convertEN_ServicionToEN_ServicioVisita(EN_Servicio servicio)
    {
        List<EN_ServiciosVisita> listaServicioVisita = new List<EN_ServiciosVisita>();

        EN_ServiciosVisita servicioVisita = new EN_ServiciosVisita();
        servicioVisita.Servicio_Id = servicio.id;
        servicioVisita.ServicioName = servicio.ServicioName;
        servicioVisita.Servicio_Precio = servicio.Precio;
        servicioVisita.Tiempo = servicio.Tiempo;

        listaServicioVisita.Add(servicioVisita);

        return listaServicioVisita;
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