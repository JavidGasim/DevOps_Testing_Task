using DevOps_Testing_Task.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Testing_Task.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    }
}
