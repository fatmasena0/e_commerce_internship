using System;
using System.Collections.Generic;
using System.ComponentModel; //Displayname
using System.ComponentModel.DataAnnotations; //Required
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}