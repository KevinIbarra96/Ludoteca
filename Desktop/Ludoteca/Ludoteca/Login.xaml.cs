namespace Ludoteca;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	private void OnLoginButtonClicked(object sender, EventArgs e)
	{
		string username = txtUsername.Text;
		string password = txtContrase�a.Text;


        
        if (username == "GeraValente")
        {
            if (password == "test1")
            {
                // Si las credenciales son correctas, mostramos un mensaje de alerta
                //Navigation.PushAsync(new AppShell());
                
                DisplayAlert("��xito!", "Usuario " + username + " conectado correctamente.", "OK");
                 Navigation.PushAsync(new AppShell());
            }
            else
            {
                // Si la contrase�a es incorrecta, mostramos un mensaje de error espec�fico
                DisplayAlert("Error", "Contrase�a incorrecta. Por favor, intente nuevamente.", "OK");
            }
        }
        else
        {
            // Si el usuario es incorrecto, mostramos un mensaje de error espec�fico
            DisplayAlert("Error", "Usuario incorrecto. Por favor, intente nuevamente.", "OK");
        }


    }
}