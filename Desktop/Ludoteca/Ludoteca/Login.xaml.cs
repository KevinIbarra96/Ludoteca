namespace Ludoteca;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	
	public void OnLoginButtonClicked(object sender, EventArgs e)
	{
		string username = txtUsername.Text;
		string password = txtContrase�a.Text;

        string message= validacionLogin(username, password);
		DisplayAlert("Mensaje", message, "OK");
    }
    public string validacionLogin(string username, string password)
    {
        string message = "";
        if (username != "GerardoValente")
		{
			message = "Usuario no existe";
		}
		if(username == "GerardoValente" && password != "test1234")
		{
			message = "Contrase�a incorrecta";
		}
			message = "Login exitoso";
		
		return message;
    }
}