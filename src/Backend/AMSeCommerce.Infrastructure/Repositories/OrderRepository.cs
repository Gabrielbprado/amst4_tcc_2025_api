using AMSeCommerce.Domain.Contracts.Order;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;

namespace AMSeCommerce.Infrastructure.Repositories;

public class OrderRepository(AmsEcommerceContext context) : IOrderWriteOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task CreateOrder(Order order) => await _context.Orders.AddAsync(order);
}