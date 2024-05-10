using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Personel.Models
{
	public class Admin
	{
        [Key]
        public int AdminId { get; set; }


        [Column(TypeName = "Varchar(20)")]
        [StringLength(20, ErrorMessage ="En Fazla 20 Karakter Girebilirsiniz")]
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
        public string Kullanici { get; set; }


		[Column(TypeName = "Varchar(12)")]
        [StringLength(12, ErrorMessage = "En Fazla 12 Karakter Girebilirsiniz")]
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Sifre { get; set; }

        [Column(TypeName = "Varchar(25)")]
        [StringLength(25, ErrorMessage = "En Fazla 25 Karakter Girebilirsiniz")]
        [EmailAddress(ErrorMessage ="Lütfen Geçerli Bir Email Adresi Giriniz")]
        public string Email { get; set; }

    }
}
