namespace vacanta.Models
{
    public class Continent
    {
        public int ID { get; set; }
        public string DenumireContinent { get; set; }
        public ICollection<Luna>? Luni { get; set; }
    }
}
