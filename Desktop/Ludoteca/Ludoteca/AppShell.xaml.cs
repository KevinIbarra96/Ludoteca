using Entidad;
using Negocio;
using Ludoteca.Resources;

namespace Ludoteca
{
    public partial class AppShell : Shell
    {

        List<EN_Menu> menuRes;
        public AppShell()
        {

            getMenuByRol();
            
            InitializeComponent();
        }

        public async void getMenuByRol()
        {
            menuRes = await RN_Menu.RN_GetMenuByRol(Session.RolId);
        }
    }
}
