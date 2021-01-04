using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="Isim girilmesi zorunludur")]
        [Display(Name ="Ad Soyad")]
        public string Name { get; set; }
        [Required()]
        [MinLength(3)]
        [MaxLength(50)]
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string Adress3 { get; set; }
        [Required()]
        public string City { get; set; }
        public string Country { get; set; }
        public bool isGift { get; set; }

    }
}
