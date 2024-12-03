using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class UsuarioRolPopup
{

    UpdateUsuarioConfig _updateUsuarioConfig;

    List<EN_Rol> rolesList = new List<EN_Rol>();

    public UsuarioRolPopup(UpdateUsuarioConfig updateUsuarioConfig, EN_User usuario)
    {
        InitializeComponent();
        getRoles(GlobalEnum.Action.ACTUALIZAR, usuario.idRol);

        BtnGuardar.Clicked += BtnGuardarActualizr_Clicked;
        IdUsuarioEntry.Text = usuario.id.ToString();
        UsuarioNamelbl.Text = usuario.UserName;
        UsuarioNameEntry.Text = usuario.UserName;
        ContrasenaEntry.Text = usuario.Password;

        _updateUsuarioConfig = updateUsuarioConfig;

    }
    public UsuarioRolPopup(UpdateUsuarioConfig updateUsuarioConfig)
    {
        InitializeComponent();

        BtnGuardar.Clicked += BtnGuardar_Clicked;
        UsuarioNamelbl.Text = "Nuevo Usuario";

        getRoles(GlobalEnum.Action.CREAR_NUEVO, 0);

        _updateUsuarioConfig = updateUsuarioConfig;

    }

    private async void getRoles(GlobalEnum.Action action, int idRol)
    {
        EN_Response<EN_Rol> rolResponse = await RN_Rol.RN_GetAllActiveRols();
        rolesList = rolResponse.Rbody;

        picker.ItemsSource = rolesList;
        picker.ItemDisplayBinding = new Binding("RolName");

        if (GlobalEnum.Action.ACTUALIZAR == action)
            picker.SelectedItem = rolesList.FirstOrDefault(rol => rol.id == idRol);

    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private async void BtnGuardarActualizr_Clicked(object sender, EventArgs e)
    {
        try
        {
            var pick = (EN_Rol)picker.SelectedItem;
            var usuario = new EN_User() { id = int.Parse(IdUsuarioEntry.Text), UserName = UsuarioNameEntry.Text, Password = ContrasenaEntry.Text, idRol = pick.id, RolName = pick.RolName };

            await RN_Users.RN_UpdateUser(usuario);

            _updateUsuarioConfig(GlobalEnum.Action.ACTUALIZAR, usuario);

            var toast = Toast.Make("Actualizacion de " + usuario.UserName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            MopupService.Instance.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error en el proceso de guardado\nDetalle: " + ex.Message, "Ok");
        }
    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var pick = (EN_Rol)picker.SelectedItem;

            var usuario = new EN_User() { UserName = UsuarioNameEntry.Text, Password = ContrasenaEntry.Text, idRol = pick.id, RolName = pick.RolName, statusString = "Activo" };
            EN_Response<EN_User> resp = await RN_Users.RN_AddNewUser(usuario);

            usuario.id = resp.Rbody[0].id;

            _updateUsuarioConfig(GlobalEnum.Action.CREAR_NUEVO, usuario);

            var toast = Toast.Make("Se agregó el " + usuario.UserName + " correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();

            MopupService.Instance.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error en el proceso de guardado\nDetalle: " + ex.Message, "Ok");
        }
    }
}