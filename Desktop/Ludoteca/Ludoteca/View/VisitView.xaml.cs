namespace Ludoteca.View;

using Entidad;
using global::Resources.Properties;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;
using System.Diagnostics;

public partial class VisitView : ContentPage
{

    VisitViewModel viewModel;

    UpdateVisitasTable _updateVisitasTable;
    CalcularTotalVisita _calcularTotalVisita;
    AddProductoToVisita _addProductoToVisita;
    AddServicioToVisita _addServicioToVisita;

    TicketPrinter ticket;

    public VisitView()
    {
        InitializeComponent();

        viewModel = new VisitViewModel();
        BindingContext = viewModel;

        _updateVisitasTable = viewModel._UpdateVisitasTable;
        _calcularTotalVisita = viewModel._CalcularTotalVisita;
        _addProductoToVisita = viewModel._AddProductoToVisita;
        _addServicioToVisita = viewModel._addServicioToVIsita;

        searchBar.TextChanged += SearchBar_TextChanged;

    }

    private void SearchBar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string searchText = searchBar.Text;
        int count = 0;
        viewModel.Visitas.Clear();

        foreach (var product in viewModel.VisitasInmutable.Where(visita =>
                                visita.Hijos != null && visita.Hijos.Any(hijo =>
                                hijo.NombreHijo.Contains(searchText, StringComparison.OrdinalIgnoreCase))))
        {
            count += 1;
            viewModel.Visitas.Add(product); // Agregar los productos filtrados de nuevo
        }
        Console.WriteLine(count);
    }
    private async void NuevaVisita_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.NuevaVisitaPopUp(_updateVisitasTable, _calcularTotalVisita));
    }

    private async void AddServicio_Clicked(object sender, EventArgs e)
    {

        var btn = sender as Label;
        var visitaSelected = btn.BindingContext as EN_Visita;

        await MopupService.Instance.PushAsync(new PopUp.ServicioList(_addServicioToVisita, visitaSelected.id));
    }

    private async void RegistrarPadreEHijo_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.RegistrarPadresEHijos());
    }

    private async void Cobrar_Clicked(object sender, EventArgs e)
    {
        //TODO fañta agregarle los diferentes casos relacionados a cuando es la primera visita del hijo(Ya se agrego un registro simple, falta agregar mas de 1 hijo por padres,agregarle un nuevo hijo a padres ya registrados)
        //TODO falta agregarle las actualizaciones para cuando se agrega un nuevo producto o un nuevo servicio a la visita esa misma actualizacion debe realizarce a la base de datos

        if (await DisplayAlert("Advertencia", "¿Continuar con el proceso de cobro?", "Si", "No"))
        {
            try
            {

                var btn = sender as Label;
                var visitaSelected = btn.BindingContext as EN_Visita;

                if (!await DisplayAlert("Información", "¿Entregó Gafete?", "Si", "No"))
                {
                    visitaSelected.Total += 50.00;
                    visitaSelected.GafeteEntregado = false;

                    await RN_Gafete.Delete(visitaSelected.GafeteId);
                }

                visitaSelected.HoraSalida = DateTime.Now;
                visitaSelected.TiempoTotal = visitaSelected.TiempoTranscurrido;

                ticket = new TicketPrinter(visitaSelected);
                string action = await DisplayActionSheet("Selecciona una impresora ", "Cancel", null, ticket.ListPrinters());

                if (action == "Cancel")
                {
                    await DisplayAlert("Atencion", "No se seleccionó ninguna impresora, se cancelará el proceso de cobro", "OK");
                    return;
                }

                await ticket.PrintTicket(action);

                bool answer = await DisplayAlert("Atencion", "¿Quieres imprimir otro ticket?", "Si", "No");
                if (answer)
                    await ticket.PrintTicket(action);


                //await CrearTicketPDF(visitaSelected, action);

                await RN_Visita.cobrarVisitas(visitaSelected);

                _updateVisitasTable(GlobalEnum.Action.REMOVER, visitaSelected);

                await DisplayAlert("Felicidades", "Se ah cobrado la visitaa de " + visitaSelected.Hijos.First().NombreHijo, "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle:" + ex.Message, "OK");
                Debug.WriteLine(ex.Message);
            }
        }

    }
    private async Task CrearTicketPDF(EN_Visita visitaSelected, string PrintName)
    {

        // Obtener la fecha actual
        DateTime fechaActual = DateTime.Today;
        int year = fechaActual.Year;
        int day = fechaActual.Day;
        var nameMonth = fechaActual.ToString("MMMM");

        // Obtener nuevo folio desde la base de datos
        var folioResponse = await RN_Tickets.RN_GetNewFolio();
        var nuevoFolio = folioResponse.Rbody.First().id;

        string nombreTicket = $"Ticket_{nuevoFolio}_{visitaSelected.Hijos[0].NombreHijo}{fechaActual:yyyyMMdd}.pdf";

        // Verificar los valores de la fecha
        if (year < 1900 || year > DateTime.Now.Year || fechaActual.Month < 1 || fechaActual.Month > 12 || day < 1 || day > 31)
        {
            throw new Exception("Fecha inválida.");
        }
        // Obtener la ruta base desde la configuración de la BD
        string rutaBase = ApplicationProperties.rutaTickets.ConfigStringValue;

        // Definir la ruta del directorio (año, mes, día)
        string rutaDirectorio = Path.Combine(rutaBase, year.ToString(), nameMonth, day.ToString());

        // Verificar si el directorio existe y crear si no existe
        if (!Directory.Exists(rutaDirectorio))
        {
            Directory.CreateDirectory(rutaDirectorio);
        }

        // Definir la ruta del archivo PDF
        string rutaPDF = Path.Combine(rutaDirectorio, nombreTicket);

        await RN_Tickets.RN_AddNewTicket(new EN_Tickets
        {
            nombre = nombreTicket,
            idvisita = visitaSelected.id,
            fecha_creacion = fechaActual.Date,
            ruta = rutaPDF,

        });

    }

    private async void AddProductos_Tapped(object sender, TappedEventArgs e)
    {
        var btn = sender as Border;
        var visitaSelected = btn.BindingContext as EN_Visita;

        await MopupService.Instance.PushAsync(new PopUp.ProductoList(_addProductoToVisita, visitaSelected.id, visitaSelected.Productos));
    }
}
