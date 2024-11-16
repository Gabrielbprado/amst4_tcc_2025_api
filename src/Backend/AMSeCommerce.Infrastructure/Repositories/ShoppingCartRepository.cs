using AMSeCommerce.Domain.Contracts.ShoppingCart;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class ShoppingCartRepository(AmsEcommerceContext context) : IShoppingCartWriteOnlyRepository,IShoppingCartReadOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task AddItemToCart(ShoppingCart shoppingCart) => await _context.ShoppingCart.AddAsync(shoppingCart);
    public void RemoveProduct(long productId)
    {
        var product = _context.ShoppingCart.FirstOrDefault(x => x.ProductId == productId)!;
        _context.ShoppingCart.Remove(product);
    }

    public void UpdateItemToCart(ShoppingCart existShoppingCart) => _context.ShoppingCart.Update(existShoppingCart);

    public async Task<IList<ShoppingCart>> GetCart(long userId) => await _context.ShoppingCart.Where(x => x.UserId == userId).ToListAsync();
    public async Task<ShoppingCart> GetProduct(long id) => await _context.ShoppingCart.FirstOrDefaultAsync(x => x.ProductId == id);
}