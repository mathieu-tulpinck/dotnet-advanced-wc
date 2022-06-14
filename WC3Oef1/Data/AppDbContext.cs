using Microsoft.EntityFrameworkCore;
using WC3Oef1.Models;

namespace WC3Oef1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
