using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View;

public partial class VentasView : ContentPage
{

	VentasViewModel viewModel;

	LoadVentasTable _loadVentasTable;
	UpdateVentasTable _updateVentasTable;

    private TicketPrinter ticket;

    public VentasView()
	{
		InitializeComponent();

		viewModel = new VentasViewModel();
		BindingContext = viewModel;

		_loadVentasTable = viewModel._loadVentasTable;
		_updateVentasTable = viewModel._updateVentasTable;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		_loadVentasTable();
        

    }


	protected override void OnDisappearing() {
		GC.Collect();
		GC.SuppressFinalize(this);
		GC.WaitForPendingFinalizers();
	}

    private async void NuevaVenta_Clicked(object sender, EventArgs e)
    {
		await MopupService.Instance.PushAsync(new PopUp.NuevaVentaPoup(_updateVentasTable) );
    }

    private async void ImprimirTicket_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;


        ticket = new TicketPrinter((EN_Ventas) btn.CommandParameter);
        string action = await DisplayActionSheet("Selecciona una impresora ", "No Imprimir", null, ticket.ListPrinters());

        if (action == "No Imprimir")
        {
            //await DisplayAlert("Atencion", "No se seleccionó ninguna impresora, se cancelará el proceso", "OK");
            //throw new Exception("No se seleccionó ninguna impresora, se cancelará el proceso");
            //await DisplayAlert("Atencion", "No se seleccionó ninguna impresora, se cancelará el proceso de cobro", "OK");
            bool answer = await DisplayAlert("Atencion", "¿Seguro que no quieres imprimir?", "Si", "No");
            if (!answer)
            {
                string action2 = await DisplayActionSheet("Selecciona una impresora ", "Cancelar", null, ticket.ListPrinters());
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
}