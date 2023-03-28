using Ecommerce_Project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly BrandContext _dbContext;
        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>>GetBrand()
        {
            if(_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Brands.ToListAsync();

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {

            if(_dbContext == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Brands.FindAsync(id);

            if(brand == null)
            {
                return NotFound();
            }

            return brand;
        
        
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> postBrand(Brand brand)
        {

            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrand), new {id=brand.Id},brand);

        }
        


    }
}
