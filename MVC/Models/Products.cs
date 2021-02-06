using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public byte[] ImageName { get; set; }
        public double? Rating { get; set; }
    }
}
