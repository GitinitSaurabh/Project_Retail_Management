using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public partial class Carts
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int? ZipCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? VendorId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
