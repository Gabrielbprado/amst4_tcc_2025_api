namespace AMSeCommerce.Domain.Contracts.ShoppingCart;

public interface IShoppingCartWriteOnlyRepository
{
    Task AddItemToCart(Entities.ShoppingCart shoppingCart);
}