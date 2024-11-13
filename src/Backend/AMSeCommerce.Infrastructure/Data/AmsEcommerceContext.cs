using AMSeCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Data;

public class AmsEcommerceContext(DbContextOptions<AmsEcommerceContext> opts) : DbContext(opts)
{
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCart { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AmsEcommerceContext).Assembly);
    }
}