using Data;
using Entidad;

namespace Negocio
{
    public class RN_Ventas
    {
        public static async Task<EN_Response<EN_Ventas>> getAllVentas()
        {
            return await DB_Ventas.getAllVentas();
        }
        public static async Task<EN_Response<EN_Ventas>> addNewProducto(EN_Ventas _Venta)
        {
            return await DB_Ventas.addNewProducto(_Venta);
        }
    }
}
