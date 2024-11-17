using CommunityToolkit.Maui.Alerts;
using Entidad;
using Mopups.Services;
using Negocio;
using Resources.Properties;
using System.Linq;

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
        int idPapa = 0;
        int idMama = 0;
        try
        {
            EN_Response<EN_Padre> response = null;

            //EN_Hijo hijo = new EN_Hijo();
            List<EN_Hijo> hijos = new List<EN_Hijo>();
            EN_Padre padre = null;
            EN_Padre madre = null;


            if (validaciones(idPapa, idMama))
            {

                if (ValidarEntry(EntryNombrePapa) && ValidarEntry(EntryNumeroPapa))
                {
                    padre = new EN_Padre();
                    padre.PadreName = EntryNombrePapa.Text;
                    padre.Telefono = EntryNumeroPapa.Text;
                    padre.Address = EditorDireccion.Text;

                    response = await RN_Padre.RN_AddNewPadre(padre);
                    idPapa = response.Rbody[0].id;
                }

                if (ValidarEntry(EntryNombreMama) && ValidarEntry(EntryNumeroMama))
                {
                    madre = new EN_Padre();
                    madre.PadreName = EntryNombreMama.Text;
                    madre.Telefono = EntryNumeroMama.Text;
                    madre.Address = EditorDireccion.Text;

                    response = await RN_Padre.RN_AddNewPadre(madre);
                    idMama = response.Rbody[0].id;
                }
                if (!string.IsNullOrWhiteSpace(EntryNombreHijo.Text) && DateFechaNacimientoHijo.Date != null)
                {
                    if (!ValidarEdad(DateFechaNacimientoHijo.Date))
                    {
                        await DisplayAlert("Advertencia", $"La edad no es válida. Debe estar entre el rango permitido.\nEdad mínima: {ApplicationProperties.edadMinima.ConfigIntValue} años\nEdad máxima: {ApplicationProperties.edadMaxima.ConfigIntValue} años", "OK");
                        return;
                    }

                    EN_Hijo hijo = new EN_Hijo
                    {
                        NombreHijo = EntryNombreHijo.Text,
                        fechaNac = DateFechaNacimientoHijo.Date.ToString(),
                        papa = idPapa,
                        mama = idMama
                    };
                    hijos.Add(hijo);
                }

                foreach (var hijoLayout in HijosStackLayout.Children)
                {
                    if (hijoLayout is VerticalStackLayout layout)
                        {
                        var nombreEntry = layout.Children.OfType<Entry>().FirstOrDefault();
                        var fechaDatePicker = layout.Children.OfType<HorizontalStackLayout>()
                            .FirstOrDefault()?.Children.OfType<DatePicker>().FirstOrDefault();


                        if (nombreEntry != null && !string.IsNullOrWhiteSpace(nombreEntry.Text) && fechaDatePicker != null)
                        {
                            if (!ValidarEdad(fechaDatePicker.Date))
                            {
                                await DisplayAlert("Advertencia", $"La edad no es válida. Debe estar entre el rango permitido.\nEdad mínima: {ApplicationProperties.edadMinima.ConfigIntValue} años\nEdad máxima: {ApplicationProperties.edadMaxima.ConfigIntValue} años", "OK");
                                return;
                            }
                                

                                EN_Hijo hijo = new EN_Hijo
                                {
                                    NombreHijo = nombreEntry.Text,
                                    fechaNac = fechaDatePicker.Date.ToString(),
                                    papa = idPapa,
                                    mama = idMama
                                };
                                hijos.Add(hijo); // Añadir cada hijo a la lista
                            } 
                        }
                }
                

                foreach (var hijo in hijos)
                {
                    EN_Response<EN_Hijo> hijoResponse = await RN_Hijo.RN_AddNewHijo(hijo);
                    if (hijoResponse != null && hijoResponse.Rcode == 200)
                    {
                        var toast = Toast.Make("Registro correcto", CommunityToolkit.Maui.Core.ToastDuration.Short, 30);
                        await toast.Show();
                    }
                    else
                    {
                     await DisplayAlert("Error", "Ha ocurrido un error\nDetalle: " + hijoResponse.Rmessage, "OK");
                    }
                }

                await MopupService.Instance.PopAsync();

            }
            else
            {
                await DisplayAlert("Advertencia", "Verifica que los campos estén correctos. Los campos que no pueden estar vacíos:" +
                    "\n-Al menos la información de un Padre\n-Dirección\n-La fecha de nacimiento", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ha ocurrido un error\nDetalle: " + ex.Message, "OK");
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
    private bool ValidarEdad(DateTime fechaNacimiento)
    {
        int edad = DateTime.Now.Year - fechaNacimiento.Year;
        if (fechaNacimiento.Date > DateTime.Now.AddYears(-edad)) edad--;

        return edad >= ApplicationProperties.edadMinima.ConfigIntValue && edad <= ApplicationProperties.edadMaxima.ConfigIntValue;
    }
    private void OnAddHijoClicked(object sender, EventArgs e)
    {
        // Ocultar el botón actual que ha sido clicado
        var button = sender as Button;
        if (button != null)
        {
            button.IsVisible = false; // Ocultar el botón después de clic
        }

        var hijoLayout = new VerticalStackLayout
        {
            Margin = new Thickness(0, 10, 0, 10)
        };

        // Agregar un nuevo Entry para el nombre del hijo
        var nombreLabel = new Label { Text = "Nombre del hijo" };
        var nombreEntry = new Entry { 
            Placeholder = "Ingrese nombre del hijo",
            WidthRequest = 350,
            HorizontalOptions = LayoutOptions.Start
        };
        
        // Agregar un nuevo DatePicker para la fecha de nacimiento
        var fechaLabel = new Label { Text = "Fecha de nacimiento" };

        // Crear un HorizontalStackLayout para alinear el DatePicker y el nuevo botón
        var fechaYBotonStack = new HorizontalStackLayout
        {
            HorizontalOptions = LayoutOptions.Fill,
            Spacing = 5 // Añadir espacio entre los elementos del Stack horizontal
        };

        // Crear DatePicker y botón adicional
        var fechaNacimientoDatePicker = new DatePicker { HorizontalOptions = LayoutOptions.Start };
        fechaNacimientoDatePicker.DateSelected += OnDateSelected;
        var addButton = new Button
        {
            Text = "+",
            HorizontalOptions = LayoutOptions.End,
            BackgroundColor = Colors.LawnGreen, // Configurar color de fondo
            TextColor = Colors.White,
            Margin = new Thickness(5) // Margen para dar espacio al botón
        };

        // Asignar nuevamente el evento OnAddHijoClicked al nuevo botón
        addButton.Clicked += OnAddHijoClicked;

        // Añadir DatePicker y botón en el HorizontalStackLayout
        fechaYBotonStack.Children.Add(fechaNacimientoDatePicker);
        fechaYBotonStack.Children.Add(addButton);

        // Añadir los controles al layout del hijo
        hijoLayout.Children.Add(nombreLabel);
        hijoLayout.Children.Add(nombreEntry);
        hijoLayout.Children.Add(fechaLabel);
        hijoLayout.Children.Add(fechaYBotonStack); // Añadir el stack con DatePicker y botón

        // Añadir el nuevo StackLayout al StackLayout principal
        HijosStackLayout.Children.Add(hijoLayout);
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime fechaSeleccionada = e.NewDate;

        if (!ValidarEdad(fechaSeleccionada))
        {
            DisplayAlert("Advertencia", $"La edad no es válida. Debe estar entre el rango permitido.\nEdad mínima: {ApplicationProperties.edadMinima.ConfigIntValue} años\nEdad máxima: {ApplicationProperties.edadMaxima.ConfigIntValue} años", "OK");
        }
    }

}