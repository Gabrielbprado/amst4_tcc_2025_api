using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class ProductRepository(AmsEcommerceContext context) : IProductWriteOnlyRepository
{
    public async Task AddProduct(Product product) => await context.Products.AddAsync(product);
    public async Task<IEnumerable<Product>> GetProducts() => await context.Products.ToListAsync();
}