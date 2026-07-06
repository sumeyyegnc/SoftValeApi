using System.ComponentModel.DataAnnotations;

namespace SoftValeApi.Models
{
    public class Arac
    {
        [Key]
        public int Id { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Renk { get; set; }
    }
}
