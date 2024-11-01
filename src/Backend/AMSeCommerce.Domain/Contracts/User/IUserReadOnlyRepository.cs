using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.User;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistsByEmail(string requestEmail);
    Task<Customers> GetByEmail(string email);
    Task<bool> ExistUserActiveWithId(Guid userIdentifier);
    Task<Customers> GetById(long userId);
}