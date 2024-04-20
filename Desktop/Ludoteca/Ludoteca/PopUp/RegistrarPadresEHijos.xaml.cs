using CommunityToolkit.Maui.Alerts;
using Entidad;
using Mopups.Services;
using Negocio;

namespace Ludoteca.PopUp;

public partial class RegistrarPadresEHijos
{
	public RegistrarPadresEHijos()
	{
		InitializeComponent();
	}

    private async void BtnGuardar_Clicked(object sender, EventArgs e)
    {

        //id=0 asignar 0 cuando no tiene papa o mama asignado

        try
        {
            EN_Response<EN_Padre> response = null;

            EN_Hijo hijo = new EN_Hijo();
            EN_Padre padre = null;
            EN_Padre madre = null;


            if (validaciones(hijo.papa,hijo.mama))
            {

                if (ValidarEntry(EntryNombrePapa) && ValidarEntry(EntryNumeroPapa))
                {
                    padre = new EN_Padre();
                    padre.PadreName = EntryNombrePapa.Text;
                    padre.Telefono = EntryNumeroPapa.Text;
                    padre.Address = EditorDireccion.Text;

                    response = await RN_Padre.RN_AddNewPadre(padre);
                    hijo.papa = response.Rbody[0].id;
                }

                if (ValidarEntry(EntryNombreMama) && ValidarEntry(EntryNumeroMama))
                {
                    madre = new EN_Padre();
                    madre.PadreName = EntryNombreMama.Text;
                    madre.Telefono = EntryNumeroMama.Text;
                    madre.Address = EditorDireccion.Text;

                    response = await RN_Padre.RN_AddNewPadre(madre);
                    hijo.mama = response.Rbody[0].id;
                }

                hijo.NombreHijo = EntryNombreHijo.Text;
                hijo.fechaNac = DateFechaNacimientoHijo.Date.ToString();

                EN_Response<EN_Hijo> hijoResponse = await RN_Hijo.RN_AddNewHijo(hijo);
                if (hijoResponse.RerrorCode != "0")
                {
                    await MopupService.Instance.PopAsync();

                    var toast = Toast.Make("Registro correcto", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
                    await toast.Show();
                }
                else
                {
                    await DisplayAlert("Error", "Ah ocurrido un error\nDetalle: " + hijoResponse.Rmessage, "OK");
                }
            }

            await DisplayAlert("Advertencia", "Verifica que los campos esten correctos, Los abajo un listado de los campos que no pueden estar vacíos\n-Almenos la informacion de un Papa\n-Direccion\n-La fecha de nacimiento", "OK");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error","Ah ocurrido un error\nDetalle: "+ex.Message,"OK");
        }
    }

    private void BtnCancelar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private bool ValidarEntry(Entry campos)
    {
        if ( string.IsNullOrEmpty(campos.Text) )
        {
            return false;
        }
        return true;
    }

    private bool validaciones(int papaId, int mamaId )
    {
        if ((papaId != null || mamaId != null) && ValidarEntry(EntryNombreHijo) && !string.IsNullOrEmpty(EditorDireccion.Text) ) {
            return true;
        }
        return false;
    }

}