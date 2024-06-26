﻿using System.ComponentModel;

namespace Entidad
{
    public class EN_Producto: INotifyPropertyChanged
    {
        public int id {  get; set; }
        private string _productoName;
        private int _cantidad;
        private double _precio;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string ProductoName
        {
            get { return _productoName; } 
            set { if (_productoName != value){ _productoName = value; OnPropertyChanged(nameof(ProductoName)); }  }
        }
        public double Precio
        {
            get { return _precio; }
            set { if (_precio != Math.Round(value, 2) ) { _precio = Math.Round(value, 2); OnPropertyChanged(nameof(Precio)); } }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { if (_cantidad != value) { _cantidad = value; OnPropertyChanged(nameof(Cantidad)); } }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
