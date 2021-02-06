using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class WishlistController : Controller
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
                IEnumerable<WishLists> items = new List<WishLists>();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);



                    using (var response = await httpClient.GetAsync("https://localhost:44307/api/wishlist"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<IEnumerable<WishLists>>(apiResponse);
                    }
                    foreach (WishLists modelObject in items)
                    {
                        Products prod = new Products();
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);



                        using (var response = await httpClient.GetAsync("https://localhost:44307/api/products/" + modelObject.ProductId))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            prod = JsonConvert.DeserializeObject<Products>(apiResponse);
                        }
                        modelObject.Product = prod;
                    }
                }
                return View(items);
            }
               
        }



        public async Task<IActionResult> DeleteFromWishlist(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            
            if (accessToken == null)
            {
                return RedirectToAction("Index", "Account");
            }

            else
            {
                WishLists deletedItem = new WishLists();
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    using (var response = await httpClient.DeleteAsync("https://localhost:44307/api/wishlist/" + id))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        deletedItem = JsonConvert.DeserializeObject<WishLists>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }

                
        }
    }
       
}

