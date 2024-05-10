using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Personel.Models
{
    public class PersonelBilgi
    {
        [Key]
        public int PersonelID { get; set; }
        [Required(ErrorMessage = "Lütfen Bu Alanı Doldurunuz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Lütfen Bu Alanı Doldurunuz")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Lütfen Bu Alanı Doldurunuz")]
        public string Sehir { get; set; }
        public int BirimID { get; set; }
        public Birim Birim { get; set; }
    }
}
