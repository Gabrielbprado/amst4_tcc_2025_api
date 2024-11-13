using AMSeCommerce.Domain.Contracts.ShoppingCart;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;

namespace AMSeCommerce.Infrastructure.Repositories;

public class ShoppingCartRepository(AmsEcommerceContext context) : IShoppingCartWriteOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task AddItemToCart(ShoppingCart shoppingCart) => await _context.ShoppingCart.AddAsync(shoppingCart);
}