using Entidad;
using Ludoteca.Resources;
using Negocio;
using System.Collections.ObjectModel;

namespace Ludoteca.ViewModel
{

    public delegate void UpdateUsuarioConfig(GlobalEnum.Action Action, EN_User usuario);
    public delegate void UpdateRolConfig(GlobalEnum.Action Action, EN_Rol rol);
    public delegate void GetAllRolConfig();

    internal class ConfiguracionViewModel
    {

        public ObservableCollection<EN_Gafete> Gafetes { get; set; }
        public ObservableCollection<EN_User> Usuarios { get; set; }
        public ObservableCollection<EN_Rol> Rol { get; set; }

        public UpdateUsuarioConfig _updateUsuario;
        public UpdateRolConfig _updateRol;
        public GetAllRolConfig _getAllRol;
 
        public ConfiguracionViewModel() {
            Gafetes = new ObservableCollection<EN_Gafete>();
            Usuarios = new ObservableCollection<EN_User>();
            Rol = new ObservableCollection<EN_Rol>();

            _updateUsuario = UpdateUsuario;
            _updateRol = UpdateRol;
            

            getAllGafetes();
            getAllUsers();
            getAllRol();

        }

        private async Task getAllUsers()
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
        private async Task getAllRol()
        {
            var RolResponse = await RN_Rol.RN_GetAllRols();
            foreach (EN_Rol rol in RolResponse.Rbody)
            {
                if (rol.status == 0)
                    rol.statusString = "Inactivo";
                else
                    rol.statusString = "Activo";
                addRolToCollection(rol);
            }

        }

        private void UpdateUsuario(GlobalEnum.Action Action, EN_User product)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addUsuariosToCollection(product);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateUserToColection(product);
        }

        private void UpdateRol(GlobalEnum.Action Action, EN_Rol rol)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addRolToCollection(rol);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateRolToColection(rol);
        }

        private async Task getAllGafetes()
        {

            var gafeteResponse = await RN_Gafete.getAllGafete();

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

        private void addRolToCollection(EN_Rol rol)
        {
            Rol.Add(rol);

            _getAllRol = getAllRol;
        }
        private void addUsuariosToCollection(EN_User usuario)
        {
            Usuarios.Add(usuario);
        }

        private void addGafeteToCollection(EN_Gafete gafete)
        {
            Gafetes.Add(gafete);
        }

        private void updateUserToColection(EN_User user)
        {
            EN_User encontrado = Usuarios.FirstOrDefault(usuario => usuario.id == user.id);

            encontrado.UserName = user.UserName;
            encontrado.idRol = user.idRol;
            encontrado.RolName = user.RolName;
            encontrado.Password = user.Password;

        }
        private void updateRolToColection(EN_Rol rol)
        {

            EN_Rol encontrado = Rol.FirstOrDefault(r => r.id == rol.id);

            if (encontrado != null)
            {
                encontrado.RolName = rol.RolName;
            }

        }

    }
}
