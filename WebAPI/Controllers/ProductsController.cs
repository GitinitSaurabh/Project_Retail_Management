using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Models;
using WebAPI.Repository;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private IProductRepository ProductRepository;

        private IWebHostEnvironment webHostEnvironment;
        public ProductsController(IProductRepository repo, IWebHostEnvironment environment)
        {
            ProductRepository = repo;
            webHostEnvironment = environment;
            
        }
        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await ProductRepository.GetAllProducts();
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Products>>> SearchProductByName(string name)
        {
            var products = await ProductRepository.GetProductByName(name);
            if (products == null)
            {
                return BadRequest("Products Not Found, Please Try Again");
            }
            return Ok(products);
        }
               
       
        [HttpPost]
        public IActionResult AddProductRating(int id, [FromBody] Products products)
        {
            var returnMsg = ProductRepository.AddProductRating(id, products);
            if (returnMsg == "Rating Added!")
            {
                return Ok(returnMsg);
            }
            else
            {
                return BadRequest(returnMsg);
            }
        }
        [HttpGet("{id:int}")]
        public Products SearchProductById(int id)
        {
            var product = ProductRepository.GetProductById(id);
            //if (product == null)
            //{
            //    return BadRequest("Products Not Found, Please Try Again");
            //}
            return product;
        }

        [Route("GetProductsByCategory/{name}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> SearchProductByCategory(string name)
        {
            var products = await ProductRepository.GetProductByCategory(name);
            if (products == null)
            {
                return BadRequest("Products Not Found, Please Try Again");
            }
            return Ok(products);
        }

    }
}