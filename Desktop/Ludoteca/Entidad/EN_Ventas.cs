using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Ventas : INotifyPropertyChanged
    {
        public int id { get; set; }

        private double _total;
        private DateTime _fecha;
        private List<EN_Producto> _productos;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double Total
        {
            get => _total;
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }

        public DateTime Fecha
        {
            get => _fecha;
            set { _fecha = value; OnPropertyChanged(nameof(Fecha)); }
        }

        public List<EN_Producto> Productos
        {
            get => _productos;
            set { _productos = value; OnPropertyChanged(nameof(Productos)); }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine(propertyName);
        }

    }
}
