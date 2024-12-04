using Entidad;
using Ludoteca.Resources;
using Negocio;
using System.Collections.ObjectModel;

namespace Ludoteca.ViewModel
{

    public delegate void LoadServiciosTable();
    public delegate void UpdateServiciosTable(GlobalEnum.Action Action, EN_Servicio servicios);

    internal class ServiciosViewModel
    {
        public ObservableCollection<EN_Servicio> servicios { get; set; }
        public ObservableCollection<EN_Servicio> SsrviciosInmutble { get; set; }

        public LoadServiciosTable _loadServiciosTable;
        public UpdateServiciosTable _UpdateServiciosTable;


        public ServiciosViewModel()
        {
            servicios = new ObservableCollection<EN_Servicio>();
            SsrviciosInmutble = new ObservableCollection<EN_Servicio>();

            //Asignacin de delegados
            _loadServiciosTable = loadServiciosTable;
            _UpdateServiciosTable = UpdateServiciosTable;

            //loadServiciosTable();
        }

        //Metodo destinada para agregar o editar una iteracion de la coleccion
        private void UpdateServiciosTable(GlobalEnum.Action Action, EN_Servicio servicio)
        {
            if (Action == GlobalEnum.Action.CREAR_NUEVO)
                addServiciosToCollection(servicio);
            if (Action == GlobalEnum.Action.ACTUALIZAR)
                updateServiciosToColection(servicio);
        }

        //Metodo destinado para limpiar y recargar la informacion de la tabla desde el inicio.
        private async void loadServiciosTable()
        {
            SsrviciosInmutble.Clear();
            servicios.Clear();
            EN_Response<EN_TipoServicio> tipoServicioRes = await RN_TipoServicio.RN_GetAllActiveTipoServicio();
            foreach (var servicio in await RN_Servicio.RN_GetAllActiveServicios())
            {
                foreach (EN_TipoServicio tp in tipoServicioRes.Rbody)
                {
                    if (tp.id == servicio.IdTipoServicio)
                        servicio.TipoServicio = tp.Nombre;
                }
                addServiciosToCollection(servicio);
            }
        }

        private void addServiciosToCollection(EN_Servicio servicio)
        {
            servicios.Add(servicio);
            SsrviciosInmutble.Add(servicio);
        }

        private void updateServiciosToColection(EN_Servicio servicio)
        {
            EN_Servicio Encontrado = servicios.FirstOrDefault(s => s.id == servicio.id);

            if (Encontrado != null)
            {
                Encontrado.ServicioName = servicio.ServicioName;
                Encontrado.Descripcion = servicio.Descripcion;
                Encontrado.Precio = servicio.Precio;
                Encontrado.Tiempo = servicio.Tiempo;
                Encontrado.IdTipoServicio = servicio.IdTipoServicio;
                Encontrado.TipoServicio = servicio.TipoServicio;
            }
        }

    }
}
