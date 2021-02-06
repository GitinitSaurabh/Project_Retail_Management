using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    //[System.Web.Http.Route("[controller]/[action]")]
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ProductRetailManagementDBContext _context;
        public IConfiguration Configuration { get; }

        public AccountController(ProductRetailManagementDBContext context, IConfiguration configuration)
        {
            this.Configuration = configuration;
            _context = context;
        }


      

        public Customers GetCustomer(string username, string password)
        {
            var customer = _context.Customers.Where(x => x.Email == username && x.Password == password).SingleOrDefault();            
            return customer;
        }
    }
}
