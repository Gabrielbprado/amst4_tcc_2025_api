using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class ProductRepository(AmsEcommerceContext context) : IProductWriteOnlyRepository, IProductReadOnlyRepository
{
    public async Task AddProduct(Product product) => await context.Products.AddAsync(product);
    public async Task<List<Product>> GetProducts() => await context.Products.ToListAsync();
    public async Task<Product> GetById(long requestProductId) => await context.Products.FirstOrDefaultAsync(x => x.Id == requestProductId);
}