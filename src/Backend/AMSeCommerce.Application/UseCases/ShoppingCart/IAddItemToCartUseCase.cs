using AMSeCommerce.Communication.Request.ShoppingCart;

namespace AMSeCommerce.Application.UseCases.ShoppingCart;

public interface IAddItemToCartUseCase
{
    Task Execute(RequestAddItemToCartJson request);
}