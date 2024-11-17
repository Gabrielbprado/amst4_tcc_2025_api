using AMSeCommerce.Communication.Request.Product;

namespace AMSeCommerce.Application.UseCases.Product.Update;

public interface IUpdateProductUseCase
{
    Task Execute(RequestProductJson product);
}