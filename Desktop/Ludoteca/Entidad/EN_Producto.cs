using System.ComponentModel;

namespace Entidad
{
    public class EN_Producto : INotifyPropertyChanged
    {
        public int id { get; set; }
        private string _productoName;
        private int _cantidad;
        private double _precio;

        private int _cantidadVisita;
        private bool _isEnable;

        //Propiedad para mostrar u ocultar el boton editar en el inventario
        public bool Visble = true;


        public event PropertyChangedEventHandler? PropertyChanged;

        public string ProductoName
        {
            get { return _productoName; }
            set { if (_productoName != value) { _productoName = value; OnPropertyChanged(nameof(ProductoName)); } }
        }
        public double Precio
        {
            get { return _precio; }
            set { if (_precio != Math.Round(value, 2)) { _precio = Math.Round(value, 2); OnPropertyChanged(nameof(Precio)); } }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { if (_cantidad != value) { _cantidad = value; OnPropertyChanged(nameof(Cantidad)); } }
        }
        public int CantidadVisita
        {
            get { return _cantidadVisita; }
            set { if (_cantidadVisita != value) { _cantidadVisita = value; OnPropertyChanged(nameof(CantidadVisita)); } }
        }
        public bool IsEnable
        {
            get { return _isEnable; }
            set { if (_isEnable != value) { _isEnable = value; OnPropertyChanged(nameof(IsEnable)); } }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
