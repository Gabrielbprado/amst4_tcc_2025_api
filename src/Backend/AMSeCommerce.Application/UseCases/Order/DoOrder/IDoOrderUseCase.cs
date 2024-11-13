using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.DoOrder;

public interface IDoOrderUseCase
{
    Task<ResponsePixJson> Execute(RequestOrderJson request);
}