﻿using Data;
using Entidad;

namespace Negocio
{
    public class RN_Producto
    {
        public static async Task<EN_Response<EN_Producto>> modificarProductoVisita(int id_Visita, EN_ProductosVisita producto)
        {
            return await DB_Producto.modificarProductoVisita(id_Visita, producto);
        }
        public static async Task<EN_Response<EN_Producto>> RN_increaseCantidadProducto(int id, int Cantidad)
        {
            return await DB_Producto.increaseCantidadProducto(id, Cantidad);
        }
        public static async Task<List<EN_Producto>> RN_GetAllProductos()
        {
            return await DB_Producto.getAllProductos();
        }
        public static async Task<List<EN_Producto>> RN_GetAllActiveProductos()
        {
            return await DB_Producto.getAllActiveProductos();
        }
        public static async Task<List<EN_Producto>> RN_GetProductoByID(int _id)
        {
            return await DB_Producto.getProductoById(_id);
        }
        public static async Task<List<EN_Producto>> RN_DeleteProducto(int _ide)
        {
            return await DB_Producto.deleteProducto(_ide);
        }
        public static async Task RN_UpdateProducto(EN_Producto eN_Producto)
        {
            await DB_Producto.updateProducto(eN_Producto);
        }
        public static async Task<EN_Response<EN_Producto>> RN_AddNewProducto(EN_Producto eN_Producto)
        {
            return await DB_Producto.addNewProducto(eN_Producto);
        }
    }
}
