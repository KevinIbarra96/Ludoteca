using System.Collections.ObjectModel;
using Negocio;
using Entidad;
using Ludoteca.Resources;

namespace Ludoteca.ViewModel
{

    public delegate void LoadInventarioData();
    public delegate void UpdateInventarioData(GlobalEnum.Action Action, EN_Producto prduct);

    public class InventarioViewModel
    {

        public ObservableCollection<EN_Producto> Productos { get; set; }
        public ObservableCollection<EN_Producto> ProductInmutable { get; set; }

        //Iniciacion de delegados
        public LoadInventarioData _loadInventarioData;
        public UpdateInventarioData _UpdateInventarioData;


        public InventarioViewModel()
        {
            Productos = new ObservableCollection<EN_Producto>();
            ProductInmutable = new ObservableCollection<EN_Producto>();
            
            //Asignacin de delegados
            _loadInventarioData = loadInventarioData;
            _UpdateInventarioData = UpdateInventarioData;

            loadInventarioData();
        }

        //Metodo destinada para agregar o editar una iteracion de la coleccion
        private void UpdateInventarioData(GlobalEnum.Action Action,EN_Producto product)
        {
            if(Action == GlobalEnum.Action.CREAR_NUEVO)
                addProductToCollection(product);
            if(Action == GlobalEnum.Action.ACTUALIZAR)
                updateProductToColection(product);
        }

        //Metodo destinado para limpiar y recargar la informacion de la tabla desde el inicio.
        private async void loadInventarioData()
        {
            ProductInmutable.Clear();
            Productos.Clear();
            foreach(var producto in await RN_Producto.RN_GetAllProductos())
            {
                addProductToCollection(producto);
            }
        }

        private void addProductToCollection(EN_Producto producto)
        {
            Productos.Add(producto);
            ProductInmutable.Add(producto);
        }

        private void updateProductToColection(EN_Producto producto)
        {
            EN_Producto Encontrado = Productos.FirstOrDefault(p => p.id == producto.id);

            if(Encontrado != null)
            {
                Encontrado.ProductoName = producto.ProductoName;
                Encontrado.Precio = producto.Precio;
                Encontrado.Cantidad = producto.Cantidad;
            }
        }
    }
}
