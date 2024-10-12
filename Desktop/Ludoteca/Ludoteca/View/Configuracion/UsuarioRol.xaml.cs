using Ludoteca.ViewModel;

namespace Ludoteca.View.Configuracion;

public partial class UsuarioRol : ContentView
{

    ConfiguracionViewModel viewModel;

    public UsuarioRol()
	{
		InitializeComponent();

        viewModel = new ConfiguracionViewModel();
        BindingContext = viewModel;

    }
}