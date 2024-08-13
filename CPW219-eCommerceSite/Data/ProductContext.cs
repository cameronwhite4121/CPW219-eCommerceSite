using CPW219_eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Data
{
    // : is inheritence
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }

    }
}
