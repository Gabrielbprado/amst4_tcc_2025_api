using AMSeCommerce.Domain.Contracts.Address;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class AddressRepository(AmsEcommerceContext context) : IAddressWriteOnlyRepository, IAddressReadOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task AddAsync(Address address) => await _context.Address.AddAsync(address);

    public async Task<Address> GetAsync(long id) => await _context.Address.Where(a => a.UserId == id).FirstOrDefaultAsync();
}