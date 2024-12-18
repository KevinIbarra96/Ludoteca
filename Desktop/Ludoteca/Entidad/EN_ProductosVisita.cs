using System.ComponentModel;

namespace Entidad
{
    public class EN_ProductosVisita : INotifyPropertyChanged
    {

        private int _idProducto;
        private string _productoName;
        private double _precioProductoVisita;
        private int _cantidadProductoVisita;
        private string _cantidadProducto;

        public int id_Producto
        {
            get => _idProducto;
            set { _idProducto = value; OnPropertyChanged(nameof(id_Producto)); }
        }
        public string ProductoName
        {
            get => _productoName;
            set { _productoName = value; OnPropertyChanged(nameof(ProductoName)); }
        }
        public double precioProductoVisita
        {
            get => _precioProductoVisita;
            set { _precioProductoVisita = value; OnPropertyChanged(nameof(precioProductoVisita)); }
        }
        public int CantidadProductoVisita
        {
            get => _cantidadProductoVisita;
            set { _cantidadProductoVisita = value; OnPropertyChanged(nameof(CantidadProducto)); }
        }

        public string CantidadProducto
        {
            get => $"({CantidadProductoVisita}) {ProductoName}";

            set { _cantidadProducto = value; OnPropertyChanged(nameof(CantidadProducto)); }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
