using Ludoteca.ViewModel;

namespace Ludoteca.View;

public partial class ReporteVisitasView : ContentPage
{
	ReporteVisitasViewModel viewModel;
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
}