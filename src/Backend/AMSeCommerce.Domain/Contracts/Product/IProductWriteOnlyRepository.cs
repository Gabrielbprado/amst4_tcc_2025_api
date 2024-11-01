namespace AMSeCommerce.Domain.Contracts.Product;

public interface IProductWriteOnlyRepository
{
    Task AddProduct(Domain.Entities.Product product);
    Task<IEnumerable<Entities.Product>> GetProducts();
}