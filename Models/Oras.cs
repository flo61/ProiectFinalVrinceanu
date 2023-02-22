namespace vacanta.Models
{
    public class Oras
    {
        public int ID { get; set; }
        public string NumeOras { get; set; }
        public ICollection<Luna>? Luni { get; set; }
    }
}
