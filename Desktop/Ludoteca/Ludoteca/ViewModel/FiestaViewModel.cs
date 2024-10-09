using Entidad;
using Ludoteca.Resources;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.ViewModel
{

    public delegate void LoadFiestasTable();
    public delegate void UpdateFiestasTable(GlobalEnum.Action Action, EN_Fiesta fiestas);

    internal class FiestaViewModel
    {

        public ObservableCollection<EN_Fiesta> fiestas { get; set; }
        public ObservableCollection<EN_Fiesta> fiestasInmutable { get; set; }

        public LoadFiestasTable _loadFiestasTable;
        public UpdateFiestasTable _UpdateFiestasTable;

        public FiestaViewModel()
        {
            fiestas = new ObservableCollection<EN_Fiesta>();
            fiestasInmutable = new ObservableCollection<EN_Fiesta>();

            //Asignacin de delegados
            _loadFiestasTable = loadFiestaTable;
            _UpdateFiestasTable = UpdateFiestaTable;

            loadFiestaTable();

        }

        private async void loadFiestaTable()
        {
            fiestasInmutable.Clear();
            fiestas.Clear();
            EN_Response<EN_Fiesta> fiestasl = await RN_Fiesta.RN_GetAllActiveFiestas();


            foreach (var fiesta in fiestasl.Rbody)
            {
                addFiestaToCollection(fiesta);
            }
        }

        private void UpdateFiestaTable(GlobalEnum.Action Action, EN_Fiesta fiesta)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addFiestaToCollection(fiesta);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateFiestaToColection(fiesta);
        }

        private void addFiestaToCollection(EN_Fiesta fiesta)
        {
            fiestas.Add(fiesta);
            fiestasInmutable.Add(fiesta);
        }

        private void updateFiestaToColection(EN_Fiesta fiesta)
        {
            EN_Fiesta Encontrado = fiestas.FirstOrDefault(s => s.id == fiesta.id);

            if (Encontrado != null)
            {

            }
        }

    }
}
