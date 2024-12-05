using System.ComponentModel;

namespace Entidad
{
    public class EN_Hijo : INotifyPropertyChanged
    {
        public EN_Hijo() { }

        public EN_Hijo(int _id, string _name)
        {
            id = _id;
            NombreHijo = _name;
        }

        public int id { get; set; }
        //public string NombreHijo { get; set; }
        public int papa { get; set; }
        public int mama { get; set; }
        public string fechaNac { get; set; }

        private string _selectedBackgroundColor;
        private string _nombreHijo;

        public string NombreHijo
        {
            get { return _nombreHijo; }
            set
            {
                _nombreHijo = value;
                OnPropertyChanged(nameof(NombreHijo));
            }
        }
        public string SelectedBackgroundColor
        {
            get { return _selectedBackgroundColor; }
            set
            {
                _selectedBackgroundColor = value;
                OnPropertyChanged(nameof(SelectedBackgroundColor));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
