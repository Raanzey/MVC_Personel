using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Personel.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }
        [Required(ErrorMessage = "Lütfen Bu Alanı Doldurunuz")]
        public string Ad { get; set; }

        public IList<PersonelBilgi> PersonelBilgis { get; set; }
    }
}
