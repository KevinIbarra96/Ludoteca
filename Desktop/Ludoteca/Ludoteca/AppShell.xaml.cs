using Entidad;
using Ludoteca.View;
using Negocio;
using Ludoteca.Resources;
using System;

namespace Ludoteca
{
    public partial class AppShell : Shell
    {        

        public AppShell()
        {            
            InitializeComponent();
            loadMenu();                                             
        }

        public async void loadMenu()
        {
            List<EN_Menu> menuList = await RN_Menu.RN_GetMenuByRol(Session.RolId);

            foreach (EN_Menu menu in menuList)
            {
                ShellContent me = new ShellContent();
                me.Title = menu.MenuName;
                me.ContentTemplate = new DataTemplate(Type.GetType(menu.Path)) ;
                me.Route = menu.ClassName;

                Items.Add(me);
            }
        }

    }
}
