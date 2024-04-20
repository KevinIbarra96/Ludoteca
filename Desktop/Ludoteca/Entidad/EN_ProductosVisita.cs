using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_ProductosVisita
    {
        public int id_Producto {  get; set; }
        public string ProductoName { get; set; }
        public double precioProductoVisita { get; set; }
        public int CantidadProductoVisita { get; set; }
    }
}
