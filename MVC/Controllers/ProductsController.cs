using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {

        public async Task<IActionResult> Index()
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                List<Products> productsList = new List<Products>();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/products"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        productsList = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    }
                }
                return View(productsList.Take(12));
            }

        }

        public async Task<IActionResult> ViewProduct(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else {
                IEnumerable<VendorStocks> vendorStocks = new List<VendorStocks>();
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                Products getProduct = new Products();
               
                IEnumerable<Vendors> vendorList = new List<Vendors>();


                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        getProduct = JsonConvert.DeserializeObject<Products>(apiResponse);
                    }
                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/vendors/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        vendorList = JsonConvert.DeserializeObject<IEnumerable<Vendors>>(apiResponse);
                    }
                   
                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/vendorstock/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        vendorStocks = JsonConvert.DeserializeObject<IEnumerable<VendorStocks>>(apiResponse);
                    }
                }
                TempData["ProductId"] = id;
                //double amount = getProduct.Price;
                //ViewBag.price = amount;
                ProductViewModel productModel = new ProductViewModel();

                //product is out of stock
                if (vendorList == null)
                {
                    productModel.product = getProduct;
                    productModel.DeliveryDate = DateTime.UtcNow.AddDays(12);
                    productModel.VendorStocks = vendorStocks;
                }
                else
                {
                    productModel.product = getProduct;
                    productModel.DeliveryDate = DateTime.UtcNow.AddDays(12);
                    productModel.Vendors = vendorList;
                    productModel.VendorStocks = vendorStocks;
                }
                return View(productModel);
            }

                
        }



        [HttpPost]
        public async Task<ActionResult> ViewProduct(ProductViewModel model)
        {
            IEnumerable<VendorStocks> vendorStocks = new List<VendorStocks>();
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            int productId = (int)TempData["ProductId"];
            //TempData.Keep("ProductId");
            Products getProduct = new Products();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/" + productId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    getProduct = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
                using (var response = await httpClient.GetAsync("https://localhost:44307/api/vendorstock/" + productId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vendorStocks = JsonConvert.DeserializeObject<IEnumerable<VendorStocks>>(apiResponse);
                }
            }
            if (model.VendorId != 0)
            {
                foreach (var stockItem in vendorStocks)
                {
                    if (stockItem.VendorId == model.VendorId)
                    {
                        if (model.Quantity > stockItem.StockInHand)
                        {
                            TempData["QuantityMsg"] = "<script>alert('Quantity should be within selected vendor stock')</script>";
                            return RedirectToAction("ViewProduct", productId);
                        }
                    }
                }
                Carts cartItem = new Carts();
                Carts cartReturned = new Carts();
                cartItem.ProductId = productId;
                cartItem.ZipCode = model.ZipCode;
                cartItem.DeliveryDate = model.DeliveryDate;
                cartItem.VendorId = model.VendorId;
                cartItem.Quantity = model.Quantity;
                cartItem.Price = getProduct.Price;
                StringContent content = new StringContent(JsonConvert.SerializeObject(cartItem), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.PostAsync("https://localhost:44307/api/carts/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cartReturned = JsonConvert.DeserializeObject<Carts>(apiResponse);
                    }
                }
                if (cartReturned == null)
                    return Content("There is some issue");
                return RedirectToAction("Index", "Carts");
            }
            else
            {
                WishLists wishlistItem = new WishLists()
                {
                    VendorId = model.VendorId,
                    ProductId = productId,
                    Quantity = model.Quantity,
                    DateAdded = DateTime.UtcNow,
                    CustomerId = (int)HttpContext.Session.GetInt32("customerId")
                };
                WishLists returnedItem = new WishLists();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                   
                    StringContent content = new StringContent(JsonConvert.SerializeObject(wishlistItem), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44307/api/wishlist/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        returnedItem = JsonConvert.DeserializeObject<WishLists>(apiResponse);
                    }


                }


                if (returnedItem == null)
                    return Content("There is some issue");
                return RedirectToAction("Index", "Wishlist");
            }
        }


        public async Task<IActionResult> SerachProductByName(string item)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                IEnumerable<Products> prod = new List<Products>();
                using (var httpClient = new HttpClient(clientHandler))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/" + item))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        prod = JsonConvert.DeserializeObject<IEnumerable<Products>>(apiResponse);
                    }
                }
                return View("Index", prod);
            }
               
        }

        public async Task<ActionResult> SerachProductByCategory(string name)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                IEnumerable<Products> products = new List<Products>();
                using (var httpClient = new HttpClient(clientHandler))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/GetProductsByCategory/" + name))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<IEnumerable<Products>>(apiResponse);
                    }
                }

                return View("Index", products);
            }
                
        }

        //[HttpPost]
        //public async Task<ActionResult> ViewProduct(ProductViewModel model)
        //{
        //    int productId = (int)TempData["ProductId"];
        //    //TempData.Keep("ProductId");
        //    Products getProduct = new Products();
        //    using (var httpClient = new HttpClient(clientHandler))
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/" + productId))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            getProduct = JsonConvert.DeserializeObject<Products>(apiResponse);
        //        }
        //    }
        //    if (model.VendorId != 0)
        //    {
        //        Carts cartItem = new Carts();
        //        Carts cartReturned = new Carts();
        //        cartItem.ProductId = productId;
        //        cartItem.ZipCode = model.ZipCode;
        //        cartItem.DeliveryDate = model.DeliveryDate;
        //        cartItem.VendorId = model.VendorId;
        //        cartItem.Quantity = model.Quantity;
        //        cartItem.Price = getProduct.Price;
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(cartItem), Encoding.UTF8, "application/json");
        //        using (var httpClient = new HttpClient(clientHandler))
        //        {
        //            using (var response = await httpClient.PostAsync("https://localhost:44307/api/carts/", content))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                cartReturned = JsonConvert.DeserializeObject<Carts>(apiResponse);
        //            }
        //        }
        //        if (cartReturned == null)
        //            return Content("There is some issue");
        //        return RedirectToAction("Index", "Carts");
        //    }
        //    else
        //    {
        //        WishLists wishlistItem = new WishLists()
        //        {
        //            VendorId = model.VendorId,
        //            ProductId = productId,
        //            Quantity = model.Quantity,
        //            DateAdded = DateTime.UtcNow,
        //            CustomerId = HttpContext.Session.GetInt32("customerId")
        //        };
        //        WishLists returnedItem = new WishLists();
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(wishlistItem), Encoding.UTF8, "application/json");
        //        using (var httpClient = new HttpClient(clientHandler))
        //        {
        //            using (var response = await httpClient.PostAsync("https://localhost:44307/api/wishlist/", content))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                returnedItem = JsonConvert.DeserializeObject<WishLists>(apiResponse);
        //            }
        //        }
        //        if (returnedItem == null)
        //            return Content("There is some issue");
        //        return RedirectToAction("Index", "Wishlist");
        //    }


        //}


        //[HttpGet]
        //public async Task<IActionResult> ViewProduct(int id)
        //{
        //    Products getProduct = new Products();
        //    IEnumerable<Vendors> vendorList = new List<Vendors>();
        //    using (var httpClient = new HttpClient(clientHandler))
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            getProduct = JsonConvert.DeserializeObject<Products>(apiResponse);
        //        }
        //        using (var response = await httpClient.GetAsync("https://localhost:44307/api/vendors/" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            vendorList = JsonConvert.DeserializeObject<IEnumerable<Vendors>>(apiResponse);
        //        }
        //    }
        //    TempData["ProductId"] = id;
        //    //double amount = getProduct.Price;
        //    //ViewBag.price = amount;
        //    ProductViewModel productModel = new ProductViewModel();

        //    //product is out of stock
        //    if (vendorList == null)
        //    {
        //        productModel.product = getProduct;
        //        productModel.DeliveryDate = DateTime.UtcNow.AddDays(12);
        //    }
        //    else
        //    {
        //        productModel.product = getProduct;
        //        productModel.DeliveryDate = DateTime.UtcNow.AddDays(12);
        //        productModel.Vendors = vendorList;
        //    }
        //    return View(productModel);
        //}

        //public async Task<IActionResult> Index()
        //{

        //    if (HttpContext.Session.GetString("customerName") == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }
        //    else
        //    {
        //        List<Products> ProductsList = new List<Products>();
        //        using (var httpClient = new HttpClient(clientHandler))
        //        {
        //            using (var response = await httpClient.GetAsync("http://localhost:53426/api/Products"))
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                ProductsList = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
        //            }

        //        }

        //        return View(ProductsList.Take(12));
        //    }

        //}

    }
}
