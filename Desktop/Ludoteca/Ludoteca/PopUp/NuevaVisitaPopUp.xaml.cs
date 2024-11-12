namespace Ludoteca.PopUp;

using Entidad;
using Negocio;
using System.Linq;
using Ludoteca.ViewModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using Mopups.Services;
using Ludoteca.Resources;
using global::Resources.Properties;
using System.ComponentModel.DataAnnotations;

public partial class NuevaVisitaPopUp
{

	UpdateVisitasTable _updateVisitasTable;
    CalcularTotalVisita _calcularTotalVisitas;

    ObservableCollection<EN_Hijo> Hijos;

    double _totalProducto = 0;
    double _totalServicio = 0;
    int _TotalHijos = 0;

    bool _PrimerProductoSelec = true;

    EN_Gafete _Gafete;
    List<EN_Oferta> _Oferta =  new List<EN_Oferta>();

    private double _Total = 0;

    EN_Padre padre;

    public NuevaVisitaPopUp(UpdateVisitasTable updateVisitasTable,CalcularTotalVisita calcularTotalVisita)
	{
		InitializeComponent();

        Hijos = new ObservableCollection<EN_Hijo>();
        
        getAllProductos();
        getAllServicios();
        getAllOfertas();

        calcularTotal();
        getGafetesActivosNoAsignados();

        _updateVisitasTable = updateVisitasTable;
        _calcularTotalVisitas = calcularTotalVisita;
	}

    private void calcularTotal() {

        _Total = 0;
        _Total = _totalProducto + (_totalServicio * _TotalHijos);

        TotalVisita.Text = "";
        TotalVisita.Text = "<strong style=\"color:red\"> Total: </strong>" + _Total + "$";

    }

    #region Events

    private void Hijos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Cambiar el color de fondo del elemento seleccionado
        foreach (EN_Hijo hijo in e.PreviousSelection)
        {
            hijo.SelectedBackgroundColor = "White";
        }

        foreach (EN_Hijo hijo in e.CurrentSelection)
        {
            hijo.SelectedBackgroundColor = "#40E1E1E1";
        }

        _TotalHijos = HijosCollectionView.SelectedItems.Count;
        calcularTotal();
    }

    private async void getGafetesActivosNoAsignados()
    {
        EN_Response<EN_Gafete> responseGafete = await RN_Gafete.getGafeteNoAsignado();
        
        GafetePicker.ItemsSource = responseGafete.Rbody;
        GafetePicker.ItemDisplayBinding = new Binding("Numero");

    }

    private void OfertaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        _Oferta.Clear();
        var pick = (Picker)sender;
        EN_Oferta ofe = (EN_Oferta)pick.SelectedItem;
        _Oferta.Add(ofe);
    }

    private async void Ingresar_Clicked(object sender, EventArgs e)
    {
        List<EN_Padre> lisPadre = new List<EN_Padre>();
        lisPadre.Add(padre);
        try
        {

            string respValidar = await ValidarCampos();
            if (respValidar != null)
                throw new Exception(respValidar);

            EN_Visita nuevaVisita = new EN_Visita();
            nuevaVisita.Total = _Total;
            nuevaVisita.Oferta = _Oferta;
            nuevaVisita.GafeteId = _Gafete.id;
            nuevaVisita.NumeroGafete = _Gafete.Numero;
            nuevaVisita.Hijos = HijosCollectionView.SelectedItems.OfType<EN_Hijo>().ToList();
            nuevaVisita.Padres = lisPadre;
            nuevaVisita.Servicios = ConvertClass.convertEN_ServicionToEN_ServicioVisita( (EN_Servicio) ServicioCollectionView.SelectedItem);
            nuevaVisita.Productos = ConvertClass.convertEN_ProductosToEN_ProductosVisita(ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList());

            
            EN_Response<EN_Visita> response = await RN_Visita.ingresarNuevaVisita(nuevaVisita);
            nuevaVisita.id = response.Rbody[0].id;
            nuevaVisita.HoraEntrada = response.Rbody[0].HoraEntrada;
            nuevaVisita.Timer = new Timer(TimerCallback, nuevaVisita, 0, 15000);

            _updateVisitasTable(GlobalEnum.Action.CREAR_NUEVO, nuevaVisita);

            var toast = Toast.Make("Nueva visita registrada correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            await MopupService.Instance.PopAsync();


        }
        catch(NullReferenceException invalidCastException)
        {
            await DisplayAlert("Error", "Por favor verifica que todos los datos esten correctos", "OK");
        }catch (Exception ex)
        {
            await DisplayAlert("Error","Ah ocurrido un error\nDetalle: "+ex.Message,"OK");
        }
    }

    public async Task<string> ValidarCampos()
    {
        string resp = null;

        if (ProductosCollectionView.SelectedItems.Count == 0)
            resp = "Porfavor Selecciona un producto";

        if(ServicioCollectionView.SelectedItem == null )
            resp = "Porfavor Selecciona un servicio";

        if(HijosCollectionView.SelectedItems.Count == 0)
            resp = "Porfavor Selecciona un hijo";

        if (_Oferta.Count == 0)
            resp = "Porfavor Selecciona una oferta";

        if (_Gafete == null )
            resp = "Porfavor Selecciona un Gafete";

        return resp;
    }

    private void BuscarHijos_Clicked(object sender, EventArgs e)
    {
        getPadresEHijos(NumTelefonoEntry.Text);
    }

    private void Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DesactivarProductoVisitaEntry();
        _totalProducto = 0;
        //foreach (EN_Producto prod in e.CurrentSelection)
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
                _totalProducto += Math.Round(total, 2);
            }

            prod.IsEnable = true;
        }
        calcularTotal();
    }

    private void EntryCantidadProducto_TextChanged(object sender, TextChangedEventArgs e)
    {
        
        _totalProducto = 0;
        foreach (EN_Producto prod in ProductosCollectionView.SelectedItems.OfType<EN_Producto>().ToList())
        {
            int cantidadV = prod.CantidadVisita;
            if (e.NewTextValue == "")
                cantidadV = 0;

            double total = prod.Precio * cantidadV;
            _totalProducto += Math.Round(total, 2);
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

        double PrecioxMinuto = (double)ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue;
        double TotalPrecioExcedente = 0;

        // Actualiza el tiempo restante y realiza otras operaciones según sea necesario
        DateTime now = DateTime.Now;
        TimeSpan TiempoTranscurrido = now - visita.HoraEntrada;

        int totalTiempoServicios = visita.Servicios.Sum(servicio => servicio.Tiempo);

        //Validar si el tiempo transcurrido es menor al tiempo acordado
        if ((int)TiempoTranscurrido.TotalMinutes <= totalTiempoServicios)
        {
            visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
            Console.WriteLine($"Tiempo restante para el elemento {visita.id}: {visita.TiempoTranscurrido} Minutos");
        }
        else
        {
            int tiempoExcedente = (int)TiempoTranscurrido.TotalMinutes - totalTiempoServicios;

            //Considerar el numero de hijos para los tiemposExcedentes
            tiempoExcedente *= visita.Hijos.Count;

            /*TODO Calculo para manejar el tiempo de las ofertas cuando se habla por tiempo.
            if (tiempoExcedente > 0 && tiempoExcedente > visita.Oferta.FirstOrDefault().Tiempo)
                TotalPrecioExcedente = PrecioxMinuto * (tiempoExcedente - visita.Oferta.FirstOrDefault().Tiempo);*/

            //Cuando no tiene un servicio se maneja el servicio por defalut "Sin Servicio que se configura en ApplicationProperties"

            visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
            visita.Total = 0;
            visita.Total += TotalPrecioExcedente + _CalcularTotalVisita(visita);

            if (ApplicationProperties.IdTiempoLibreServicio == visita.Servicios.First().Servicio_Id)
            {
                if (visita.TiempoTranscurrido <= 35)
                    visita.Total += (double)(ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue * (visita.TiempoTranscurrido * visita.Hijos.Count));
                else
                    visita.Total += (double)(ApplicationProperties.PrecioMinutoSesentaMin.ConfigDecimalValue * (visita.TiempoTranscurrido * visita.Hijos.Count));
            }
            else
            {
                visita.Total += (double)(ApplicationProperties.PrecioMinutoDespuesServicio.ConfigDecimalValue * tiempoExcedente);
            }

            visita.TiempoExcedido = tiempoExcedente;

        }
    }

    private void GafetePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var pick = (Picker) sender;
        EN_Gafete gaf = (EN_Gafete)pick.SelectedItem ;
        _Gafete = gaf;
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
            List<EN_Producto> prod= await RN_Producto.RN_GetAllActiveProductos();
            ProductosCollectionView.ItemsSource = await RN_Producto.RN_GetAllActiveProductos();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
    private async void getAllServicios()
    {
        try { 
            EN_Response<EN_Servicio> Serv = await RN_Servicio.RN_GetallServiciosByTipoServicio(1);
            
            ServicioCollectionView.ItemsSource = Serv.Rbody;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
    private async void getAllOfertas()
    {
        try
        {
            EN_Response<EN_Oferta> Ofer = await RN_Oferta.RN_GetAllActiveOfertas();

            OfertaPicker.ItemsSource = Ofer.Rbody;
            OfertaPicker.ItemDisplayBinding = new Binding("OfertaName");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }
    #endregion

    #region PrivatMethod
    private void DesactivarProductoVisitaEntry()
    {
        foreach (EN_Producto prod in ProductosCollectionView.ItemsSource )
        {            
            prod.IsEnable = false;
        }
    }

    #endregion
}