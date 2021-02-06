using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<IEnumerable<Products>> GetProductByName(string name);
        Products GetProductById(int id);
        string AddProductRating(int id, Products products);
        Task<IEnumerable<Products>> GetProductByCategory(string name);

    }
}
