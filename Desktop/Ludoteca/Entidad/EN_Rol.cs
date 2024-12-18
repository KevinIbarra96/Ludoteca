using System.ComponentModel;

namespace Entidad
{
    public class EN_Rol : INotifyPropertyChanged
    {
        private int _id;
        private string _rolName;
        private int _status;
        private string _statusString;

        public int id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(id)); }
        }

        public string RolName
        {
            get => _rolName;
            set { _rolName = value; OnPropertyChanged(nameof(RolName)); }
        }

        public int status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(nameof(status)); }
        }

        public string statusString
        {
            get => _statusString;
            set { _statusString = value; OnPropertyChanged(nameof(statusString)); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
