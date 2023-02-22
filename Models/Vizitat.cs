namespace vacanta.Models
{
    public class Vizitat
    {
        public int ID { get; set; }
        public string AmVizitat { get; set; }
        public ICollection<Luna>? Luni { get; set; }
    }
}
