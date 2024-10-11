using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.ViewModel
{
    internal class ConfiguracionViewModel
    {

        public ObservableCollection<EN_Gafete> Gafetes { get; set; }
        public ObservableCollection<EN_User> Usuarios { get; set; }

        public ConfiguracionViewModel() {

            Gafetes = new ObservableCollection<EN_Gafete>();
            Usuarios = new ObservableCollection<EN_User>();
            getAllActiveGafetes();
            getAllUsers();
        }

        private async void getAllUsers()
        {
            var UsuariosResponse = await RN_Users.RN_GetUsersAndRol();
            foreach (EN_User us in UsuariosResponse.Rbody)
            {
                if (us.status == 0)
                    us.statusString = "Inactivo";
                else
                    us.statusString = "Activo";
                addUsuariosToCollection(us);
            }

        }

        private async void getAllActiveGafetes()
        {

            var gafeteResponse = await RN_Gafete.getAllActiveGafete();

            foreach (EN_Gafete en in gafeteResponse.Rbody)
            {
                if (en.Asignado == 0)
                    en.AsignadoString = "No";
                else
                    en.AsignadoString = "Si";

                if (en.Status == 0)
                    en.StatusString = "Inactivo";
                else
                    en.StatusString = "Activo";

                addGafeteToCollection(en);
            }
        }

        private void addUsuariosToCollection(EN_User usuario)
        {
            Usuarios.Add(usuario);
        }

        private void addGafeteToCollection(EN_Gafete gafete)
        {
            Gafetes.Add(gafete);
        }

    }
}
