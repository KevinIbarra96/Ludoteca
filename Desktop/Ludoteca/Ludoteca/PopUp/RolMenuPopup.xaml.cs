using CommunityToolkit.Maui.Alerts;
using Entidad;
using Ludoteca.Resources;
using Ludoteca.ViewModel;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class RolMenuPopup
{

    UpdateRolConfig _updateRolConfig;

    public RolMenuPopup(UpdateRolConfig updateRolConfig)
    {
        InitializeComponent();
        getAllActiveMenu();

        RolNamelbl.Text = "Nuevo Rol";

        _updateRolConfig = updateRolConfig;

        BtnGuardar.Clicked += BtnGuardar_Clicked;
    }

    public RolMenuPopup(UpdateRolConfig updateRolConfig, EN_Rol rol)
    {
        InitializeComponent();
        getAllActiveMenu();
        getMenuByRol(rol.id);


        RolNamelbl.Text = rol.RolName;
        RolNameEntry.Text = rol.RolName;

        _updateRolConfig = updateRolConfig;

        BtnGuardar.Clicked += BtnGuardarActualizar_Clicked;

    }


    private async Task getAllActiveMenu()
    {
        try
        {
            EN_Response<EN_Menu> menuResponse = await RN_Menu.getAllActiveMenu();
            MenuCollectionView.ItemsSource = menuResponse.Rbody;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    private async void getMenuByRol(int idRol)
    {
        try
        {
            //await getAllActiveMenu();
            EN_Response<EN_Menu> menuResponse = await RN_Menu.RN_GetMenuByRol(idRol);

            if (menuResponse.Rcode == 200)
            {
                IList<object> MenuListInterface = [.. menuResponse.Rbody];

                MenuCollectionView.SelectedItems = MenuListInterface;
            }
            else
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + menuResponse.Rmessage, "OK");
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }


    private void MenuCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (EN_Menu menu in e.PreviousSelection)
        {
            menu.SelectedBackgroundColor = "White";
        }

        foreach (EN_Menu menu in e.CurrentSelection)
        {
            menu.SelectedBackgroundColor = "#40E1E1E1";

        }

    }

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            EN_Rol nuevoRol = new EN_Rol();
            nuevoRol.RolName = RolNameEntry.Text;
            nuevoRol.statusString = "Activo";

            List<EN_Menu> MenuList = MenuCollectionView.SelectedItems.OfType<EN_Menu>().ToList();

            await RN_Rol.RN_AddNewRol(nuevoRol, MenuList);


            _updateRolConfig(GlobalEnum.Action.CREAR_NUEVO, nuevoRol);

            /*var toast = Toast.Make("Nuevo Rol Creado correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();*/

            await MopupService.Instance.PopAsync();

        }
        catch (NullReferenceException invalidCastException)
        {
            await DisplayAlert("Error", "Por favor verifica que todos los datos esten correctos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }

    }

    private async void BtnGuardarActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            EN_Rol nuevoRol = new EN_Rol();
            nuevoRol.RolName = RolNameEntry.Text;
            nuevoRol.statusString = "Activo";

            List<EN_Menu> MenuList = MenuCollectionView.SelectedItems.OfType<EN_Menu>().ToList();

            await RN_Rol.RN_UpdateRol(nuevoRol, MenuList);


            _updateRolConfig(GlobalEnum.Action.ACTUALIZAR, nuevoRol);

            /*var toast = Toast.Make("Nuevo Rol Creado correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();*/

            await MopupService.Instance.PopAsync();

        }
        catch (NullReferenceException invalidCastException)
        {
            await DisplayAlert("Error", "Por favor verifica que todos los datos esten correctos", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }

    }

    private void Cancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}