using System.ComponentModel;

namespace Entidad
{
    public class EN_Menu : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string MenuName { get; set; }
        public string Path { get; set; }
        public string ClassName { get; set; }
        public int MenuOrder { get; set; }
        public string IconName { get; set; }

        private string _selectedBackgroundColor = "White";

        public string SelectedBackgroundColor
        {
            get { return _selectedBackgroundColor; }
            set
            {
                _selectedBackgroundColor = value;
                OnPropertyChanged(nameof(SelectedBackgroundColor));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
