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

        public DbSet<Member> members { get; set; }
    // : is inheritence
public DbSet<CPW219_eCommerceSite.Models.RegisterViewModel> RegisterViewModel { get; set; } = default!;

    }
}
