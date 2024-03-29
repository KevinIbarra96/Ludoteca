using System.ComponentModel;

namespace Entidad
{
    public class EN_Servicio : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        public int id { get; set; }
        private string _ServicioName;
        private string _Descripcion;
        private int _Precio;
        private int _Tiempo; // Time in minutesw
        private int _status;

        public string ServicioName 
        {
            get { return _ServicioName; }
            set { if (_ServicioName != value) { _ServicioName = value; OnPropertyChanged(nameof(ServicioName)); } }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { if (_Descripcion != value) { _Descripcion = value; OnPropertyChanged(nameof(Descripcion)); } }
        }
        public int Precio
        {
            get { return _Precio; }
            set { if (_Precio != value) { _Precio = value; OnPropertyChanged(nameof(Precio)); } }
        }
        public int Tiempo
        {
            get { return _Tiempo; }
            set { if (_Tiempo != value) { _Tiempo = value; OnPropertyChanged(nameof(Tiempo)); } }
        }
        public int status
        {
            get { return _status; }
            set { if (_status != value) { _status = value; OnPropertyChanged(nameof(status)); } }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
