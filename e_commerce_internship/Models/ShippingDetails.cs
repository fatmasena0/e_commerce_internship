using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }
        [Required(ErrorMessage ="Lütfen adresi bilgisini giriniz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Lütfen şehir bilgisini giriniz.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen ilçe bilgisini giriniz.")]
        public string Semt { get; set; }
        public string PostaKodu { get; set; }

    }
}