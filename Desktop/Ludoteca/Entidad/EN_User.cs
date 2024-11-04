
using System.ComponentModel;

namespace Entidad
{
    public class EN_User : INotifyPropertyChanged
    {
        private int _id;
        private string _userName;
        private string _password;
        private int _idRol;
        private string _rolName;
        private int _status;
        private string _statusString;


        public int id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(id)); }
        }

        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public int idRol
        {
            get => _idRol;
            set { _idRol = value; OnPropertyChanged(nameof(idRol)); }
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
