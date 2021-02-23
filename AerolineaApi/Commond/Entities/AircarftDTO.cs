namespace Aerolina.Domain.Entities
{
    public class AircarftDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public int? Capacidad { get; set; }
        public string Descripcion { get; set; }
        public int Arolinea { get; set; }
        public string ArolineaNombre { get; set; }
        public string Piloto { get; set; }
    }
}
