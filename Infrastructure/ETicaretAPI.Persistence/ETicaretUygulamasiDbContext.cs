using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence
{
    public class ETicaretUygulamasiDbContext : DbContext
    {
        public ETicaretUygulamasiDbContext(DbContextOptions options) : base(options)
        {
        }
        public  DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public  DbSet<Customer> Customers { get; set; }
  
    }
}
