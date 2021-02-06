using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Data;

namespace WebAPI.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductRetailManagementDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProductRetailManagementDBContext>>()))
            {
                // 1. Products
                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // Data was already seeded
                }



                context.Products.AddRange(new ProductData().GetProductList());



                // 2. Customers
                // Look for any customers.
                if (context.Customers.Any())
                {
                    return;   // Data was already seeded
                }
                context.Customers.AddRange(new CustomerData().GetCustomerList());



                // 3. Vendors
                // Look for any vendors.
                if (context.Vendors.Any())
                {
                    return;   // Data was already seeded
                }
                context.Vendors.AddRange(new VendorData().GetVendorList());



                // 4. VendorStocks
                // Look for any vendor stocks.
                if (context.VendorStocks.Any())
                {
                    return;   // Data was already seeded
                }
                context.VendorStocks.AddRange(new VendorStocksData().GetVendorStocksList());
                context.SaveChanges();
            }
        }
        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var context = new ProductRetailManagementDBContext(
        //    serviceProvider.GetRequiredService<DbContextOptions<ProductRetailManagementDBContext>>()))
        //    {
        //        // 1. Products
        //        // Look for any products.
        //        if (context.Products.Any())
        //        {
        //            return; // Data was already seeded
        //        }



        //        context.Products.AddRange(
        //        new Products
        //        {
        //            ProductId = 1,
        //            Name = "Macbook Air M1 - (8 GB/256 GB HDD) M1 Chip Laptop (14 inch, Silver, 1.35 kgs)",
        //            Price = 96000,
        //            Description = "Laptop",
        //            ImageName = "dairymilk.jpeg",
        //            Rating = 4.5
        //        },
        //        new Products
        //        {
        //            ProductId = 2,
        //            Name = "Ferrero Rocher",
        //            Price = 200,
        //            Description = "Dessert",
        //            ImageName = "ferrerorocher.jpeg",
        //            Rating = 4.5
        //        },
        //        new Products
        //        {
        //            ProductId = 3,
        //            Name = "Ferrero Rocher",
        //            Price = 200,
        //            Description = "Dessert",
        //            ImageName = "ferrerorocher.jpeg",
        //            Rating = 4.5
        //        },
        //        new Products
        //        {
        //            ProductId = 4,
        //            Name = "DairyMilk",
        //            Price = 100,
        //            Description = "Dessert",
        //            ImageName = "dairymilk.jpeg",
        //            Rating = 4.2
        //        },
        //        new Products
        //        {
        //            ProductId = 5,
        //            Name = "Redmi Note 8",
        //            Price = 15999,
        //            Description = "Mobile",
        //            ImageName = "redminote8.jpeg",
        //            Rating = 4.0
        //        },
        //        new Products
        //        {
        //            ProductId = 6,
        //            Name = "DairyMilk",
        //            Price = 100,
        //            Description = "Dessert",
        //            ImageName = "dairymilk.jpeg",
        //            Rating = 4.2
        //        },
        //        new Products
        //        {
        //            ProductId = 7,
        //            Name = "DairyMilk",
        //            Price = 100,
        //            Description = "Dessert",
        //            ImageName = "dairymilk.jpeg",
        //            Rating = 4.2
        //        },
        //        new Products
        //        {
        //            ProductId = 8,
        //            Name = "DairyMilk",
        //            Price = 100,
        //            Description = "Dessert",
        //            ImageName = "dairymilk.jpeg",
        //            Rating = 4.2
        //        });



        //        // 2. Customers
        //        // Look for any customers.
        //        if (context.Customers.Any())
        //        {
        //            return; // Data was already seeded
        //        }



        //        context.Customers.AddRange(
        //        new Customers
        //        {
        //            CustomerId = 1,
        //            FirstName = "Paul",
        //            LastName = "Walker",
        //            Email = "paul@gmail.com",
        //            Password = "Paul123"

        //        },
        //        new Customers
        //        {
        //            CustomerId = 2,
        //            FirstName = "Chris",
        //            LastName = "Hemsworth",
        //            Email = "chris@gmail.com",
        //            Password = "Chris123"
        //        });


        //        if (context.Vendors.Any())
        //            {
        //                return; // data was already seeded
        //            }



        //        context.Vendors.AddRange(
        //        new Vendors
        //        {
        //            VendorId = 1,
        //            Name = "99 Vendors",
        //            DeliveryCharge = 50,
        //            Rating = 4.1
        //        },
        //        new Vendors
        //        {
        //            VendorId = 2,
        //            Name = "CORSECA",
        //            DeliveryCharge = 40,
        //            Rating = 3.4
        //        });



        //        //// 4. VendorStocks
        //        //// Look for any vendor stocks.
        //        //if (context.VendorStocks.Any())
        //        //{
        //        //    return; // Data was already seeded
        //        //}



        //        //context.VendorStocks.AddRange(
        //        //new VendorStock
        //        //{
        //        //    VendorStockId = 1,
        //        //    VendorId = 1,
        //        //    ProductId = 1,
        //        //    StockInHand = 100,
        //        //    ExpectedDate = new DateTime(2021, 3, 1)
        //        //},
        //        //new VendorStock
        //        //{
        //        //    VendorStockId = 2,
        //        //    VendorId = 2,
        //        //    ProductId = 1,
        //        //    StockInHand = 60,
        //        //    ExpectedDate = new DateTime(2021, 3, 5)
        //        //});



        //        context.SaveChanges();
        //    }
        //}
    }
}
