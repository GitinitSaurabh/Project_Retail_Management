using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class VendorRepository : IVendorRepository
    {
        public IConfiguration Configuration { get; }
        private readonly ProductRetailManagementDBContext _context;
        public VendorRepository(ProductRetailManagementDBContext context, IConfiguration configuration)
        {
            this.Configuration = configuration;
            _context = context;
        }


        public async Task<IEnumerable<Vendors>> GetAllVendorDetails(int prodId)
        {
            var vendorIds = _context.VendorStocks.Where(v => v.ProductId == prodId && v.StockInHand > 0).Select(x => x.VendorId).ToList();
            return await _context.Vendors.Where(v => vendorIds.Contains(v.VendorId)).OrderBy(x => x.VendorId).ToListAsync();
        }
    }
}
