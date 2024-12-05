using Entidad;

namespace Resources.Properties
{
    public class ApplicationProperties
    {

        public static EN_Configuracion PrecioMinutoTreintaMin;
        public static EN_Configuracion PrecioMinutoSesentaMin;
        public static EN_Configuracion PrecioMinutoDespuesServicio;
        public static EN_Configuracion PrecioNiñoAdicional;
        public static EN_Configuracion edadMinima;
        public static EN_Configuracion edadMaxima;
        public static EN_Configuracion rutaTickets;


        public readonly static int IdPrecioMinutoTreintaMin = 1 ;
        public readonly static int IdPrecioMinutoSesentaMin = 6;
        public readonly static int IdPrecioMinutoDespuesServicio = 7;
        public readonly static int IdPrecioNiñoAdicional = 5;
        public readonly static int IdedadMinima = 2;
        public readonly static int IdedadMaxima = 3;
        public readonly static int IdrutaTickets = 4;

        //Configuracion Local
        /*public readonly static int IdTiempoLibreServicio = 7;

        public readonly static int IdAdministratorRol = 1;

        public readonly static int IdSinProducto = 20;*/

        //Server Configuracion
        public readonly static int IdTiempoLibreServicio = 1;

        public readonly static int IdAdministratorRol = 1;

        public readonly static int IdSinProducto = 1;

    }
}
