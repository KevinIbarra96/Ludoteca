namespace Entidad
{
    public class EN_Response<T>
    {
        public int Rcode { get; set; }
        public string Rmessage { get; set; }
        public string RerrorCode { get; set; }
        public List<T> Rbody { get; set; }
    }
}
