
using System.ComponentModel;

namespace Entidad
{
    public class EN_Gafete : INotifyPropertyChanged
    {

        public int id { get; set; }

        private int _numero;

        public int Numero
        {
            get { return _numero; }
            set { if (_numero != value) { _numero = value; OnPropertyChanged(nameof(Numero)); } }
        }

        private int _asignado;

        public int Asignado
        {
            get { return _asignado; }
            set { if (_asignado != value) { _asignado = value; OnPropertyChanged(nameof(Asignado)); } }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
