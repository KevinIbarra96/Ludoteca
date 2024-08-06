using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.View;

public partial class ServiciosView : ContentPage
{
    int count = 0;

    ServiciosViewModel viewModel;

    LoadServiciosTable _loadServiciosTable;
    UpdateServiciosTable _UpdateServiciosTable;

    public ServiciosView()
	{
		InitializeComponent();

        viewModel = new ServiciosViewModel();
        BindingContext = viewModel;

        _loadServiciosTable = viewModel._loadServiciosTable;
        _UpdateServiciosTable = viewModel._UpdateServiciosTable;

        searchBar.TextChanged += SearchBar_TextChanged;
    }

    private void SearchBar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        string searchText = searchBar.Text;

        // Filtrar la ObservableCollection en función del texto de búsqueda
        var filteredProducts = viewModel.SsrviciosInmutble
            .Where(p => p.ServicioName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        viewModel.servicios.Clear();

        foreach (var product in filteredProducts)
        {
            viewModel.servicios.Add(product); // Agregar los productos filtrados de nuevo
        }
    }
   /* private async void ActualizarPrecio_Clicked(object sender, EventArgs e)
    {
        EN_Response<EN_Servicio> resp;

        try
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter is EN_Servicio servicio)
            {

                string responseEntry = await DisplayPromptAsync("Servicio", "Ingresa el nuevo Precio: ", "Actualizar", "Cancelar", "Precio", 4, Keyboard.Numeric);

                if (responseEntry == "" && responseEntry != null) { await DisplayAlert("Error", "Valor no puede ser vacío", "ok"); return; } //Validar que el valor enviado no se vacío

                if (responseEntry != null)
                {
                    resp = await RN_Servicio.RN_setNewPrecio(servicio.id, int.Parse(responseEntry));

                    if (resp.RerrorCode == "0") //0 significa que no hubo ningun error, 0 es el valor por defaul que se recibe de la WebAPi
                    {

                        servicio.Precio = int.Parse(responseEntry);

                        _UpdateServiciosTable(GlobalEnum.Action.ACTUALIZAR, servicio);

                        var toast = Toast.Make("Se actualizó el precio de " + servicio.ServicioName +" a $" +servicio.Precio, CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
                        await toast.Show();
                    }
                    else
                        await DisplayAlert("Mensaje", resp.Rmessage, "ok");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "ok");
        }
    }*/

    private async void EditarServicios_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        await MopupService.Instance.PushAsync(new PopUp.ServicioPopup((EN_Servicio)btn.CommandParameter, _UpdateServiciosTable));
    }

    private async void Agregar_Clicked(object sender, EventArgs e)
    {
        await MopupService.Instance.PushAsync(new PopUp.ServicioPopup(_UpdateServiciosTable));
    }
}