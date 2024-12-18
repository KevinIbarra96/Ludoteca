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
    EN_Response<EN_Menu> menuSelectedResponse = new EN_Response<EN_Menu>();

    EN_Rol RolActualizando;
    List<EN_Menu> menuSelected;

    public RolMenuPopup(UpdateRolConfig updateRolConfig)
	{
		InitializeComponent();
        getValues();

        RolNamelbl.Text = "Nuevo Rol";

        _updateRolConfig = updateRolConfig;

        BtnGuardar.Clicked += BtnGuardar_Clicked;
        MenuCollectionView.SelectionChanged += MenuCollectionView_SelectionChanged;
    }

    public RolMenuPopup(UpdateRolConfig updateRolConfig, EN_Rol rol)
    {
        InitializeComponent();
      
        menuSelected = new List<EN_Menu>();
        RolActualizando = rol;
        getValues();
               
        RolNamelbl.Text = rol.RolName;
        RolNameEntry.Text = rol.RolName;

        _updateRolConfig = updateRolConfig;

        BtnGuardar.Clicked += BtnGuardarActualizar_Clicked;
        //MenuCollectionView.SelectionChanged += MenuCollectionViewActualizando_SelectionChanged;


    }

    private async void getValues()
    {
        await getAllActiveMenu();
        if (RolActualizando != null)
            getMenuByRol(RolActualizando.id);
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
            menuSelectedResponse = await RN_Menu.RN_GetMenuByRol(idRol);

            if (menuSelectedResponse.Rcode == 200)
            {
                IList<object> MenuListInterface = [.. menuSelectedResponse.Rbody];
                //MenuCollectionView.SelectedItems = MenuListInterface;
                
                foreach (EN_Menu s in menuSelectedResponse.Rbody)
                {
                    menuSelected.Add(s);
                }

                MenuSelectedPaint();

            }
            else
            {
                await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + menuSelectedResponse.Rmessage, "OK");
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + ex.Message, "OK");
        }
    }

    //Este metodo quedo exclusivo para el caso de agregar un nuevo rol
    private void MenuCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        foreach (EN_Menu menu in e.PreviousSelection)
        {
            menu.SelectedBackgroundColor = "White"; // Restablecer color
        }

        // Selecci�n de nuevos elementos
        foreach (EN_Menu menu in e.CurrentSelection)
        {
            menu.SelectedBackgroundColor = "#40E1E1E1"; // Marcar visualmente

        }
    }

    //Este metodo quedo exclusivopara el caso de actualizar un rol

    private void MenuSeletectedPaint(EN_Menu menuFromCVSelected)
    {

        if (menuSelected.Count == 0)
        {
            menuSelected.Add(menuFromCVSelected);
            MenuSelectedPaint();
            return;
        }
        
        var menuEncontrado = menuSelected.FirstOrDefault(m => m.id == menuFromCVSelected.id);
        if(menuEncontrado == null)
            menuSelected.Add(menuFromCVSelected);
        else
            menuSelected.Remove(menuEncontrado);        

        MenuSelectedPaint();
    } 

    private void MenuSelectedPaint()
    {
        var activeMenus = MenuCollectionView.ItemsSource.OfType<EN_Menu>().ToList();
        // Actualizar el estado de selecci�n de cada men�        
        foreach (var menu in activeMenus)
        {
            if (menuSelected.Any(selected => selected.id == menu.id))
            {
                menu.SelectedBackgroundColor = "#40E1E1E1"; // Cambia el color seg�n sea necesario
            }
            else
            {
                menu.SelectedBackgroundColor = "White";

            }
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

            if (!string.IsNullOrEmpty(nuevoRol.RolName) && MenuList.Count >= 1)
            {
                await RN_Rol.RN_AddNewRol(nuevoRol, MenuList);


                _updateRolConfig(GlobalEnum.Action.CREAR_NUEVO, nuevoRol);

            /*var toast = Toast.Make("Nuevo Rol Creado correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();*/

                await MopupService.Instance.PopAsync();
            }
            else
            {
                await DisplayAlert("Alerta", "El Nombre de Rol est� vacio o la lista est� vac�a", "OK");
            }

            

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
            nuevoRol.status = 1;
            nuevoRol.id = RolActualizando.id;
            nuevoRol.statusString = "Activo";

            if(!string.IsNullOrEmpty(nuevoRol.RolName) && menuSelected.Count >= 1 )
            {
                var response = await RN_Rol.RN_UpdateRol(nuevoRol, menuSelected);
                if (response.Rcode != 200) throw new Exception(response.Rmessage);


                _updateRolConfig(GlobalEnum.Action.ACTUALIZAR, nuevoRol);
              
            /*var toast = Toast.Make("Nuevo Rol Creado correctamente", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
            await toast.Show();*/

                await MopupService.Instance.PopAsync();
            }
            else
            {
                await DisplayAlert("Alerta", "El Nombre de Rol est� vacio o la lista est� vac�a", "OK");
            }
            

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

    private void MenuCollection_Tapped(object sender, TappedEventArgs e)
    {
        if (RolActualizando == null)
            return;

        StackLayout btn = sender as StackLayout;
        var Menu = btn.BindingContext as EN_Menu;
        
        MenuSeletectedPaint(Menu);
    }
}