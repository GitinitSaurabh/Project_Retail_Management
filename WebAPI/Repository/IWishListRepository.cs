using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IWishListRepository
    {
        Task<IEnumerable<WishLists>> GetAllWishlistItems();
        Task<WishLists> AddToWishlist(WishLists item);
        Task<WishLists> DeleteFromWishlist(int id);
        Task<Carts> DecreaseQuantity(int id);
    }
}
