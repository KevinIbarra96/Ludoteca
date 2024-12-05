
using System.ComponentModel;

namespace Entidad
{
    public class EN_Gafete : INotifyPropertyChanged
    {

        public int id { get; set; }
        private int _numero;
        private int _asignado;
        private string _asignadoString;
        private int _status;
        private string _statusString;

        public int Numero
        {
            get { return _numero; }
            set { if (_numero != value) { _numero = value; OnPropertyChanged(nameof(Numero)); } }
        }

        public int Asignado
        {
            get { return _asignado; }
            set
            {
                _asignado = value;
                OnPropertyChanged(nameof(Asignado));
            }
        }

        public string AsignadoString
        {
            get { return _asignadoString; }
            set
            {
                _asignadoString = value;
                OnPropertyChanged(nameof(AsignadoString));
            }
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

        public string StatusString
        {
            get { return _statusString; }
            set
            {
                _statusString = value;
                OnPropertyChanged(nameof(StatusString));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
