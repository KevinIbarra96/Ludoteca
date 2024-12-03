using Entidad;
using Ludoteca.Resources;
using Negocio;

namespace Ludoteca
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            loadMenu();
        }

        private async void loadMenu()
        {

            try
            {
                EN_Response<EN_Menu> menuResponse = await RN_Menu.RN_GetMenuByRol(Session.RolId);
                List<EN_Menu> menuList = menuResponse.Rbody;

                foreach (EN_Menu menu in menuList)
                {
                    ShellContent me = new ShellContent();
                    me.Title = menu.MenuName;
                    me.Icon = menu.IconName;
                    me.ContentTemplate = new DataTemplate(Type.GetType(menu.Path));
                    me.Route = menu.ClassName;

                    Items.Add(me);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ah ocurrido un error \nDetalle: " + ex.Message, "Ok");
            }
        }

        private async void CerrarSession_Tapped(object sender, TappedEventArgs e)
        {

            bool answer = await DisplayAlert("Atencion", "¿Estas seguro de cerrar sesison?", "Si", "No");
            if (!answer)
                return;

            AccionesSession.CerrarSession();

            // Redirigir a la página principal de la aplicación
            App.Current.MainPage = new Login();
        }
    }
}
