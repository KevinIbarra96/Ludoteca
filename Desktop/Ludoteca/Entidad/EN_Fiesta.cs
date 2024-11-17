using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Fiesta : INotifyPropertyChanged
    {
        public int id { get; set; }
        private List<EN_Padre> _padre;
        private List<EN_Hijo> _hijo;
        private int _idServicio;
        private EN_Servicio _Servicio;
        private int _idTurno;
        private string _turno;
        private DateTime _Fecha;
        private string _tematica;
        private int _EdadACumplir;
        private string _TipoComida;
        private int _ninosAdicionales;
        private double _anticipo;
        private double _total;
        private int _status;

        public List<EN_Padre> Padre
        {
            get => _padre;
            set { _padre = value; OnPropertyChanged(nameof(Padre)); }
        }

        public List<EN_Hijo> Hijo
        {
            get => _hijo;
            set { _hijo = value; OnPropertyChanged(nameof(Hijo)); }
        }

        public int IdServicio
        {
            get { return _idServicio; }
            set
            {
                _idServicio = value;
                OnPropertyChanged(nameof(IdServicio));
            }
        }
        public EN_Servicio Servicio
        {
            get => _Servicio;
            set { _Servicio = value; OnPropertyChanged(nameof(Servicio)); }
        }

        public int IdTurno
        {
            get { return _idTurno; }
            set
            {
                _idTurno = value;
                OnPropertyChanged(nameof(IdTurno));
            }
        }

        public string Turno
        {
            get => _turno;
            set { _turno = value; OnPropertyChanged(nameof(Turno)); }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set
            {
                _Fecha = value;
                OnPropertyChanged(nameof(Fecha));
            }
        }

        public string Tematica
        {
            get => _tematica;
            set { _tematica = value; OnPropertyChanged(nameof(Tematica)); }
        }

        public int EdadACumplir
        {
            get => _EdadACumplir;
            set { _EdadACumplir = value; OnPropertyChanged(nameof(EdadACumplir)); }
        }

        public string TipoComida
        {
            get => _TipoComida;
            set { _TipoComida = value; OnPropertyChanged(nameof(TipoComida)); }
        }
        public int NinosAdicionales
        {
            get => _ninosAdicionales;
            set { _ninosAdicionales = value; OnPropertyChanged(nameof(NinosAdicionales)); }
        }

        public double Anticipo
        {
            get => _anticipo;
            set { _anticipo = value; OnPropertyChanged(nameof(Anticipo)); }
        }

        public double Total
        {
            get => _total;
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }

        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
