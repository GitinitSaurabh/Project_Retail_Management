using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public partial class Vendors
    {
        [Key]
        public int VendorId { get; set; }
        public string Name { get; set; }
        public int? DeliveryCharge { get; set; }
        public double? Rating { get; set; }
    }
}
