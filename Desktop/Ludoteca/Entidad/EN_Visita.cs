using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad 
{
    public class EN_Visita : INotifyPropertyChanged
    {
        public int id { get; set; }
        private DateTime _HoraEntrada;

        private int _gafeteId;
        
        public int GafeteId
        {
            get { return _gafeteId; }
            set { if (_gafeteId != value) { _gafeteId = value; OnPropertyChanged(nameof(GafeteId)); } }
        }

        private int _numeroGafete;

        public int NumeroGafete
        {
            get { return _numeroGafete; }
            set { if (_numeroGafete != value) { _numeroGafete = value; OnPropertyChanged(nameof(NumeroGafete)); } }
        }

        public DateTime HoraEntrada
        {
            get {  return _HoraEntrada; }
            set {
                if (_HoraEntrada != value)
                {
                    _HoraEntrada = value;
                    OnPropertyChanged(nameof(HoraEntrada));
                }
            }
        }
        private DateTime? _HoraSalida;
        
        public DateTime? HoraSalida
        {
            get { return _HoraSalida; }
            set
            {
                if (_HoraSalida != value)
                {
                    _HoraSalida = value;
                    OnPropertyChanged(nameof(HoraSalida));
                }
            }
        }

        private List<EN_Oferta> _Oferta;

        public List<EN_Oferta> Oferta
        {
            get { return _Oferta; }
            set
            {
                if (_Oferta != value)
                {
                    _Oferta = value;
                    OnPropertyChanged(nameof(Oferta));
                }
            }
        }

        /*private int _Oferta;
        
        public int Oferta
        {
            get { return _Oferta; }
            set
            {
                if (_Oferta != value)
                {
                    _Oferta = value;
                    OnPropertyChanged(nameof(Oferta));
                }
            }
        }
        private string _OfertaName;
        public string OfertaName
        {
            get { return _OfertaName; }
            set
            {
                if (_OfertaName != value)
                {
                    _OfertaName = value;
                    OnPropertyChanged(nameof(OfertaName));
                }
            }
        }*/


        public List<EN_Hijo>? Hijos { get; set; }

        private ObservableCollection<EN_ServiciosVisita>? _servicios;
        public ObservableCollection<EN_ServiciosVisita>? Servicios 
        {
            get => _servicios;
            set { _servicios = value; OnPropertyChanged(nameof(Servicios)); } 
        }
        public List<EN_Padre>? Padres {  get; set; }

        public ObservableCollection<EN_ProductosVisita>? _productos;
        public ObservableCollection<EN_ProductosVisita>? Productos 
        { 
            get { return _productos; }
            set { _productos = value; OnPropertyChanged(nameof(Productos)); }
        }

        private double _Total;
        public double Total
        {
            get { return _Total; }
            set
            {
                if (_Total != Math.Round(value, 2))
                {
                    _Total = Math.Round(value, 2);
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

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

        private int _tiempoExcedido;

        public int TiempoExcedido
        {
            get { return _tiempoExcedido; }
            set
            {
                if (_tiempoExcedido != value)
                {
                    _tiempoExcedido = value;
                    OnPropertyChanged(nameof(TiempoExcedido));
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
