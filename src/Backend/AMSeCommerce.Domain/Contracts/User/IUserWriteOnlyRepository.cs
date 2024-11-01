using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.User;

public interface IUserWriteOnlyRepository
{
    Task Add(Customers customer);
}