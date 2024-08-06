using Entidad;
using System.Collections.ObjectModel;

namespace Ludoteca.Resources
{
    public class ConvertClass
    {
        public static ObservableCollection<EN_ServiciosVisita> convertEN_ServicionToEN_ServicioVisita(EN_Servicio servicio)
        {
            ObservableCollection<EN_ServiciosVisita> listaServicioVisita = new ObservableCollection<EN_ServiciosVisita>();

            EN_ServiciosVisita servicioVisita = new EN_ServiciosVisita();
            servicioVisita.Servicio_Id = servicio.id;
            servicioVisita.ServicioName = servicio.ServicioName;
            servicioVisita.Servicio_Precio = servicio.Precio;
            servicioVisita.Tiempo = servicio.Tiempo;

            listaServicioVisita.Add(servicioVisita);

            return listaServicioVisita;
        }

        public static ObservableCollection<EN_ProductosVisita> convertEN_ProductosToEN_ProductosVisita(List<EN_Producto> produ)
        {
            ObservableCollection<EN_ProductosVisita> productosVisitas = new ObservableCollection<EN_ProductosVisita>();
            foreach (EN_Producto p in produ)
            {
                EN_ProductosVisita pro = new EN_ProductosVisita();
                pro.id_Producto = p.id;
                pro.ProductoName = p.ProductoName;
                pro.precioProductoVisita = p.Precio;
                pro.CantidadProductoVisita = p.CantidadVisita;
                productosVisitas.Add(pro);
            }

            return productosVisitas;
        }


    }
}
