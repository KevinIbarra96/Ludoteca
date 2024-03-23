using Entidad;
using Ludoteca.Resources;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.ViewModel
{


    public delegate void LoadVisitasTable();
    public delegate void UpdateVisitasTable(GlobalEnum.Action Action, EN_Visita visita);

    public class VisitViewModel
    {
        public ObservableCollection<EN_Visita> Visitas { get; set; }
        public ObservableCollection<EN_Visita> VisitasInmutable { get; set; }

        //Iniciacion de delegados
        public LoadVisitasTable _loadVisitasTable;
        public UpdateVisitasTable _UpdateVisitasTable;

        public VisitViewModel() {

            Visitas = new ObservableCollection<EN_Visita>();
            VisitasInmutable = new ObservableCollection<EN_Visita>();

            //Asignacin de delegados
            _loadVisitasTable = loadVisitasTable;
            _UpdateVisitasTable = UpdateVisitasTable;

            loadVisitasTable();

        }

        private void TimerCallback(object state)
        {
            EN_Visita visita = (EN_Visita)state;

            // Actualiza el tiempo restante y realiza otras operaciones según sea necesario
            DateTime now = DateTime.Now;
            TimeSpan TiempoTranscurrido = now - visita.HoraEntrada;

            if (visita.TiempoTranscurrido <= 0)
            {
                // Detén el temporizador si es necesario
                visita.Timer.Dispose();
                Console.WriteLine($"¡Tiempo terminado para el elemento {visita.id}!");
            }
            else
            {
                // Realiza otras acciones según sea necesario
                visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
                Console.WriteLine($"Tiempo restante para el elemento {visita.id}: {visita.TiempoTranscurrido} Minutos");
            }
        }

        private void UpdateVisitasTable(GlobalEnum.Action Action, EN_Visita visita)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addVisitaToCollection(visita);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateVisitaToColection(visita);
        }

        //Metodo destinado para limpiar y recargar la informacion de la tabla desde el inicio.
        private async void loadVisitasTable()
        {
            VisitasInmutable.Clear();
            Visitas.Clear();

            var visitasResponse = await RN_Visita.RN_getAllVisitasActivas();

            foreach (var visita in visitasResponse.Rbody)
            {
                visita.Timer = new Timer(TimerCallback, visita, 0, 20000);
                visita.Total = calcularTotalVisita(visita);
                visita.TiempoTranscurrido = calcularTiempoRestanteVisita(visita);
                addVisitaToCollection(visita);
            }
        }

        private void addVisitaToCollection(EN_Visita visita)
        {
            Visitas.Add(visita);
            VisitasInmutable.Add(visita);
        }

        private int calcularTotalVisita(EN_Visita visita)
        {
            int totalVisita = 0;
            
            foreach (EN_ServiciosVisita servicio in visita.Servicios)
            {
                totalVisita += servicio.Servicio_Precio;
            }

            foreach (EN_ProductosVisita produc in visita.Productos)
            {
                totalVisita += produc.precioProductoVisita;
            }

            return totalVisita;
        }

        private int calcularTiempoRestanteVisita(EN_Visita visita)
        {
            int TiempoRestante = 0;

            foreach (EN_ServiciosVisita servicio in visita.Servicios)
            {
                TiempoRestante += servicio.Tiempo;
            }

            return TiempoRestante;
        }

        private void updateVisitaToColection(EN_Visita visita)
        {
            EN_Visita Encontrado = Visitas.FirstOrDefault(p => p.id == visita.id);

            if (Encontrado != null)
            {
                //TODO necesitamos implementar los cambios para actualizar.
            }
        }

    }
}
