using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Fiesta : INotifyPropertyChanged
    {
        public int id { get; set; }
        private int _idHijo;
        private string _nombrehijo;
        private int _idServicio;
        private string _nombreServicio;
        private DateTime _Fecha;
        private double _anticipo;
        private double _total;
        private int _status;

        public int IdHijo
        {
            get { return _idHijo; }
            set { _idHijo = value; OnPropertyChanged(nameof(IdHijo)); }
        }

        public string NombreHijo
        {
            get => _nombrehijo;
            set { _nombrehijo = value; OnPropertyChanged(nameof(NombreHijo)); }
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

        public string NombreServicio
        {
            get => _nombreServicio;
            set { _nombreServicio = value; OnPropertyChanged(nameof(NombreServicio)); }
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
