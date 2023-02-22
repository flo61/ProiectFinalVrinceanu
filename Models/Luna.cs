using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace vacanta.Models
{
    public class Luna
    {
        public int ID { get; set; }
        public string Persoane { get; set; }
        public decimal Buget { get; set; }
        public string Suveniruri { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataPlecare { get; set; }
        public int? ContinentID { get; set; }
        public Continent? Continent { get; set; }
        public int? TaraID { get; set; }
        public Tara? Tara { get; set; }
        public int? OrasID { get; set; }
        public Oras? Oras { get; set; }
        public int? VizitatID { get; set; }
        public Vizitat? Vizitat { get; set; }

    }
}
