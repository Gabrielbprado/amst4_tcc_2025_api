namespace AMSeCommerce.Domain.Contracts.Order;

public interface IOrderReadOnlyRepository
{
    Task<List<Entities.Order>> GetOrders(long userId);
}