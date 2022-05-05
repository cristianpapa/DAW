namespace DAW2._0.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public int IdProdus { get; set; }
        public int CodPlata { get; set; }
        public int CodLivrare { get; set; }
        public string Status { get; set; }
        public DateTime DataPlasare { get; set; }

    }
}
