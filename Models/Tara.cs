namespace vacanta.Models
{
    public class Tara
    {
        public int ID { get; set; }
        public string TaraDorita { get; set; }
        public ICollection<Luna>? Luni { get; set; }
    }
}
