using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.User;

public interface IUserUpdateOnlyRepository
{
    void Update(Customers customers);
}