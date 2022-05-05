namespace DAW2._0.Models
{
    public class Plata
    {
        public int Id { get; set; }
        public string Metoda { get; set; }
        public float Suma { get; set; }
        public DateTime Data { get; set; }

        public virtual Comanda Comanda { get; set; }
    }
}
