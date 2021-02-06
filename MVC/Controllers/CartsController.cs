using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class CartsController : Controller
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

                IEnumerable<Carts> cartItems = new List<Carts>();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/carts"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cartItems = JsonConvert.DeserializeObject<IEnumerable<Carts>>(apiResponse);
                    }
                }
                var distinctProductIds = cartItems.Select(p => p.ProductId).Distinct().ToList();
                List<Carts> distinctItems = new List<Carts>();
                foreach (var id in distinctProductIds)
                {
                    int q = 0;
                    foreach (var item in cartItems)
                    {
                        if (item.ProductId == id)
                        {
                            q += item.Quantity;
                        }
                    }
                    Carts obj = cartItems.Where(p => p.ProductId == id).FirstOrDefault();
                    obj.Quantity = q;
                    distinctItems.Add(obj);
                }



                return View(distinctItems);
            }
                
        }



        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                Carts deletedCart = new Carts();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await httpClient.DeleteAsync("https://localhost:44307/api/carts/" + id))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        deletedCart = JsonConvert.DeserializeObject<Carts>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
               
        }



        public async Task<IActionResult> Checkout()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                IEnumerable<Carts> list = new List<Carts>();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/carts"))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<IEnumerable<Carts>>(apiResponse);
                    }
                }



                //to deduct quantity of ordered products from db
                foreach (var item in list)
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                        using (var response = await httpClient.PutAsync("https://localhost:44307/api/vendorstock/", content))
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //cartReturned = JsonConvert.DeserializeObject<Cart>(apiResponse);
                        }
                    }
                }



                //to delete items from cart
                bool isCartEmpty;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.DeleteAsync("https://localhost:44307/api/carts"))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        isCartEmpty = JsonConvert.DeserializeObject<bool>(apiResponse);
                    }
                }
                return View();
            }

                
        }



        public async Task<IActionResult> IncreaseCartItem(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                Carts cartObj = new Carts();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/carts/" + id))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cartObj = JsonConvert.DeserializeObject<Carts>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
               
        }
        public async Task<IActionResult> DecreaseFromCart(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                Carts cartObj = new Carts();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/wishlist/" + id))
                    {


                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cartObj = JsonConvert.DeserializeObject<Carts>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
               
        }
    }
}
