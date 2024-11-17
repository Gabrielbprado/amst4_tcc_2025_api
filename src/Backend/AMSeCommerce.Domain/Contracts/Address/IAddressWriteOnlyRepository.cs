namespace AMSeCommerce.Domain.Contracts.Address;

public interface IAddressWriteOnlyRepository
{
    Task AddAsync(Entities.Address address);
}