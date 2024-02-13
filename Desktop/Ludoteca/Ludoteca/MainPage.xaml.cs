﻿using Entidad;
using Negocio;

namespace Ludoteca
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public string Name { get; set; }

        public MainPage()
        {            
            GetUsers();

            InitializeComponent();

            Name = AppInfo.Name;
            this.BindingContext = this;

        }

        private async void GetUsers()
        {
            EN_User eN_User = new EN_User() { 
                UserName = "",
                Password = "",
                idRol = 1
            };

            //var userResponse = await RN_Users.RN_GetAllUsers();
            //var userRespnseID = await RN_Users.RN_GetUserByID(2);
            //var userRespnseAdd = await RN_Users.RN_AddNewUser(eN_User);
            //var userResponseDelete = await RN_Users.RN_DeleteUser(5);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            /*if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);*/
        }
    }

}
