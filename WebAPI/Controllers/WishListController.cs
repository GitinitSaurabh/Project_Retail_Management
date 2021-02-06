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
    public class WishListController : ControllerBase
    {
        private readonly IWishListRepository repository;
        public WishListController(IWishListRepository repo)
        {
            repository = repo;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishLists>>> GetWishlistItems()
        {
            var items = await repository.GetAllWishlistItems();
            if (items == null)
                return NotFound();



            return Ok(items);
        }



        [HttpPost]
        public async Task<ActionResult<WishLists>> AddToWishlist(WishLists item)
        {
            WishLists addedItem = await repository.AddToWishlist(item);
            if (addedItem.Equals(0))
                return BadRequest("No items added");
            return Ok(addedItem);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Carts>> DeleteItemFromWishlist(int id)
        {
            WishLists deletedItem = await repository.DeleteFromWishlist(id);
            if (deletedItem == null)
                return BadRequest("No items deleted");
            return Ok(deletedItem);
        }



        //[Route("api/cart/decreaseitem/")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Carts>> DecreaseItem(int id)
        {
            return Ok(await repository.DecreaseQuantity(id));
        }
    }
}