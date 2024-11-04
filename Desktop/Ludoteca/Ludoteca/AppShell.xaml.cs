using Entidad;
using Ludoteca.View;
using Negocio;
using System;
using Ludoteca.Resources;
using System.Reflection.Metadata;
using Ludoteca.Resources.Models;

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
            EN_Response<EN_Menu> menuResponse = await RN_Menu.RN_GetMenuByRol(Session.RolId);
            List<EN_Menu> menuList = menuResponse.Rbody;

            foreach (EN_Menu menu in menuList)
            {
                ShellContent me = new ShellContent();
                me.Title = menu.MenuName;
                me.Icon = menu.IconName;
                me.ContentTemplate = new DataTemplate(Type.GetType(menu.Path)) ;
                me.Route = menu.ClassName;

                Items.Add(me);
            }
        }

    }
}
