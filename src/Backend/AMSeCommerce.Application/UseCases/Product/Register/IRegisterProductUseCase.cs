using AMSeCommerce.Communication.Request.Product;
using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.Product.Register;

public interface IRegisterProductUseCase
{
    Task<ResponseRegisteredProductJson> Execute(RequestProductJson request);
}