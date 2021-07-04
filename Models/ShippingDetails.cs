using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koesell.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Adres Bilgilerini Doldurunuz.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen Sehir Giriniz.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen Semti Giriniz.")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen Mahalle Giriniz.")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen PostaKodu Giriniz.")]
        public string PostaKodu { get; set; }


    }
}