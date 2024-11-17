using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Domain.Contracts.Order;

public interface IOrderWriteOnlyRepository
{
    Task CreateOrder(Entities.Order order);
    void UpdateOrderStatus(Entities.Order order);
}