using Entidad;
using Ludoteca.ViewModel;
using Mopups.Services;

namespace Ludoteca.View.Configuracion;

public partial class UsuarioRol : ContentView
{

    ConfiguracionViewModel viewModel;
    UpdateUsuarioConfig _updateUsuarioConfig;

    public UsuarioRol()
	{
		InitializeComponent();

        viewModel = new ConfiguracionViewModel();
        BindingContext = viewModel;

        _updateUsuarioConfig = viewModel._updateUsuario;

    }

    private void Editar_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        EN_User usuario = (EN_User)btn.CommandParameter;
        MopupService.Instance.PushAsync(new PopUp.UsuarioRolPopup(_updateUsuarioConfig,usuario));
    }

    private void Nuevo_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PushAsync(new PopUp.UsuarioRolPopup(_updateUsuarioConfig));
    }
}