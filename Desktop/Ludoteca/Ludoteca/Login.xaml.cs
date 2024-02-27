using Entidad;
using Ludoteca.Resources;
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

		if(string.IsNullOrEmpty(validacionLogin(username, password)))
		{
            string result = await RN_Users.RN_Login(username, password);
			if(!string.IsNullOrEmpty(result))
			{
                await DisplayAlert("Mensaje", result, "OK");
                string successMessage = $"Usuario '{username}' conectado correctamente";
				if(successMessage == result)
				{
                    //Geenra un id de sesion unico
                    string sessionId = Guid.NewGuid().ToString();
					Session.SetSessionId(sessionId);
                    

                    //navegacion
                    await Navigation.PushAsync(new AppShell());
                }             
            }          
        } else
		{
            await DisplayAlert("Alerta", validacionLogin(username, password), "OK");

        }





    }
    public string validacionLogin(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return "Los campos no pueden ser vacíos";

        return null;

    }
	
}