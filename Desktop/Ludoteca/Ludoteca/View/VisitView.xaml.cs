namespace Ludoteca.View;

using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Diagnostics;

public partial class VisitView : ContentPage
{

    VisitViewModel viewModel;

    UpdateVisitasTable _updateVisitasTable;
    CalcularTotalVisita _calcularTotalVisita;
    AddProductoToVisita _addProductoToVisita;
    AddServicioToVisita _addServicioToVisita;

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
        await MopupService.Instance.PushAsync(new PopUp.NuevaVisitaPopUp(_updateVisitasTable,_calcularTotalVisita));
    }

    private async void AddProducto_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Label;
        var visitaSelected = btn.BindingContext as EN_Visita;

        await MopupService.Instance.PushAsync(new PopUp.ProductoList(_addProductoToVisita, visitaSelected.id) );
    }

    private async void AddServicio_Clicked(object sender, EventArgs e)
    {

        var btn = sender as Label;
        var visitaSelected = btn.BindingContext as EN_Visita;

        await MopupService.Instance.PushAsync(new PopUp.ServicioList(_addServicioToVisita,visitaSelected.id) );
    }

    private async void RegistrarPadreEHijo_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.RegistrarPadresEHijos() );
    }

    private async void Cobrar_Clicked(object sender, EventArgs e)
    {
        //TODO fañta agregarle los diferentes casos relacionados a cuando es la primera visita del hijo(Ya se agrego un registro simple, falta agregar mas de 1 hijo por padres,agregarle un nuevo hijo a padres ya registrados)
        //TODO falta agregarle las actualizaciones para cuando se agrega un nuevo producto o un nuevo servicio a la visita esa misma actualizacion debe realizarce a la base de datos

        try
        {
            
            if (await DisplayAlert("Advertencia", "¿Continuar con el proceso de cobro?", "Si", "No"))
            {
                try
                {
                    var btn = sender as Label;
                    var visitaSelected = btn.BindingContext as EN_Visita;

                    //await RN_Visita.RN_DeleteVisita(visitaSelected.id);
                    await RN_Visita.cobrarVisitas(visitaSelected);

                    GenerateTicketPdf(@"C:\PDF\PDFPrueba.pdf", visitaSelected, CalcularAlturaDelTicket(visitaSelected.Productos.Count));
                    _updateVisitasTable(GlobalEnum.Action.REMOVER, visitaSelected);

                    await DisplayAlert("Felicidades", "Se ah cobrado la visitaa de " + visitaSelected.Hijos[0].NombreHijo, "OK");
                }catch(Exception ex)
                {
                    await DisplayAlert("Error","Ah ocurrido un erro\nDetalle:"+ ex.Message,"OK");
                }
            }

        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", "ah ocurrido un error \nDetalles: " + ex.Message, "OK");
        }
    }


    public static void GenerateTicketPdf(string fileName,EN_Visita visita , double height)
    {
        // Ancho del ticket en milímetros
        double width = 70;
        double initialHeight = 200; // Altura inicial, se ajustará dinámicamente según el contenido

        PdfDocument document = new PdfDocument();
        document.Info.Title = "Ticket de Compra";

        PdfPage page = document.AddPage();
        page.Width = XUnit.FromMillimeter(width);
        page.Height = XUnit.FromMillimeter(initialHeight);

        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont titleFont = new XFont("Arial", 8, XFontStyle.Bold);
        XFont regularFont = new XFont("Arial", 8, XFontStyle.Regular);

        double x = 10, y = 10;
        double lineHeight = regularFont.GetHeight();

        // Encabezado centrado
        string titulo = "La Casita de Molly";
        double tituloWidth = gfx.MeasureString(titulo, titleFont).Width;
        double tituloX = x;
        gfx.DrawString(titulo, titleFont, XBrushes.Black, new XRect(tituloX, y, width, height), XStringFormats.TopCenter);
        y += lineHeight * 2;

        foreach (var hijo in visita.Hijos)
        {
            gfx.DrawString("Nombre: " + hijo.NombreHijo, regularFont, XBrushes.Black, new XRect(x, y, width, height), XStringFormats.TopLeft);
            y += lineHeight;
        }

        gfx.DrawString("Hora de entrada: " + visita.HoraEntrada, regularFont, XBrushes.Black, new XRect(x, y, width, height), XStringFormats.TopLeft);
        y += lineHeight;
        gfx.DrawString("Hora de salida: " + DateTime.Now, regularFont, XBrushes.Black, new XRect(x, y, width, height), XStringFormats.TopLeft);
        y += lineHeight;
        gfx.DrawString("Gafete: " + visita.NumeroGafete, regularFont, XBrushes.Black, new XRect(x, y, width, height), XStringFormats.TopLeft);
        y += lineHeight;
        gfx.DrawString("Minutos extendidos: " + visita.TiempoExcedido, regularFont, XBrushes.Black, new XRect(x, y, width, height), XStringFormats.TopLeft);
        y += lineHeight;

        y += 5;
        gfx.DrawLine(XPens.Black, x, y, width - 20, y); // Línea horizontal ajustada
        y += 5;

        // Dibujar encabezado de productos y servicios
        gfx.DrawString("Productos y Servicios", titleFont, XBrushes.Black, new XRect(x, y, width - 20, height), XStringFormats.TopLeft);

        // Ajuste de las posiciones de las columnas
        double precioX = x + 100; // Posición ajustada más cerca y un poco a la izquierda
        gfx.DrawString("Precio", titleFont, XBrushes.Black, new XRect(precioX, y, 30, height), XStringFormats.TopRight);

        double totalX = precioX + 30; // Posición ajustada para que "Total" esté cerca de "Precio"
        gfx.DrawString("Total", titleFont, XBrushes.Black, new XRect(totalX, y, 30, height), XStringFormats.TopRight);
        y += lineHeight;

        foreach (var servicio in visita.Servicios)
        {
            gfx.DrawString(servicio.ServicioName, regularFont, XBrushes.Black, new XRect(x, y, 100, height), XStringFormats.TopLeft); // Ajuste ancho de la primera columna
            gfx.DrawString(servicio.Servicio_Precio.ToString("0.00"), regularFont, XBrushes.Black, new XRect(precioX, y, 30, height), XStringFormats.TopRight);
            gfx.DrawString(servicio.Servicio_Precio.ToString("0.00"), regularFont, XBrushes.Black, new XRect(totalX, y, 30, height), XStringFormats.TopRight);
            y += lineHeight;

            // Ajuste dinámico de la altura de la página
            if (y > page.Height.Point - 20)
            {
                page.Height = new XUnit(y + 20, XGraphicsUnit.Point);
            }
        }

        foreach (var producto in visita.Productos)
        {
            gfx.DrawString(producto.CantidadProducto, regularFont, XBrushes.Black, new XRect(x, y, 110, height), XStringFormats.TopLeft); // Ajuste ancho de la primera columna
            gfx.DrawString(producto.precioProductoVisita.ToString("0.00"), regularFont, XBrushes.Black, new XRect(precioX, y, 30, height), XStringFormats.TopRight);
            gfx.DrawString(producto.precioProductoVisita.ToString("0.00"), regularFont, XBrushes.Black, new XRect(totalX, y, 30, height), XStringFormats.TopRight);
            y += lineHeight;

            // Ajuste dinámico de la altura de la página
            if (y > page.Height.Point - 20)
            {
                page.Height = new XUnit(y + 20, XGraphicsUnit.Point);
            }
        }

        y += 5;
        gfx.DrawLine(XPens.Black, x, y, width - 20, y);
        y += 5;

        gfx.DrawString("Total: $" + visita.Total.ToString("0.00"), regularFont, XBrushes.Black, new XRect(x, y, width - 20, height), XStringFormats.TopLeft); ;

        document.Save(fileName);
    }

    public static double CalcularAlturaDelTicket(int numServicios)
    {
        // Calcular la altura del ticket en función del número de servicios y otros elementos
        double titleHeight = 20; // Altura del título
        double footerHeight = 20; // Altura del pie de página
        double lineHeight = 12; // Altura de línea de texto

        // Calcular la altura total en función del número de servicios
        double serviciosHeight = lineHeight * numServicios; // Altura de los servicios
        double totalHeight = titleHeight + footerHeight + serviciosHeight;

        return totalHeight;
    }

}
