using AMSeCommerce.Domain.Contracts.User;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class UserRepository(AmsEcommerceContext context) : IUserWriteOnlyRepository, IUserReadOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task Add(Customers customer) => await _context.Customers.AddAsync(customer);

    public async Task<bool> ExistsByEmail(string requestEmail) =>
        await _context.Customers.AnyAsync(u => u.Email == requestEmail);

    public async Task<Customers> GetByEmail(string email) =>
        await _context.Customers.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> ExistUserActiveWithId(Guid userIdentifier) =>
        await _context.Customers.AnyAsync(u => u.UserIdentifier == userIdentifier);

    public async Task<Customers> GetById(long userId) => await _context.Customers.FirstAsync(u => u.Id.Equals(userId));
    public void Update(Customers customers) => _context.Customers.Update(customers);
}