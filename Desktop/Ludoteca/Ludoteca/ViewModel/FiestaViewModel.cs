using Data;
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

    public delegate Task LoadFiestasTable();
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

        private async Task loadFiestaTable()
        {
            fiestasInmutable.Clear();
            fiestas.Clear();
            EN_Response<EN_Fiesta> fiestasl = await RN_Fiesta.RN_GetAllActiveFiestas();
            var turno = await RN_Turno.RN_GetAllActiveTurno();

            foreach (var fiesta in fiestasl.Rbody)
            {
                EN_Turno t = turno.Rbody.First(x => x.id == fiesta.IdTurno);
                fiesta.Turno = t.NombreTurno;

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

        private void updateFiestaToColection(EN_Fiesta nuevaFiesta)
        {
            EN_Fiesta Encontrado = fiestas.FirstOrDefault(s => s.id == nuevaFiesta.id);

            if (Encontrado != null)
            {
                Encontrado.Padre = nuevaFiesta.Padre;
                Encontrado.Fecha = nuevaFiesta.Fecha;
                Encontrado.IdServicio = nuevaFiesta.IdServicio;
                Encontrado.Servicio = nuevaFiesta.Servicio;
                Encontrado.Hijo = nuevaFiesta.Hijo;
                Encontrado.Tematica = nuevaFiesta.Tematica;
                Encontrado.EdadACumplir = nuevaFiesta.EdadACumplir;
                Encontrado.IdTurno = nuevaFiesta.IdTurno;
                Encontrado.Turno = nuevaFiesta.Turno;
                Encontrado.TipoComida = nuevaFiesta.TipoComida;
                Encontrado.NinosAdicionales = nuevaFiesta.NinosAdicionales;
                Encontrado.Anticipo = nuevaFiesta.Anticipo;
                Encontrado.Total = nuevaFiesta.Total;
            }
        }

    }
}
