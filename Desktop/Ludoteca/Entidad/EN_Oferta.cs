using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_Oferta : INotifyPropertyChanged
    {

        private int _id;
        private string _ofertaName;
        private string _descripcion;
        private int _tiempo;
        private double _totalDescuento;


        public int id 
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(id)); } 
        }

        public string OfertaName
        {
            get => _ofertaName;
            set { _ofertaName = value; OnPropertyChanged(nameof(OfertaName)); }
        }
        public string Descripcion
        {
            get => _descripcion;
            set { _descripcion = value; OnPropertyChanged(nameof(Descripcion)); }
        }
        public int Tiempo
        {
            get => _tiempo;
            set { _tiempo = value; OnPropertyChanged(nameof(Tiempo)); }
        }
        public double totalDescuento
        {
            get => _totalDescuento;
            set { _totalDescuento = value; OnPropertyChanged(nameof(totalDescuento)); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
