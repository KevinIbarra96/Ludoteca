using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.ViewModel
{
    public delegate void LoadReporteVisitasTable();
    public class ReporteVisitasViewModel
    {
        public ObservableCollection<EN_Visita> Visitas { get; set; }
        public ObservableCollection<EN_Visita> VisitasInmutable { get; set; }

        //Iniciacion de delegados
        public LoadReporteVisitasTable _loadReporteVisitasTable;

        public ReporteVisitasViewModel()
        {
            Visitas = new ObservableCollection<EN_Visita>();
            VisitasInmutable = new ObservableCollection<EN_Visita>();

            //Asignacin de delegados
            _loadReporteVisitasTable = loadReporteVisitasTable;

            loadReporteVisitasTable();


        }
        //Metodo destinado para limpiar y recargar la informacion de la tabla desde el inicio.
        private async void loadReporteVisitasTable()
        {
            VisitasInmutable.Clear();
            Visitas.Clear();

            var visitasResponse = await RN_Visita.RN_getAllVisitasCompleted();
            
            foreach (var visita in visitasResponse.Rbody)
            {
                addVisitaToCollection(visita);
            }
        }
        private void addVisitaToCollection(EN_Visita visita)
        {
            Visitas.Add(visita);
            VisitasInmutable.Add(visita);
        }
        public async Task LoadReporteVisitasByDate(DateTime fecha)
        {
            VisitasInmutable.Clear();
            Visitas.Clear();

            var visitasResponse = await RN_Visita.RN_getVisitaCompleteByDate(fecha);
            foreach (var visita in visitasResponse)
            {
                addVisitaToCollection(visita);
            }
        }
        public async Task LoadReporteVisitasByDateRange(DateTime fechaInicio, DateTime fechaFin)
        {
            Visitas.Clear();
            VisitasInmutable.Clear();

            var visitasPorRango = await RN_Visita.RN_getVisitasCompleteByDateRange(fechaInicio, fechaFin);

            foreach (var visita in visitasPorRango)
            {
                addVisitaToCollection(visita);
            }
        }

    }
}
