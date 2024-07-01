using Entidad;
using Ludoteca.Resources;
using Negocio;
using System.Collections.ObjectModel;
using Resources.Properties;

namespace Ludoteca.ViewModel
{


    public delegate void LoadVisitasTable();
    public delegate void UpdateVisitasTable(GlobalEnum.Action Action, EN_Visita visita);
    public delegate double CalcularTotalVisita(EN_Visita visita);

    public delegate void AddProductoToVisita(EN_ProductosVisita producto, int visitaId);

    public class VisitViewModel
    {
        public ObservableCollection<EN_Visita> Visitas { get; set; }
        public ObservableCollection<EN_Visita> VisitasInmutable { get; set; }

        //Iniciacion de delegados
        public LoadVisitasTable _loadVisitasTable;
        public UpdateVisitasTable _UpdateVisitasTable;
        public CalcularTotalVisita _CalcularTotalVisita;
        public AddProductoToVisita _AddProductoToVisita;

        public VisitViewModel() {

            Visitas = new ObservableCollection<EN_Visita>();
            VisitasInmutable = new ObservableCollection<EN_Visita>();

            //Asignacin de delegados
            _loadVisitasTable = loadVisitasTable;
            _UpdateVisitasTable = UpdateVisitasTable;
            _CalcularTotalVisita = calcularTotalVisita;

            _AddProductoToVisita = addProductoToVisita;

            loadVisitasTable();

        }

        private void TimerCallback(object state)
        {
            EN_Visita visita = (EN_Visita)state;

            double PrecioxMinuto = ApplicationProperties.precioXMinute;

            // Actualiza el tiempo restante y realiza otras operaciones según sea necesario
            DateTime now = DateTime.Now;
            TimeSpan TiempoTranscurrido = now - visita.HoraEntrada;

            int totalTiempo = visita.Servicios.Sum(servicio => servicio.Tiempo);

            //Validar si el tiempo transcurrido es menor al tiempo acordado
            if ((int)TiempoTranscurrido.TotalMinutes <= totalTiempo)
            {
                visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
                Console.WriteLine($"Tiempo restante para el elemento {visita.id}: {visita.TiempoTranscurrido} Minutos");
            }
            else
            {
                int tiempoExcedente = (int)TiempoTranscurrido.TotalMinutes - totalTiempo;
                visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
                visita.Total =0;
                visita.Total += (PrecioxMinuto*tiempoExcedente) + calcularTotalVisita(visita);
                visita.TiempoExcedido = tiempoExcedente;
            }
        }

        private void UpdateVisitasTable(GlobalEnum.Action Action, EN_Visita visita)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addVisitaToCollection(visita);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateVisitaToColection(visita);
            if (Action == GlobalEnum.Action.REMOVER)
                removerVisitaActiva(visita);
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

        private void addProductoToVisita(EN_ProductosVisita producto,int visitaId)
        {
            EN_Visita Encontrado = Visitas.FirstOrDefault(p => p.id == visitaId);

            Encontrado.Productos.Add(producto);

        }

        private double calcularTotalVisita(EN_Visita visita)
        {
            double totalVisita = 0;
            
            foreach (EN_ServiciosVisita servicio in visita.Servicios)
            {
                totalVisita += Math.Round(servicio.Servicio_Precio);
            }

            foreach (EN_ProductosVisita produc in visita.Productos)
            {
                totalVisita += Math.Round(produc.precioProductoVisita);
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

        private void removerVisitaActiva(EN_Visita visita)
        {

            EN_Visita Encontrado = Visitas.FirstOrDefault(p => p.id == visita.id);

            if (Encontrado != null)
            {
                Visitas.Remove(Encontrado);
                VisitasInmutable.Remove(Encontrado);
            }
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
