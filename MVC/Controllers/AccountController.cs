using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using System.Text;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private static string WebAPIurl = "https://localhost:44307/";
        
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel user)
        {
           
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");



                using (var response = await httpClient.PostAsync("https://localhost:44307/api/token", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    if (token == "Invalid credentials")
                    {
                        ViewBag.Message = "Incorrect Email and Password";
                        return View();
                    }



                    HttpContext.Session.SetString("JWToken", token);
                }
                return RedirectToAction("GetCustomerDetail", user);
            }
        }
     

        public async Task<IActionResult> GetCustomerDetail(LoginModel model)
        {
            //var tokenBased = string.Empty;
            Customers customer = new Customers();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                var responseMessage = await client.GetAsync(requestUri: "Account/GetCustomer?username=" + model.Username + "&password=" + model.Password);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultMessage = responseMessage.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customers>(resultMessage);
                    //HttpContext.Session.SetString(SessionToken, tokenBased);
                }
            }
            if (customer != null)
            {
                HttpContext.Session.SetString("customerName", customer.FirstName);
                HttpContext.Session.SetInt32("customerId", customer.CustomerId);
                return RedirectToAction("Index", "Products");
            }
            else
                return Content("Invalid Login! Return to Login Page!");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Account");
        }

    }
}
