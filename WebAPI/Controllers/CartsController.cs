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
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository repository;
        public CartsController(ICartRepository repo)
        {
            repository = repo;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carts>>> GetCartItems()
        {
            var cartItems = await repository.GetAllCartItems();
            if (cartItems == null)
                return NotFound();



            return Ok(cartItems);
        }



        [HttpPost]
        public async Task<ActionResult<Carts>> AddToCart(Carts cart)
        {
            Carts addedCart = await repository.AddToCart(cart);
            if (addedCart == null)
                return BadRequest("Cart not added");
            return Ok(addedCart);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Carts>> DeleteItemFromCart(int id)
        {
            Carts deletedCart = await repository.DeleteFromCart(id);
            if (deletedCart == null)
                return BadRequest("Cart not deleted");
            return Ok(deletedCart);
        }



        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAllCartItems()
        {
            return Ok(await repository.DeleteAllCartItems());
        }



        [HttpGet("{id}")]

        public async Task<ActionResult<Carts>> IncreaseItem(int id)
        {
            return Ok(await repository.IncreaseQuantity(id));
        }
    }
}