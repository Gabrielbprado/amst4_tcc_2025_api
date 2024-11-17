using AMSeCommerce.Domain.Contracts.Order;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class OrderRepository(AmsEcommerceContext context) : IOrderWriteOnlyRepository, IOrderReadOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task CreateOrder(Order order) => await _context.Orders.AddAsync(order);
    public void UpdateOrderStatus(Order order) => _context.Orders.Update(order);

    public Task<List<Order>> GetOrders(long userId) => _context.Orders.Where(o => o.UserId == userId).ToListAsync();
    public Task<Order> GetOrderByTransactionId(long pixJsonTransactionId) => _context.Orders.FirstOrDefaultAsync(o => o.PaymentMethodId == pixJsonTransactionId);
} 