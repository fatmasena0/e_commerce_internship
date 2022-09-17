using System;
using System.Collections.Generic;
using System.ComponentModel; //include [DisplayName]
using System.ComponentModel.DataAnnotations; //include [Required]
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class Register
    {
        [Required] //kullanıcının aşağıdaki alanları boş bırakmamasını sağlar
        [DisplayName("Ad")]
        public string Name { get; set; }
        [Required] 
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage ="Geçersiz E-Mail Adresi")] //Geçerli E-Mail girilip girilmediğini check eder
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Girilen şifreler aynı değil")]
        [DisplayName("Şifre Tekrar")]
        public string Repassword { get; set; }
    }
}