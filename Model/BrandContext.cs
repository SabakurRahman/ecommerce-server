using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Project.Model
{
    public class BrandContext : DbContext
    {

        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {
            
        }
        public DbSet<Brand> Brands { get; set; }

        internal Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
