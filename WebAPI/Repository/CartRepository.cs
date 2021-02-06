using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ProductRetailManagementDBContext context;
        public CartRepository(ProductRetailManagementDBContext _context)
        {
            context = _context;
        }
        public async Task<Carts> AddToCart(Carts cart)
        {
            await context.Carts.AddAsync(cart);
            context.SaveChanges();
            return cart;
        }



        public async Task<Carts> DeleteFromCart(int id)
        {
            Carts cartObject = context.Carts.Find(id);
            context.Carts.Remove(cartObject);
            await context.SaveChangesAsync();
            return cartObject;
        }



        public async Task<IEnumerable<Carts>> GetAllCartItems()
        {
            return await context.Carts.Include(p => p.Product).Include(v => v.Vendor).ToListAsync();
        }



        public async Task<bool> DeleteAllCartItems()
        {
            context.Carts.RemoveRange(context.Carts);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Carts> IncreaseQuantity(int id)
        {
            Carts cartObject = context.Carts.Find(id);
            cartObject.Quantity++;
            context.Carts.Update(cartObject);
            await context.SaveChangesAsync();
            return cartObject;
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
