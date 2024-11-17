namespace AMSeCommerce.Domain.Contracts.Product;

public interface IProductReadOnlyRepository
{
    Task<List<Entities.Product>> GetProducts();
    Task<Entities.Product> GetById(long requestProductId);
    Task<List<Entities.Product>> GetProductsBySeller(long id);
    Task<List<Entities.ProductImage>> GetProductImages(long productId);
    Task<List<Entities.Product>> GetProductsByCategory(long categoryId);
}