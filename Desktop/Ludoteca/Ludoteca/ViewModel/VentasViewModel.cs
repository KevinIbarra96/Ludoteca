using Entidad;
using Ludoteca.Resources;
using Negocio;
using Resources.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludoteca.ViewModel
{

    public delegate void LoadVentasTable();
    public delegate void UpdateVentasTable(GlobalEnum.Action action, EN_Ventas venta);

    public class VentasViewModel
    { 
        public ObservableCollection<EN_Ventas> Ventas { get; set; }
        public ObservableCollection<EN_Ventas> VentasInmutable { get; set; }

        public LoadVentasTable _loadVentasTable;
        public UpdateVentasTable _updateVentasTable;


        public VentasViewModel()
        {
            Ventas = new ObservableCollection<EN_Ventas>();
            VentasInmutable = new ObservableCollection<EN_Ventas>();

            //Asignacion de los Delegados
            _loadVentasTable = loadVentasData;
            _updateVentasTable = UpdateVentasData;

        }

        private async void loadVentasData()
        {
            VentasInmutable.Clear();
            Ventas.Clear();

            foreach (var venta in await getAllVentas() )
            {
                addVentasToCollection(venta);
            }
        }

        private void UpdateVentasData(GlobalEnum.Action Action, EN_Ventas venta)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addVentasToCollection(venta);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateVentasToColection(venta);
        }


        private async Task<List<EN_Ventas>> getAllVentas()
        {
            var ListVentas = await RN_Ventas.getAllVentas();
            return ListVentas.Rbody;
        }

        private void addVentasToCollection(EN_Ventas venta)
        {
            Ventas.Add(venta);
            VentasInmutable.Add(venta);
        }
        private void updateVentasToColection(EN_Ventas venta)
        {
            EN_Ventas Encontrado = Ventas.FirstOrDefault(v => v.id == venta.id);

            if (Encontrado != null)
            {
                Encontrado.Total = venta.Total;
                Encontrado.Fecha = venta.Fecha;
            }
        }

    }
}
