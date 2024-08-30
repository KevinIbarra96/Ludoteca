﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_TipoServicio : INotifyPropertyChanged
    {
        public int id {  get; set; }
        private string _nombre { get; set; }

        public string Nombre
        { get { return _nombre; } 
          set { _nombre = value; OnPropertyChanged(nameof(Nombre)); } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}