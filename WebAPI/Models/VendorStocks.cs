using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public partial class VendorStocks
    {
        [Key]
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int StockInHand { get; set; }
        public DateTime ExpectedDate { get; set; }



        //references
        public virtual Products Product { get; set; }
        public virtual Vendors Vendor { get; set; }
    }
}
