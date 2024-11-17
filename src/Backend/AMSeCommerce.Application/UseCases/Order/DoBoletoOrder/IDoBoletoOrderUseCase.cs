using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.DoBoletoOrder;

public interface IDoBoletoOrderUseCase
{
    Task<ResponseBoletoJson> Execute(RequestOrderJson request);
}