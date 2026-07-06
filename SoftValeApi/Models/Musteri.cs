using System.ComponentModel.DataAnnotations;

namespace SoftValeApi.Models
{
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
    }
}
