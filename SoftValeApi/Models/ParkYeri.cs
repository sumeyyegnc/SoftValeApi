using System.ComponentModel.DataAnnotations;

namespace SoftValeApi.Models
{
    public class ParkYeri
    {
        [Key]
        public int Id { get; set; }
        public string OtoparkAdi { get; set; }
        public int Kapasite { get; set; }
    }
}
