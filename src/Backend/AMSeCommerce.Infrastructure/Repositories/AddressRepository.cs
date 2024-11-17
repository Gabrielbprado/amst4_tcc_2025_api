using AMSeCommerce.Domain.Contracts.Address;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;

namespace AMSeCommerce.Infrastructure.Repositories;

public class AddressRepository(AmsEcommerceContext context) : IAddressWriteOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task AddAsync(Address address) => await _context.Address.AddAsync(address);
}