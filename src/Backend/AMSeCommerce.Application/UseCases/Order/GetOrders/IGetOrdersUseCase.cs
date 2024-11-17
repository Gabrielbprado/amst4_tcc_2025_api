using AMSeCommerce.Communication.Response.Order;

namespace AMSeCommerce.Application.UseCases.Order.GetOrders;

public interface IGetOrdersUseCase
{
    Task<List<ResponseOrderJson>> Execute();
}