namespace AMSeCommerce.Domain.Contracts.Product;

public interface IProductReadOnlyRepository
{
    Task<List<Entities.Product>> GetProducts();
    Task<Entities.Product> GetById(long requestProductId);
}