namespace AMSeCommerce.Application.UseCases.ShoppingCart.Delete;

public interface IRemoveProductToCartUseCase
{
    Task Execute(long id);
}