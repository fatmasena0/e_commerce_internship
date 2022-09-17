using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class UserProfile
    {
        public string id { get; set; }
        [Required]
        [DisplayName("Ad")]
        public string name { get; set; }
        [Required]
        [DisplayName("Soyad")]
        public string surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string username { get; set; }
        [Required]
        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage = "Geçersiz E-Mail Adresi")]
        public string email { get; set; }
    }
}