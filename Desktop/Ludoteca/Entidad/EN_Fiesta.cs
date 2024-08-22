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
        private string _fiestaName;
        private string _description;
        private double _precio;
        private int _status;

        public string FiestaName
        {
            get { return _fiestaName; }
            set { _fiestaName = value; OnPropertyChanged(nameof(FiestaName)); }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }
        public int status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(status));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
