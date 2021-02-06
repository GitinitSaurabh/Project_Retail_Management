using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface ICartRepository
    {
        Task<IEnumerable<Carts>> GetAllCartItems();
        Task<Carts> AddToCart(Carts cart);
        Task<Carts> DeleteFromCart(int id);
        Task<bool> DeleteAllCartItems();
        Task<Carts> IncreaseQuantity(int id);
        Task<Carts> DecreaseQuantity(int id);
    }
}
