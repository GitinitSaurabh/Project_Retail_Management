using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public partial class Vendors
    {
        public Vendors()
        {
            Carts = new HashSet<Carts>();
            VendorStocks = new HashSet<VendorStocks>();
        }
        [Key]
        public int VendorId { get; set; }
        public string Name { get; set; }
        public double DeliveryCharge { get; set; }
        public double Rating { get; set; }



        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<VendorStocks> VendorStocks { get; set; }
    }
}
