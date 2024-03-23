using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad 
{
    public class EN_Visita : INotifyPropertyChanged
    {
        public int id { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida  {  get; set; }
        public int Oferta {  get; set; }
        public string OfertaName {  get; set; }
        public List<EN_Hijo>? Hijos { get; set; }
        public List<EN_ServiciosVisita>? Servicios { get; set; }
        public List<EN_Padre>? Padres {  get; set; }
        public List<EN_ProductosVisita>? Productos { get; set; }
        public int Total {  get; set; }

        private int _tiempoTranscurrido;

        public int TiempoTranscurrido
        {
            get { return _tiempoTranscurrido; }
            set
            {
                if (_tiempoTranscurrido != value)
                {
                    _tiempoTranscurrido = value;
                    OnPropertyChanged(nameof(TiempoTranscurrido));
                }
            }
        }
        public Timer? Timer { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
