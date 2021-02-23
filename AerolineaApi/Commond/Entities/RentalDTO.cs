namespace Aerolina.Domain.Entities
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public string DondeViaja { get; set; }
        public string FechaLLegada { get; set; }
        public string FechaSalida { get; set; }
        public int? CantidadPasajetos { get; set; }
    }
}
