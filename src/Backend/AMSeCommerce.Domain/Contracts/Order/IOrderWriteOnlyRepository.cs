namespace AMSeCommerce.Domain.Contracts.Order;

public interface IOrderWriteOnlyRepository
{
    Task CreateOrder(Entities.Order order);
}