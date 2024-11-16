using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.DoPixOrder;

public interface IDoPixOrderUseCase
{
    Task<ResponsePixJson> Execute(RequestOrderJson request);
}