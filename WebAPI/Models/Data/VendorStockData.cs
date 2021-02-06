using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Data
{
    public class VendorStocksData
    {
        public List<VendorStocks> GetVendorStocksList()
        {
            return new List<VendorStocks>()
            {
                new VendorStocks
                {
                    StockId = 1,
                    VendorId = 1,
                    ProductId = 1,
                    StockInHand = 0,
                    ExpectedDate = new DateTime(2021, 3, 1)
                },
                new VendorStocks
                {
                    StockId = 2,
                    VendorId = 1,
                    ProductId = 2,
                    StockInHand = 60,
                    ExpectedDate = new DateTime(2021, 3, 5)
                },
                new VendorStocks
                {
                    StockId = 3,
                    VendorId = 1,
                    ProductId = 3,
                    StockInHand = 200,
                    ExpectedDate = new DateTime(2021, 7, 1)
                },
                new VendorStocks
                {
                    StockId = 4,
                    VendorId = 1,
                    ProductId = 4,
                    StockInHand = 80,
                    ExpectedDate = new DateTime(2021, 11, 1)
                },
                new VendorStocks
                {
                    StockId = 5,
                    VendorId = 1,
                    ProductId = 5,
                    StockInHand = 600,
                    ExpectedDate = new DateTime(2021, 4, 10)
                },
                new VendorStocks
                {
                    StockId = 6,
                    VendorId = 2,
                    ProductId = 1,
                    StockInHand = 0,
                    ExpectedDate = new DateTime(2021, 3, 15)
                },
                new VendorStocks
                {
                    StockId = 7,
                    VendorId = 2,
                    ProductId = 2,
                    StockInHand = 40,
                    ExpectedDate = new DateTime(2021, 7, 19)
                },
                new VendorStocks
                {
                    StockId = 8,
                    VendorId = 2,
                    ProductId = 3,
                    StockInHand = 120,
                    ExpectedDate = new DateTime(2021, 8, 14)
                },
                new VendorStocks
                {
                    StockId = 9,
                    VendorId = 2,
                    ProductId = 4,
                    StockInHand = 50,
                    ExpectedDate = new DateTime(2021, 2, 3)
                },
                new VendorStocks
                {
                    StockId = 10,
                    VendorId = 2,
                    ProductId = 5,
                    StockInHand = 250,
                    ExpectedDate = new DateTime(2021, 9, 25)
                },
                new VendorStocks
                {
                    StockId = 11,
                    VendorId = 3,
                    ProductId = 6,
                    StockInHand = 190,
                    ExpectedDate = new DateTime(2021, 7, 20)
                },
                new VendorStocks
                {
                    StockId = 12,
                    VendorId = 3,
                    ProductId = 7,
                    StockInHand = 10,
                    ExpectedDate = new DateTime(2021, 3, 29)
                },

                new VendorStocks
                {
                    StockId = 13,
                    VendorId = 3,
                    ProductId = 8,
                    StockInHand = 100,
                    ExpectedDate = new DateTime(2021, 3, 1)
                },
                new VendorStocks
                {
                    StockId = 14,
                    VendorId = 3,
                    ProductId = 9,
                    StockInHand = 150,
                    ExpectedDate = new DateTime(2021, 3, 20)
                },
                new VendorStocks
                {
                    StockId = 15,
                    VendorId = 3,
                    ProductId = 10,
                    StockInHand = 105,
                    ExpectedDate = new DateTime(2021, 8, 29)
                },
                new VendorStocks
                {
                    StockId = 16,
                    VendorId = 4,
                    ProductId = 6,
                    StockInHand = 70,
                    ExpectedDate = new DateTime(2021, 9, 1)
                },
                 new VendorStocks
                   {
                        StockId = 18,
                        VendorId = 4,
                        ProductId = 8,
                        StockInHand = 200,
                        ExpectedDate = new DateTime(2021, 6, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 19,
                        VendorId = 4,
                        ProductId = 9,
                        StockInHand = 400,
                        ExpectedDate = new DateTime(2021, 6, 20)
                   },
                   new VendorStocks
                   {
                        StockId = 20,
                        VendorId = 4,
                        ProductId = 10,
                        StockInHand = 20,
                        ExpectedDate = new DateTime(2021, 11, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 21,
                        VendorId = 5,
                        ProductId = 11,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 9, 17)
                   },
                   new VendorStocks
                   {
                        StockId = 22,
                        VendorId = 5,
                        ProductId = 12,
                        StockInHand = 80,
                        ExpectedDate = new DateTime(2021, 12, 9)
                   },
                   new VendorStocks
                   {
                        StockId = 23,
                        VendorId = 5,
                        ProductId = 13,
                        StockInHand = 45,
                        ExpectedDate = new DateTime(2021, 12, 19)
                   },
                   new VendorStocks
                   {
                        StockId = 24,
                        VendorId = 5,
                        ProductId = 14,
                        StockInHand = 89,
                        ExpectedDate = new DateTime(2021, 5, 9)
                   },
                   new VendorStocks
                   {
                        StockId = 25,
                        VendorId = 5,
                        ProductId = 15,
                        StockInHand = 43,
                        ExpectedDate = new DateTime(2021, 7, 16)
                   },
                   new VendorStocks
                   {
                        StockId = 26,
                        VendorId = 6,
                        ProductId = 11,
                        StockInHand = 60,
                        ExpectedDate = new DateTime(2021, 8, 18)
                   },
                   new VendorStocks
                   {
                        StockId = 27,
                        VendorId = 6,
                        ProductId = 12,
                        StockInHand = 450,
                        ExpectedDate = new DateTime(2021, 4, 15)
                   },
                   new VendorStocks
                   {
                        StockId = 28,
                        VendorId = 6,
                        ProductId = 13,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 5, 19)
                   },
                   new VendorStocks
                   {
                        StockId = 29,
                        VendorId = 6,
                        ProductId = 14,
                        StockInHand = 70,
                        ExpectedDate = new DateTime(2021, 6, 23)
                   },
                   new VendorStocks
                   {
                        StockId = 30,
                        VendorId = 6,
                        ProductId = 15,
                        StockInHand = 56,
                        ExpectedDate = new DateTime(2021, 3, 22)
                   },
                   new VendorStocks
                   {
                        StockId = 31,
                        VendorId = 7,
                        ProductId = 16,
                        StockInHand = 46,
                        ExpectedDate = new DateTime(2021, 4, 22)
                   },
                   new VendorStocks
                   {
                        StockId = 32,
                        VendorId = 7,
                        ProductId = 17,
                        StockInHand = 24,
                        ExpectedDate = new DateTime(2021, 7, 12)
                   },
                   new VendorStocks
                   {
                        StockId = 33,
                        VendorId = 7,
                        ProductId = 18,
                        StockInHand = 73,
                        ExpectedDate = new DateTime(2021, 3, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 34,
                        VendorId = 7,
                        ProductId = 19,
                        StockInHand = 35,
                        ExpectedDate = new DateTime(2021, 3, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 35,
                        VendorId = 7,
                        ProductId = 20,
                        StockInHand = 76,
                        ExpectedDate = new DateTime(2021, 3, 1)
                   },
                   new VendorStocks
                   {
                        StockId = 36,
                        VendorId = 8,
                        ProductId = 16,
                        StockInHand = 34,
                        ExpectedDate = new DateTime(2021, 3, 2)
                   },
                   new VendorStocks
                   {
                        StockId = 37,
                        VendorId = 8,
                        ProductId = 17,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 12, 22)
                   },
                   new VendorStocks
                   {
                        StockId = 38,
                        VendorId = 8,
                        ProductId = 18,
                        StockInHand = 93,
                        ExpectedDate = new DateTime(2021, 10, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 39,
                        VendorId = 8,
                        ProductId = 19,
                        StockInHand = 34,
                        ExpectedDate = new DateTime(2021, 10, 22)
                   },
                   new VendorStocks
                   {
                        StockId = 40,
                        VendorId = 8,
                        ProductId = 20,
                        StockInHand = 334,
                        ExpectedDate = new DateTime(2021, 10, 19)
                   },
                   new VendorStocks
                   {
                        StockId = 41,
                        VendorId = 9,
                        ProductId = 21,
                        StockInHand = 179,
                        ExpectedDate = new DateTime(2021, 9, 27)
                   },
                   new VendorStocks
                   {
                        StockId = 42,
                        VendorId = 9,
                        ProductId = 22,
                        StockInHand = 43,
                        ExpectedDate = new DateTime(2021, 10, 27)
                   },
                   new VendorStocks
                   {
                        StockId = 43,
                        VendorId = 9,
                        ProductId = 23,
                        StockInHand = 46,
                        ExpectedDate = new DateTime(2021, 3, 27)
                   },
                   new VendorStocks
                   {
                        StockId = 44,
                        VendorId = 9,
                        ProductId = 24,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 10, 9)
                   },
                   new VendorStocks
                   {
                        StockId = 45,
                        VendorId = 9,
                        ProductId = 25,
                        StockInHand = 73,
                        ExpectedDate = new DateTime(2021, 10, 15)
                   },
                   new VendorStocks
                   {
                        StockId = 46,
                        VendorId = 10,
                        ProductId = 21,
                        StockInHand = 28,
                        ExpectedDate = new DateTime(2021, 5, 30)
                   },
                   new VendorStocks
                   {
                        StockId = 47,
                        VendorId = 10,
                        ProductId = 22,
                        StockInHand = 24,
                        ExpectedDate = new DateTime(2021, 4, 30)
                   },
                   new VendorStocks
                   {
                        StockId = 48,
                        VendorId = 10,
                        ProductId = 23,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 6, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 49,
                        VendorId = 10,
                        ProductId = 24,
                        StockInHand = 19,
                        ExpectedDate = new DateTime(2021, 7, 4)
                   },
                   new VendorStocks
                   {
                        StockId = 50,
                        VendorId = 10,
                        ProductId = 25,
                        StockInHand = 18,
                        ExpectedDate = new DateTime(2021, 3, 5)
                   },
                   new VendorStocks
                   {
                        StockId = 51,
                        VendorId = 11,
                        ProductId = 26,
                        StockInHand = 14,
                        ExpectedDate = new DateTime(2021, 4, 9)
                   },
                   new VendorStocks
                   {
                        StockId = 52,
                        VendorId = 11,
                        ProductId = 27,
                        StockInHand = 35,
                        ExpectedDate = new DateTime(2021, 3, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 53,
                        VendorId = 11,
                        ProductId = 28,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 3, 29)
                   },
                   new VendorStocks
                   {
                        StockId = 54,
                        VendorId = 11,
                        ProductId = 29,
                        StockInHand = 78,
                        ExpectedDate = new DateTime(2021, 8, 22)
                   },
                   new VendorStocks
                   {
                        StockId = 55,
                        VendorId = 11,
                        ProductId = 30,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 9, 9)
                   },
                   new VendorStocks
                   {
                        StockId = 56,
                        VendorId = 12,
                        ProductId = 26,
                        StockInHand = 96,
                        ExpectedDate = new DateTime(2021, 10, 5)
                   },
                   new VendorStocks
                   {
                        StockId = 57,
                        VendorId = 12,
                        ProductId = 27,
                        StockInHand = 100,
                        ExpectedDate = new DateTime(2021, 7, 14)
                   },
                   new VendorStocks
                   {
                        StockId = 58,
                        VendorId = 12,
                        ProductId = 28,
                        StockInHand = 14,
                        ExpectedDate = new DateTime(2021, 10, 20)
                   },
                   new VendorStocks
                   {
                        StockId = 59,
                        VendorId = 12,
                        ProductId = 29,
                        StockInHand = 13,
                        ExpectedDate = new DateTime(2021, 5, 1)
                   },
                   new VendorStocks
                   {
                        StockId = 60,
                        VendorId = 12,
                        ProductId = 30,
                        StockInHand = 10,
                        ExpectedDate = new DateTime(2021, 3, 28)
                   }

        };
        }
    }
}
