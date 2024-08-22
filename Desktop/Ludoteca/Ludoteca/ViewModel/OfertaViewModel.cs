using Entidad;
using Negocio;
using Ludoteca.Resources;
using System.Collections.ObjectModel;

namespace Ludoteca.ViewModel
{

    public delegate void LoadOfertasTable();
    public delegate void UpdateOfertasTable(GlobalEnum.Action Action, EN_Oferta ofertas);

    class OfertaViewModel
    {
        public ObservableCollection<EN_Oferta> ofertas { get; set; }
        public ObservableCollection<EN_Oferta> ofertasInmutable { get; set; }

        public LoadOfertasTable _loadOfertasTable;
        public UpdateOfertasTable _UpdateOfertasTable;


        public OfertaViewModel()
        {
            ofertas = new ObservableCollection<EN_Oferta>();
            ofertasInmutable = new ObservableCollection<EN_Oferta>();

            //Asignacin de delegados
            _loadOfertasTable = loadOfertaTable;
            _UpdateOfertasTable = UpdateOfertaTable;

            loadOfertaTable();
        }

        private async void loadOfertaTable()
        {
            ofertasInmutable.Clear();
            ofertas.Clear();
            EN_Response<EN_Oferta> ofertasl = await RN_Oferta.RN_GetAllActiveOfertas();


            foreach (var oferta in ofertasl.Rbody)
            {
                addOfertaToCollection(oferta);
            }
        }

        private void UpdateOfertaTable(GlobalEnum.Action Action, EN_Oferta oferta)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addOfertaToCollection(oferta);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateOfertaToColection(oferta);
        }

        private void addOfertaToCollection(EN_Oferta oferta)
        {
            ofertas.Add(oferta);
            ofertasInmutable.Add(oferta);
        }

        private void updateOfertaToColection(EN_Oferta oferta)
        {
            EN_Oferta Encontrado = ofertas.FirstOrDefault(s => s.id == oferta.id);

            if (Encontrado != null)
            {
                Encontrado.OfertaName = oferta.OfertaName;
                Encontrado.Descripcion = oferta.Descripcion;
                Encontrado.totalDescuento = oferta.totalDescuento;
                Encontrado.Tiempo = oferta.Tiempo;
            }
        }

    }    

}

