using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public partial class Carts
    {      
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ZipCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int VendorId { get; set; }
        public int CustomerId { get; set; }



        public virtual Products Product { get; set; }
        public virtual Vendors Vendor { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
