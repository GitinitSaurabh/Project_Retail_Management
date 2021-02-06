using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Data
{
    public class VendorData
    {
        public List<Vendors> GetVendorList()
        {
            return new List<Vendors>()
                {
                    new Vendors
                    {
                        VendorId = 1,
                        Name = "CORSECCA",
                        DeliveryCharge = 50,
                        Rating = 4.1
                    },
                     new Vendors
                     {
                         VendorId = 2,
                         Name = "Shop Stop",
                         DeliveryCharge = 40,
                         Rating = 3.4
                     },
                     new Vendors
                    {
                        VendorId = 3,
                        Name = "Shop4ever",
                        DeliveryCharge = 42,
                        Rating = 4.0
                    },
                     new Vendors
                    {
                        VendorId = 4,
                        Name = "Archies",
                        DeliveryCharge = 30,
                        Rating = 3.4
                    },
                     new Vendors
                    {
                        VendorId = 5,
                        Name = "Sugar Store",
                        DeliveryCharge = 60,
                        Rating = 4.8
                    },
                     new Vendors
                    {
                        VendorId = 6,
                        Name = "Top Q",
                        DeliveryCharge = 45,
                        Rating = 3.5
                    },
                     new Vendors
                    {
                        VendorId = 7,
                        Name = "Customer Q",
                        DeliveryCharge = 35,
                        Rating = 4.2
                    },
                     new Vendors
                    {
                        VendorId = 8,
                        Name = "Star Vendors",
                        DeliveryCharge = 50,
                        Rating = 3.8
                    },
                     new Vendors
                    {
                        VendorId = 9,
                        Name = "Villi Store",
                        DeliveryCharge = 58,
                        Rating = 4.3
                    },
                     new Vendors
                    {
                        VendorId = 10,
                        Name = "Lilly Store",
                        DeliveryCharge = 70,
                        Rating = 4.6
                    },
                     new Vendors
                    {
                        VendorId = 11,
                        Name = "Shop 99",
                        DeliveryCharge = 60,
                        Rating = 4.6
                    },
                     new Vendors
                    {
                        VendorId = 12,
                        Name = "Q Shop",
                        DeliveryCharge = 20,
                        Rating = 2.7
                    }
                };
        }
    }
}
