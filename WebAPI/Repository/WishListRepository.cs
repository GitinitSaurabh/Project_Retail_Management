using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly ProductRetailManagementDBContext context;
        public WishListRepository(ProductRetailManagementDBContext _context)
        {
            context = _context;
        }
        public async Task<WishLists> AddToWishlist(WishLists item)
        {
            await context.WishLists.AddAsync(item);
            int a = await context.SaveChangesAsync();

            if (a == 1)
                return item;

            else
                return null;
        }



        public async Task<WishLists> DeleteFromWishlist(int id)
        {
            WishLists item = context.WishLists.Find(id);
            context.WishLists.Remove(item);
            await context.SaveChangesAsync();
            return item;
        }



        public async Task<IEnumerable<WishLists>> GetAllWishlistItems()
        {            
            return await context.WishLists.ToListAsync();

        }
        public async Task<Carts> DecreaseQuantity(int id)
        {
            Carts cartObject = context.Carts.Find(id);
            cartObject.Quantity--;
            context.Carts.Update(cartObject);
            await context.SaveChangesAsync();
            return cartObject;
        }
    }
}
