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
    [Authorize]
    [ApiController]
    public class VendorStockController : ControllerBase
    {
        private readonly IVendorStockRepository repository;



        public VendorStockController(IVendorStockRepository repo)
        {
            repository = repo;
        }
        [HttpPut]
        public async Task<ActionResult<VendorStocks>> UpdateVendorStock(Carts cart)
        {
            var stock = await repository.UpdateStock(cart);
            return Ok(stock);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VendorStocks>>> GetProductQuantity(int id)
        {
            return Ok(await repository.GetProdQuantity(id));
        }
    }
}