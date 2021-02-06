using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class VendorStockRepository : IVendorStockRepository
    {
        private readonly ProductRetailManagementDBContext context;
        public VendorStockRepository(ProductRetailManagementDBContext _context)
        {
            context = _context;
        }
        public async Task<VendorStocks> UpdateStock(Carts cart)
        {
            VendorStocks stock = await context.VendorStocks.Where(v => (v.VendorId == cart.VendorId) && (v.ProductId == cart.ProductId))
                                                        .Include(p => p.Product).Include(v => v.Vendor).SingleOrDefaultAsync();
            stock.StockInHand -= cart.Quantity;
            context.VendorStocks.Update(stock);
            context.SaveChanges();
            return stock;
        }
        public async Task<IEnumerable<VendorStocks>> GetProdQuantity(int prodId)
        {
           
            return await context.VendorStocks.Where(v => v.ProductId == prodId).ToListAsync();
        }
    }
}
