using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.Product;

public interface IProductWriteOnlyRepository
{
    Task AddProduct(Domain.Entities.Product product);
    Task AddProductImages(Domain.Entities.ProductImage productImage);
    void UpdateProduct(Entities.Product product);
    void UpdateProductImages(ProductImage productImage);
}