using AMSeCommerce.Communication.Request.Product;
using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.Product;

public interface IRegisterProductUseCase
{
    Task<ResponseRegisteredProductJson> Execute(RequestProductJson request);
}