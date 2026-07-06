using System.ComponentModel.DataAnnotations;

namespace SoftValeApi.Models
{
    public class Vale
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Vardiya { get; set; }
    }
}
