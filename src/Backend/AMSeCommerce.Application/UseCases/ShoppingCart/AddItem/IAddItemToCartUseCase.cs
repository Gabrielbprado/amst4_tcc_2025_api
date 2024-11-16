using AMSeCommerce.Communication.Request.ShoppingCart;

namespace AMSeCommerce.Application.UseCases.ShoppingCart.AddItem;

public interface IAddItemToCartUseCase
{
    Task Execute(RequestAddItemToCartJson request);
}