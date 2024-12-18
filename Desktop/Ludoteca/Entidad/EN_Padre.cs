namespace Entidad
{
    public class EN_Padre
    {
        public int id { get; set; }
        public string PadreName { get; set; }
        public string Address { get; set; }
        public string PadreInfo { get { return "Direccion: " + Address + "\nTelefono: " + Telefono; } }
        public string Telefono { get; set; }
    }
}
