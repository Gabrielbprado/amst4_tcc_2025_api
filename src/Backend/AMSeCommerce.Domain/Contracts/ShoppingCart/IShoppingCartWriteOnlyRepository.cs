namespace AMSeCommerce.Domain.Contracts.ShoppingCart;

public interface IShoppingCartWriteOnlyRepository
{
    Task AddItemToCart(Entities.ShoppingCart shoppingCart);
    void RemoveProduct(long productId);
    void UpdateItemToCart(Entities.ShoppingCart existShoppingCart);
}