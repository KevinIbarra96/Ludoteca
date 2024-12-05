using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View.Configuracion;

public partial class RolMenu : ContentView
{

    ConfiguracionViewModel viewModel;
    UpdateRolConfig _updateRolConfig;

    public RolMenu()
    {
        InitializeComponent();

        viewModel = new ConfiguracionViewModel();
        BindingContext = viewModel;

        _updateRolConfig = viewModel._updateRol;

    }

    private void Guardar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new PopUp.RolMenuPopup(_updateRolConfig));
    }

    private void ButtonActualizar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;


        MopupService.Instance.PushAsync(new PopUp.RolMenuPopup(_updateRolConfig, (EN_Rol)button.CommandParameter));
    }
}