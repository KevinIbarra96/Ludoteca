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

    public delegate void AddProductoToVisita(GlobalEnum.Action action, EN_ProductosVisita producto, int visitaId);
    public delegate void AddServicioToVisita(EN_ServiciosVisita servicio, int visitaId);

    public class VisitViewModel
    {
        public ObservableCollection<EN_Visita> Visitas { get; set; }
        public ObservableCollection<EN_Visita> VisitasInmutable { get; set; }
        
        //Iniciacion de delegados
        public LoadVisitasTable _loadVisitasTable;
        public UpdateVisitasTable _UpdateVisitasTable;
        public CalcularTotalVisita _CalcularTotalVisita;
        public AddProductoToVisita _AddProductoToVisita;
        public AddServicioToVisita _addServicioToVIsita;

        public VisitViewModel() {

            Visitas = new ObservableCollection<EN_Visita>();
            VisitasInmutable = new ObservableCollection<EN_Visita>();

            //Asignacin de delegados
            _loadVisitasTable = loadVisitasTable;
            _UpdateVisitasTable = UpdateVisitasTable;
            _CalcularTotalVisita = calcularTotalVisita;

            _AddProductoToVisita = addProductoToVisita;
            _addServicioToVIsita = addServicioToVisita;
            

            loadVisitasTable();

        }

        private void TimerCallback(object state)
        {
            EN_Visita visita = (EN_Visita)state;

            double PrecioxMinuto = (double)ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue;
            double TotalPrecioExcedente = 0;

            // Actualiza el tiempo restante y realiza otras operaciones según sea necesario
            DateTime now = DateTime.Now;
            TimeSpan TiempoTranscurrido = now - visita.HoraEntrada;

            int totalTiempoServicios = visita.Servicios.Sum(servicio => servicio.Tiempo);

            //Validar si el tiempo transcurrido es menor al tiempo acordado
            if ((int)TiempoTranscurrido.TotalMinutes <= totalTiempoServicios)
            {
                visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
                Console.WriteLine($"Tiempo restante para el elemento {visita.id}: {visita.TiempoTranscurrido} Minutos");
            }
            else
            {
                int tiempoExcedente = (int)TiempoTranscurrido.TotalMinutes - totalTiempoServicios;

                //Considerar el numero de hijos para los tiemposExcedentes
                tiempoExcedente *= visita.Hijos.Count;

                /*TODO Calculo para manejar el tiempo de las ofertas cuando se habla por tiempo.
                if (tiempoExcedente > 0 && tiempoExcedente > visita.Oferta.FirstOrDefault().Tiempo)
                    TotalPrecioExcedente = PrecioxMinuto * (tiempoExcedente - visita.Oferta.FirstOrDefault().Tiempo);*/

                //Cuando no tiene un servicio se maneja el servicio por defalut "Sin Servicio que se configura en ApplicationProperties"

                visita.TiempoTranscurrido = Math.Abs((int)TiempoTranscurrido.TotalMinutes);
                visita.Total = 0;
                visita.Total += TotalPrecioExcedente + calcularTotalVisita(visita);

                if (ApplicationProperties.IdTiempoLibreServicio == visita.Servicios.First().Servicio_Id)
                {
                    if (visita.TiempoTranscurrido <= 35)
                        visita.Total += (double)(ApplicationProperties.PrecioMinutoTreintaMin.ConfigDecimalValue * (visita.TiempoTranscurrido * visita.Hijos.Count));
                    else
                        visita.Total += (double)(ApplicationProperties.PrecioMinutoSesentaMin.ConfigDecimalValue * (visita.TiempoTranscurrido * visita.Hijos.Count));
                }
                else
                {
                    visita.Total += (double)(ApplicationProperties.PrecioMinutoDespuesServicio.ConfigDecimalValue * tiempoExcedente * visita.Hijos.Count);
                }

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
                visita.Timer = new Timer(TimerCallback, visita, 0, 15000);
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

        private void addProductoToVisita(GlobalEnum.Action action ,EN_ProductosVisita producto,int visitaId)
        {

            EN_Visita Encontrado = getVisitaByID(visitaId);

            if (GlobalEnum.Action.CREAR_NUEVO == action)
                Encontrado.Productos.Add(producto);
            if (GlobalEnum.Action.ACTUALIZAR == action)
            {
                Encontrado.Productos.First().id_Producto = producto.id_Producto;
                Encontrado.Productos.First().ProductoName = producto.ProductoName;
                Encontrado.Productos.First().CantidadProductoVisita = producto.CantidadProductoVisita;
                Encontrado.Productos.First().precioProductoVisita = producto.precioProductoVisita;
                Encontrado.Productos.First().CantidadProducto = $"({producto.CantidadProductoVisita}) {producto.ProductoName}";
            }

        }
        

        private void addServicioToVisita(EN_ServiciosVisita servicio,int visitaId)
        {

            EN_Visita Encontrado = getVisitaByID(visitaId);

            Encontrado.Servicios.Add(servicio);
        }

        private double calcularTotalVisita(EN_Visita visita)
        {
            double totalVisita = 0;
            
            foreach (EN_ServiciosVisita servicio in visita.Servicios)
            {
                //totalVisita += Math.Round(servicio.Servicio_Precio);
                totalVisita += (Math.Round(servicio.Servicio_Precio) * visita.Hijos.Count);
            }

            foreach (EN_ProductosVisita produc in visita.Productos)
            {
                totalVisita += Math.Round(produc.precioProductoVisita * produc.CantidadProductoVisita);
            }

            /*foreach (EN_Oferta ofer in visita.Oferta)
            {
                totalVisita -= Math.Round(ofer.totalDescuento);
            }*/

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
            EN_Visita Encontrado = getVisitaByID(visita.id);

            if (Encontrado != null)
            {
                //TODO necesitamos implementar los cambios para actualizar.
            }
        }

        private EN_Visita getVisitaByID(int visitaId)
        {
           return Visitas.FirstOrDefault(p => p.id == visitaId);
        }

    }
}
