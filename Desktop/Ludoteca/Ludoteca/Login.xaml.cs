using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Negocio;
using Newtonsoft.Json;

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
        string password = txtContrase�a.Text;

        if (string.IsNullOrEmpty(validacionLogin(username, password)))
        {
            try
            {
                // Realizar la solicitud de inicio de sesi�n a la API
                var response = await RN_Users.RN_Login(username, password);

                
                // Verificar si la solicitud fue exitosa
                if (response.RerrorCode == GlobalEnum.ErrorCode.SUCCESS.GetHashCode().ToString())//Significa que no hubo error en la peticion
                {
                    // Obtener los datos del usuario de la respuesta
                   
                    var userData = response.Rbody.FirstOrDefault();
                    if (userData != null)
                    {
                        AccionesSession.LLenarValoresSession(userData);
                        // Guardar la sesi�n en un archivo XML
                        AccionesSession.SaveSession();

                        // Mostrar un mensaje de �xito
                        string successMessage = $"Usuario {username} conectado correctamente";
                        var toastMessage = Toast.Make(successMessage, CommunityToolkit.Maui.Core.ToastDuration.Short, 13);
                        await toastMessage.Show();

                        // Redirigir a la p�gina principal de la aplicaci�n
                        App.Current.MainPage = new AppShell();
                    }

                    
                }
                else
                {
                    // Mostrar un mensaje de error si la solicitud no fue exitosa
                    await DisplayAlert("Error", response.Rmessage, "OK");
                    
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre una excepci�n durante el inicio de sesi�n
                await DisplayAlert("Error", "Ha ocurrido un error en el proceso del login\nDetalle: " + ex.Message, "Ok");
            }
        }
        else
        {
            // Mostrar un mensaje si los datos de inicio de sesi�n no son v�lidos
            await DisplayAlert("Alerta", validacionLogin(username, password), "OK");
        }
    }
    public string validacionLogin(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return "Los campos no pueden ser vac�os";

        return null;

    }
	
}