using Ludoteca.Resources;
using Ludoteca.ViewModel;

namespace Ludoteca.PopUp;

public partial class OfertaPopup
{

    UpdateOfertasTable _UpdateOfertaTable;

    public OfertaPopup(UpdateOfertasTable updateOfertasTable)
    {
        InitializeComponent();

        //BtnGuardar.Clicked += BtnGuardarNuevo_Clicked;
        ServicioNamelbl.Text = "Nuevo Servicio";

        _UpdateOfertaTable = updateOfertasTable;

        //getTipoServicio(GlobalEnum.Action.CREAR_NUEVO, 0);
    }

    public OfertaPopup()
	{
		InitializeComponent();
	}
}