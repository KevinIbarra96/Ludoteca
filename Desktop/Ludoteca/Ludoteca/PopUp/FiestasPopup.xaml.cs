namespace Ludoteca.PopUp;

using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;
using System.Collections.ObjectModel;

public partial class FiestasPopup
{

    UpdateFiestasTable _updateFiestaTable;

    EN_Padre padre;
    EN_Servicio _Servicio;
    EN_Turno _Turno;
    List<EN_Hijo> _hijosVisita;
    double _Total = 0, _PrecioServicio = 0, _PrecioNiñoAdicional = 0;
    int _niñosAdicionales = 0, _FiestaId;
    List<EN_Servicio> _ServiciosList = new List<EN_Servicio>();
    List<EN_Turno> _TurnoList = new List<EN_Turno>();

    ObservableCollection<EN_Fiesta> FiestasList;

    List<DateTime> FechasProgramadas;

    bool isResetting = false, _Editando = false, _Editado = false;

    private TicketPrinter ticket;
    public FiestasPopup(UpdateFiestasTable updateFiestasTable)
    {
        InitializeComponent();

        FiestaViewModel fiestaVM;

        fiestaVM = new FiestaViewModel();

        FiestasList = fiestaVM.fiestas;

        _updateFiestaTable = updateFiestasTable;
        NiñosAdicionalesEntry.Text = "0";

        LoadItemData(null);

        BtnGuardar.Clicked += BtnGuardar_Clicked;

    }

    public FiestasPopup(UpdateFiestasTable updateFiestasTable, EN_Fiesta fiesta)
    {
        InitializeComponent();

        FiestaViewModel fiestaVM;

        fiestaVM = new FiestaViewModel();

        FiestasList = fiestaVM.fiestas;
        _FiestaId = fiesta.id;
        _Editando = true;
        _hijosVisita = fiesta.Hijo;

        _updateFiestaTable = updateFiestasTable;

        LoadItemData(fiesta);

        BtnGuardar.Clicked += BtnActualizar_Clicked;

    }

    private async Task LoadItemData(EN_Fiesta fiesta)
    {
        try
        {
            await GetPrecioNiñoAdicional();
            await GetServiciosFiestas();
            await GetActiveTurno();

            if (fiesta != null)
            {
                NumTelefonoEntry.IsEnabled = false;

                EN_Servicio ser = _ServiciosList.First(f => f.id == fiesta.IdServicio);
                ServiciosPicker.SelectedItem = ser;
                _Servicio = ser;

                PadresCollectionView.ItemsSource = fiesta.Padre;
                HijosCollectionView.ItemsSource = fiesta.Hijo;
                HijosCollectionView.SelectedItem = fiesta.Hijo.First();
                HijosCollectionView.IsEnabled = false;

                EN_Turno tur = _TurnoList.First(f => f.id == fiesta.IdTurno);
                TurnosPicker.SelectedItem = tur;
                _Turno = tur;

                FechaFiesta.Date = fiesta.Fecha;
                AnticipoEntry.Text = fiesta.Anticipo.ToString();
                NiñosAdicionalesEntry.Text = fiesta.NinosAdicionales.ToString();
                TematicaEntry.Text = fiesta.Tematica;
                TipoComidaEntry.Text = fiesta.TipoComida;
                EdadACumplirEntry.Text = fiesta.EdadACumplir.ToString();
            }

            calcularTotal();
            _Editando = false;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
        }
    }

    private async Task GetPrecioNiñoAdicional()
    {
        var Response = await RN_Configuracion.getConfigurationById(5);
        _PrecioNiñoAdicional = (double)Response.Rbody.First().ConfigDecimalValue;

    }

    private async Task GetFiestasProgramadas()
    {
        try
        {
            var Response = await RN_Fiesta.RN_FechasProgramadas();
            FechasProgramadas = Response.Rbody;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
        }
    }

    private async Task GetActiveTurno()
    {
        try
        {
            var Response = await RN_Turno.RN_GetAllActiveTurno();
            TurnosPicker.ItemsSource = Response.Rbody;
            _TurnoList = Response.Rbody;

            TurnosPicker.ItemDisplayBinding = new Binding("NombreTurno");
            TurnosPicker.SelectedItem = Response.Rbody.First();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
        }
    }

    private void BuscarHijos_Clicked(object sender, EventArgs e)
    {
        getPadresEHijos(NumTelefonoEntry.Text);
    }

    private async Task GetServiciosFiestas()
    {
        try
        {
            EN_Response<EN_Servicio> responseServicio = await RN_Servicio.RN_GetallServiciosByTipoServicio(2);
            _ServiciosList = responseServicio.Rbody;
            ServiciosPicker.ItemsSource = responseServicio.Rbody;
            ServiciosPicker.ItemDisplayBinding = new Binding("ServicioName");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error al actualizar\nDetalle: " + ex.Message, "Ok");
        }
    }

    private void calcularTotal()
    {
        _Total = 0;
        _Total += _PrecioServicio;
        _Total += _PrecioNiñoAdicional * _niñosAdicionales;

        TotalFiesta.Text = "";
        TotalFiesta.Text = "<strong style=\"color:red\"> Total: </strong>" + _Total + "$";
    }

    private void Hijos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (EN_Hijo hijo in e.PreviousSelection)
        {
            hijo.SelectedBackgroundColor = "White";
        }

        foreach (EN_Hijo hijo in e.CurrentSelection)
        {
            hijo.SelectedBackgroundColor = "#40E1E1E1";
        }
    }

    private async void getPadresEHijos(string _phone)
    {
        try
        {
            EN_Response<EN_Padre> PadreResp = await RN_Padre.getPadreByPhone(_phone);
            var padreList = PadreResp.Rbody;

            if (padreList.Count == 0)
            {
                throw new Exception("No se encontró el padre");
            }

            padre = padreList.First();

            List<EN_Hijo> hijo = await RN_Hijo.getHijosByPadresId(padre.id);

            PadresCollectionView.ItemsSource = new List<EN_Padre>() { padre };
            HijosCollectionView.ItemsSource = hijo;
        }
        catch (Exception ex)
        {
            //Padrelabl.Text = "";
            PadresCollectionView.ItemsSource = new List<EN_Padre>();
            HijosCollectionView.ItemsSource = new List<EN_Hijo>();
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private void ServiciosPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        _PrecioServicio = 0;
        var pick = (Picker)sender;
        EN_Servicio serv = (EN_Servicio)pick.SelectedItem;
        _Servicio = serv;
        _PrecioServicio = _Servicio.Precio;
        calcularTotal();
    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {

        try
        {
            if (!await DisponibilidadValidacion(FechaFiesta.Date, (EN_Turno)TurnosPicker.SelectedItem))
                throw new Exception("Ya hay una fiesta programada en esta fecha y en el turno");

            if (FechaFiesta.Date <= DateTime.Now)
                throw new Exception("No es permitido programar una fiesta hoy o anterior a hoy");

            EN_Fiesta nuevaFiesta = RecolercarFiestaData();

            var Response = await RN_Fiesta.RN_AddNewFiesta(nuevaFiesta);
            if (Response.Rcode != 200)
                throw new Exception("Ah ocurrido un error\nDetalle: " + Response.Rmessage);

            nuevaFiesta.id = Response.Rbody.First().id;

            _updateFiestaTable(GlobalEnum.Action.CREAR_NUEVO, nuevaFiesta);

            await imprimirFiesta(nuevaFiesta);

            /*var toast = Toast.Make("Nueva fiesta programada correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();*/

            await MopupService.Instance.PopAsync();

        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }

    }

    private async void BtnActualizar_Clicked(object sender, EventArgs e)
    {

        try
        {
            if (_Editado)
            {
                if (!await DisponibilidadValidacion(FechaFiesta.Date, (EN_Turno)TurnosPicker.SelectedItem))
                    throw new Exception("Ya hay una fiesta programada en esta fecha y en el turno");
            }

            if (FechaFiesta.Date <= DateTime.Now)
                throw new Exception("No es permitido programar una fiesta hoy o anterior a hoy");

            EN_Fiesta nuevaFiesta = RecolercarFiestaData();
            nuevaFiesta.Hijo = _hijosVisita;
            nuevaFiesta.id = _FiestaId;

            var Response = await RN_Fiesta.RN_UpdateFiesta(nuevaFiesta);
            if (Response.Rcode != 200)
                throw new Exception("Ah ocurrido un error\nDetalle: " + Response.Rmessage);

            _updateFiestaTable(GlobalEnum.Action.ACTUALIZAR, nuevaFiesta);

            //await imprimirFiesta(nuevaFiesta);

            /*var toast = Toast.Make("Nueva fiesta Actualizada correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();*/

            //await Task.WhenAll(imprimirFiesta(nuevaFiesta));
            await imprimirFiesta(nuevaFiesta);

            await MopupService.Instance.PopAsync();

        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Error", "Por favor completa todos los campos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async Task imprimirFiesta(EN_Fiesta fiesta)
    {

        ticket = new TicketPrinter(fiesta);
        string action = await Application.Current.MainPage.DisplayActionSheet("Selecciona una impresora ", "No Imprimir", null, ticket.ListPrinters());

        if (action == "No Imprimir")
        {
            //await DisplayAlert("Atencion", "No se seleccionó ninguna impresora, se cancelará el proceso", "OK");
            //throw new Exception("No se seleccionó ninguna impresora, se cancelará el proceso");
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

    private EN_Fiesta RecolercarFiestaData()
    {
        EN_Fiesta nuevaFiesta = new EN_Fiesta();
        nuevaFiesta.Fecha = FechaFiesta.Date;
        nuevaFiesta.IdServicio = _Servicio.id;
        nuevaFiesta.Servicio = _Servicio;
        nuevaFiesta.Hijo = HijosCollectionView.SelectedItems.OfType<EN_Hijo>().ToList();
        nuevaFiesta.Tematica = TematicaEntry.Text;
        nuevaFiesta.EdadACumplir = int.Parse(EdadACumplirEntry.Text);
        nuevaFiesta.IdTurno = _Turno.id;
        nuevaFiesta.Turno = _Turno.NombreTurno;
        nuevaFiesta.TipoComida = TipoComidaEntry.Text;
        nuevaFiesta.NinosAdicionales = int.Parse(NiñosAdicionalesEntry.Text);
        nuevaFiesta.Anticipo = double.Parse(AnticipoEntry.Text);
        nuevaFiesta.Total = _Total;

        return nuevaFiesta;
    }

    private void NiñosAdicionalesEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        _niñosAdicionales = 0;
        if (NiñosAdicionalesEntry.Text != "")
            _niñosAdicionales = int.Parse(NiñosAdicionalesEntry.Text);
        calcularTotal();
    }

    private async void FechaFiesta_DateSelected(object sender, DateChangedEventArgs e)
    {

        if (isResetting || _Editando)
            return;

        if (!await DisponibilidadValidacion(e.NewDate.Date, (EN_Turno)TurnosPicker.SelectedItem))
        {
            isResetting = true;

            ((DatePicker)sender).Date = e.OldDate;

            isResetting = false;
            _Editado = true;
        }

    }

    private async Task<bool> DisponibilidadValidacion(DateTime fechaActual, EN_Turno Turno)
    {
        bool res = true;

        if (FiestasList.Any(x => x.Fecha == fechaActual && x.IdTurno == Turno.id))
        {
            res = false;
            await DisplayAlert("Alerta", "Ya hay una fiesta programada en esta fecha y en el turno", "OK");
        }

        return res;
    }

    private async void TurnosPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (_Editando)
            return;

        if (!await DisponibilidadValidacion(FechaFiesta.Date, (EN_Turno)TurnosPicker.SelectedItem))
        {
            TurnosPicker.SelectedItem = _Turno;
        }
        else
        {
            var pick = (Picker)sender;
            EN_Turno turno = (EN_Turno)pick.SelectedItem;
            _Turno = turno;
            _Editado = true;
        }

    }
}