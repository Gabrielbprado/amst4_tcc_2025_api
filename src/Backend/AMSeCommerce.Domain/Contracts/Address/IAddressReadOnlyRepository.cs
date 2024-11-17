namespace AMSeCommerce.Domain.Contracts.Address;

public interface IAddressReadOnlyRepository
{
    Task<Entities.Address> GetAsync(long userId);
}