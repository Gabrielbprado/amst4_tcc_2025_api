using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.ShoppingCart.Get;

public interface IGetCartUseCase
{
    Task<IList<ResponseProductJson>> Execute();
}