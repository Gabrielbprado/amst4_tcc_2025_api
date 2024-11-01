using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.Storage;

public interface IBlobStorageService
{
    Task<string> Upload(Customers user, Stream file, string fileName);
}