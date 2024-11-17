using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class ProductRepository(AmsEcommerceContext context) : IProductWriteOnlyRepository, IProductReadOnlyRepository
{
    public async Task AddProduct(Product product) => await context.Products.AddAsync(product);
    public async Task AddProductImages(ProductImage productImage) => await context.ProductImages.AddAsync(productImage);
    public void UpdateProduct(Product product) => context.Products.Update(product);
    public void UpdateProductImages(ProductImage productImage) => context.ProductImages.Update(productImage);

    public async Task<List<Product>> GetProducts() => await context.Products.ToListAsync();
    public async Task<Product> GetById(long requestProductId) => await context.Products.FirstOrDefaultAsync(x => x.Id == requestProductId);
    public async Task<List<Product>> GetProductsBySeller(long id) => await context.Products.Where(p => p.UserIdentifier == id).ToListAsync();
    public async Task<List<ProductImage>> GetProductImages(long productId) => await context.ProductImages.Where(p => p.ProductId == productId).ToListAsync();
    public async Task<List<Product>> GetProductsByCategory(long categoryId) => await context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
}