using Ludoteca.ViewModel;

namespace Ludoteca.View;

public partial class ReporteVisitasView : ContentPage
{
    ReporteVisitasViewModel viewModel;
    private DateTime fechaInicio;
    private DateTime fechaFin;
    public ReporteVisitasView()
    {
        InitializeComponent();

        viewModel = new ReporteVisitasViewModel();
        BindingContext = viewModel;

    }
    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime fechaSeleccionada = e.NewDate;
        await viewModel.LoadReporteVisitasByDate(fechaSeleccionada);
    }
    private void OnDateInicioSelected(object sender, DateChangedEventArgs e)
    {
        fechaInicio = e.NewDate;
    }
    private void OnDateFinSelected(object sender, DateChangedEventArgs e)
    {
        fechaFin = e.NewDate;
    }
    private async void OnFilterByDateRangeClicked(object sender, EventArgs e)
    {
        DateTime fechaFin = FechaFinPicker.Date;
        if (fechaInicio > fechaFin)
        {
            await DisplayAlert("Error", "La fecha de inicio no puede ser mayor que la fecha de fin", "OK");
            return;
        }

        await viewModel.LoadReporteVisitasByDateRange(fechaInicio, fechaFin);
    }

    private void OnShowDateFilterTapped(object sender, EventArgs e)
    {
        var label = sender as Label;
        var commandParameter = (string)label?.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault()?.CommandParameter;

        if (commandParameter == "Fecha")
        {
            DateFechaSelected.IsVisible = !DateFechaSelected.IsVisible;
        }
        else if (commandParameter == "Rango")
        {
            RangoFechasContainer.IsVisible = !RangoFechasContainer.IsVisible;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.SuppressFinalize(this);
    }

}
