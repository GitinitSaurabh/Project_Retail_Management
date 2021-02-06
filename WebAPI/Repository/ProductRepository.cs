using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IConfiguration Configuration { get; }
        private readonly ProductRetailManagementDBContext _context;
        public ProductRepository(ProductRetailManagementDBContext context, IConfiguration configuration)
        {
            this.Configuration = configuration;
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetProductByCategory(string name)
        {
            return await _context.Products.Where(p => p.Description.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public Products GetProductById(int id)
        {
            return _context.Products.Where(p => p.ProductId.Equals(id)).SingleOrDefault();
        }

        public async Task<IEnumerable<Products>> GetProductByName(string name)
        {         
            var List = await _context.Products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            return List;
        }

        public string AddProductRating(int id, Products products)
        {           

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return "Product Not Found!";
                }
                else
                {
                    throw;
                }
            }
            return "Rating Added!";
        }
        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

       
    }
}
