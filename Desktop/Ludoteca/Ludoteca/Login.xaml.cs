using Entidad;
using Negocio;

namespace Ludoteca;

public partial class Login : ContentPage
{



    public Login()
	{
		InitializeComponent();
	}
	
	public async void OnLoginButtonClicked(object sender, EventArgs e)
	{
		string username = txtUsername.Text;
		string password = txtContraseña.Text;

		
        
		if (validacionLogin != null)
			await DisplayAlert("Mensaje", await RN_Users.RN_Login(username, password), "OK");
        else
            await DisplayAlert("Alerta", validacionLogin(username,password), "OK");
		await Navigation.PushAsync(new MainPage());
	}
    public string validacionLogin(string username, string password)
    {
        if (username == null & password == null && username == "" && password == "")
			return "Los campos no pueden ser vacíos";
		
		return null;		
	
    }
	
}