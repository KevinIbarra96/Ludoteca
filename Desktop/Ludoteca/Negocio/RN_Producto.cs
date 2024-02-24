using Data;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RN_Producto
    {
        public static async Task<EN_Response<EN_Producto>> RN_increaseCantidadProducto(int id,int Cantidad)
        {
            return await DB_Producto.increaseCantidadProducto(id, Cantidad);
        }
        public static async Task<List<EN_Producto>> RN_GetAllProductos()
        {
            return await DB_Producto.getAllProductos();
        }
        public static async Task<List<EN_Producto>> RN_GetProductoByID(int _id)
        {
            return await DB_Producto.getProductoById(_id);
        }
        public static async Task<List<EN_Producto>> RN_DeleteProducto(int _ide)
        {
            return await DB_Producto.deleteProducto(_ide);
        }
        public static async Task<List<EN_Producto>> RN_UpdateProducto(EN_Producto eN_Producto)
        {
            return await DB_Producto.updateProducto(eN_Producto);
        }
        public static async Task<EN_Response<EN_Producto>> RN_AddNewProducto(EN_Producto eN_Producto)
        {
            return await DB_Producto.addNewProducto(eN_Producto);
        }
    }
}
