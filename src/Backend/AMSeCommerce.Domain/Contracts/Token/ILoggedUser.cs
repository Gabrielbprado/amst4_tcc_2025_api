using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.Token;

public interface ILoggedUser
{
    Task<Customers?> User();
}