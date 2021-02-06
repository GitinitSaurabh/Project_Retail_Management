using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Data
{
    public class ProductData
    {
        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fS = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] imageInBytes = new byte[fS.Length];
            fS.Read(imageInBytes, 0, (int)fS.Length);
            fS.Close();
            return imageInBytes;
        }
        public List<Products> GetProductList()
        {
           
            return new List<Products>()
                {
                    new Products
                    {
                        ProductId = 1,
                        Name = "Macbook Air M1 - (8 GB/256 GB HDD) M1 Chip Laptop (14 inch, Silver, 1.35 kgs)",
                        Price = 96000,
                        Description = "Electronics",
                        ImageName = ImageToBinary(@"src\Image\Mac.jpg"),
                        Rating = 4.5
                    },
                    new Products
                        {
                        ProductId = 2,
                        Name = "MTR Gulab Jamun 350g ( buy1 Get 1) 350 g",
                        Price = 499,
                        Description = "Dessert",
                        ImageName = ImageToBinary(@"src\Image\gulabjamun.jpg"),
                        Rating = 5.0
                        },
                        new Products
                        {
                        ProductId = 3,
                        Name = "Singla Kaju Katli Burfi Sweets 200g Box (200 g)",
                        Price = 258,
                        Description = "Dessert",
                        ImageName = ImageToBinary(@"src\Image\kajukatli.jpg"),
                        Rating = 4.5
                        },
                        new Products
                        {
                        ProductId = 4,
                        Name = "PURAMIO Ice Cream Mix Chocolate 250 g",
                        Price = 198,
                        Description = "Dessert",
                        ImageName = ImageToBinary(@"src\Image\chocolateicecream.jpg"),
                        Rating = 4.2
                        },
                        new Products
                        {
                        ProductId = 5,
                        Name = "Haldiram's Besan Laddu Box (500 g)",
                        Price = 290,
                        Description = "Dessert",
                        ImageName = ImageToBinary(@"src\Image\ladoo.jpg"),
                        Rating = 4.3
                        },
                        new Products
                        {
                        ProductId = 6,
                        Name = "Dell Inspiron Core i7 11th Gen - (16 GB/512 GB SSD/Windows 10 Home/2 GB Graphics) Inspiron 7400 Thin and Light Laptop (14 inch, Silver, 1.26 kg, With MS Office)",
                        Price = 125997,
                        Description = "Electronics",
                        ImageName = ImageToBinary(@"src\Image\dell.jpg"),
                        Rating = 4.8
                        },
                        new Products
                        {
                        ProductId = 7,
                        Name = "Samsung Galaxy S21 Ultra (Phantom Black, 256 GB) (12 GB RAM)",
                        Price = 105999,
                        Description = "Electronics",
                        ImageName = ImageToBinary(@"src\Image\galaxys21.jpg"),
                        Rating = 4.7
                        },
                        new Products
                        {
                        ProductId = 8,
                        Name = "boAt Rockerz 450 Bluetooth Headset (Luscious Black, On the Ear)",
                        Price = 1299,
                        Description = "Electronics",
                        ImageName = ImageToBinary(@"src\Image\boat.png"),
                        Rating = 4.4
                        },
                        new Products
                        {
                        ProductId = 9,
                        Name = "Wipro 20 W Globe B22 LED Bulb (White, Pack of 6)",
                        Price = 1789,
                        Description = "Electronics",
                        ImageName = ImageToBinary(@"src\Image\led.png"),
                        Rating = 4.4
                        },
                        new Products
                        {
                        ProductId = 10,
                        Name = "Voltas 1.5 Ton Split Dual Inverter Expandable AC - Red (SAC 185V PZY-R (R32))",
                        Price = 40599,
                        Description = "Electronics",
                        ImageName = ImageToBinary(@"src\Image\ac.png"),
                        Rating = 4.4
                        },
                        new Products
                        {
                        ProductId = 11,
                        Name = "Onion 1 kg Fresh Imported From Nepal A Grade FCCAI",
                        Price = 16,
                        Description = "vegetables",
                        ImageName = ImageToBinary(@"src\Image\onion.jpg"),
                        Rating = 4.1
                        },
                        new Products
                        {
                        ProductId = 12,
                        Name = "Carrot 500 g  Fresh Imported From Netherlands A Grade FCCAI",
                        Price = 25,
                        Description = "vegetables",
                        ImageName = ImageToBinary(@"src\Image\carrot.jpg"),
                        Rating = 4.1
                        },
                        new Products
                        {
                        ProductId = 13,
                        Name = "Tomato - Hybrid 1 kg",
                        Price = 23,
                        Description = "vegetables",
                        ImageName = ImageToBinary(@"src\Image\tomato.jpg"),
                        Rating = 4.1
                        },
                        new Products
                        {
                        ProductId = 14,
                        Name = "Potato 1 kg",
                        Price = 30,
                        Description = "vegetables",
                        ImageName = ImageToBinary(@"src\Image\potato.jpg"),
                        Rating = 4.1
                        },
                        new Products
                        {
                        ProductId = 15,
                        Name = "Cabbage 1 kg",
                        Price = 35,
                        Description = "vegetables",
                        ImageName = ImageToBinary(@"src\Image\cabbage.jpg"),
                        Rating = 4.1
                        },
                        new Products
                        {
                        ProductId = 16,
                        Name = "Prakasam Cotton Solid Men Dhoti",
                        Price = 495,
                        Description = "clothing",
                        ImageName = ImageToBinary(@"src\Image\dhoti.jpg"),
                        Rating = 4.3
                        },
                        new Products
                        {
                        ProductId = 17,
                        Name = "Men Solid Cotton Blend Straight Kurta (Maroon)",
                        Price = 800,
                        Description = "clothing",
                        ImageName = ImageToBinary(@"src\Image\kurta.jpg"),
                        Rating = 4.6
                        },
                        new Products
                        {
                        ProductId = 18,
                        Name = "Slim Men Light Blue Jeans",
                        Price = 1400,
                        Description = "clothing",
                        ImageName = ImageToBinary(@"src\Image\jeans.jpg"),
                        Rating = 4.1
                        },
                        new Products
                        {
                        ProductId = 19,
                        Name = "Self Design Banarasi Cotton Silk Saree (Multicolor)",
                        Price = 2400,
                        Description = "clothing",
                        ImageName = ImageToBinary(@"src\Image\saree.jpg"),
                        Rating = 4.2
                        },
                        new Products
                        {
                        ProductId = 20,
                        Name = "Full Sleeve Printed Men Sweatshirt",
                        Price = 1300,
                        Description = "clothing",
                        ImageName = ImageToBinary(@"src\Image\sweatshirt.jpeg"),
                        Rating = 4.0
                        },
                        new Products
                        {
                        ProductId = 21,
                        Name = "India Gate Regular Choice Basmati Rice (5 kg)",
                        Price = 650,
                        Description = "Grocery",
                        ImageName = ImageToBinary(@"src\Image\rice.jpg"),
                        Rating = 4.0
                        },
                        new Products
                        {
                        ProductId = 22,
                        Name = "PARLE glucose biscuit (1560 g, Pack of 24)",
                        Price = 255,
                        Description = "Grocery",
                        ImageName = ImageToBinary(@"src\Image\parleg.jpg"),
                        Rating = 4.3
                        },
                        new Products
                        {
                        ProductId = 23,
                        Name = "Amul Pasteurised Salted Butter (500 g)",
                        Price = 180,
                        Description = "Grocery",
                        ImageName = ImageToBinary(@"src\Image\butter.jpg"),
                        Rating = 4.4
                        },
                        new Products
                        {
                        ProductId = 24,
                        Name = "Varahi Yellow Moong Dal (Split) (6 kg)",
                        Price = 889,
                        Description = "Grocery",
                        ImageName = ImageToBinary(@"src\Image\dal.jpg"),
                        Rating = 4.4
                        },
                        new Products
                        {
                        ProductId = 25,
                        Name = "Haldiram's Bhujia Sev (1 kg)",
                        Price = 215,
                        Description = "Grocery",
                        ImageName = ImageToBinary(@"src\Image\haldiram.jpg"),
                        Rating = 4.2
                        },
                        new Products
                        {
                        ProductId = 26,
                        Name = "ADIDAS XT WHITE English Willow Cricket Bat (1-1.1 kg)",
                        Price = 6600,
                        Description = "Sports",
                        ImageName = ImageToBinary(@"src\Image\bat.jpg"),
                        Rating = 4.2
                        },
                        new Products
                        {
                        ProductId = 27,
                        Name = "Yonex T Rqts E Zone 100 Green Unstrung Tennis Racquet (Pack of: 1, 285 g)",
                        Price = 6869,
                        Description = "Sports",
                        ImageName = ImageToBinary(@"src\Image\tennis.jpg"),
                        Rating = 4.4
                        },
                        new Products
                        {
                        ProductId = 28,
                        Name = "Nivia Storm Football - Size: 5 (Pack of 1, Multicolor)",
                        Price = 3200,
                        Description = "Sports",
                        ImageName = ImageToBinary(@"src\Image\football.jpeg"),
                        Rating = 4.3
                        },
                        new Products
                        {
                        ProductId = 29,
                        Name = "SNS xeon Hockey Stick - 36 inch (Black, Yellow)",
                        Price = 789,
                        Description = "Sports",
                        ImageName = ImageToBinary(@"src\Image\hockey.jpg"),
                        Rating = 4.0
                        },
                        new Products
                        {
                        ProductId = 30,
                        Name = "Kiwi Premium 32inch Round Pocket Carrom Board with Wooden Coins ,Striker & Disco powder 81.28 cm Carrom Board (Yellow)",
                        Price = 1149,
                        Description = "Sports",
                        ImageName = ImageToBinary(@"src\Image\carrom.jpg"),
                        Rating = 4.1
                        }
                };
        }
    }
}
