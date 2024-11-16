using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.DoCardOrder;

public interface IDoCardOrderUseCase
{
    Task<ResponseCardJson> Execute(RequestOrderJson request);

}