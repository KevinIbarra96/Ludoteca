using System.Collections.Generic;


namespace Entidad
{
    public class EN_Response<T>
    {
        public int Rcode { get; set; }
        public string Rmessage { get; set; }
        public int RerrorCode { get; set; }
        public List<T> Rbody { get; set; }
    }
}
