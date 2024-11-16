namespace AMSeCommerce.Domain.Contracts.ShoppingCart;

public interface IShoppingCartReadOnlyRepository
{
    Task<IList<Entities.ShoppingCart>> GetCart(long userId);
    Task<Entities.ShoppingCart> GetProduct(long id);
}