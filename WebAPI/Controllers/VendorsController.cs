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
    public class VendorsController : ControllerBase
    {
        private IVendorRepository VendorRepository;

        private IWebHostEnvironment webHostEnvironment;
        public VendorsController(IVendorRepository repo, IWebHostEnvironment environment)
        {
            VendorRepository = repo;
            webHostEnvironment = environment;

        }



        // GET: api/Vendors
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Vendors>>> GetVendors(int id)
        {
            var vendors = await VendorRepository.GetAllVendorDetails(id);
            return Ok(vendors);
        }
    }
}