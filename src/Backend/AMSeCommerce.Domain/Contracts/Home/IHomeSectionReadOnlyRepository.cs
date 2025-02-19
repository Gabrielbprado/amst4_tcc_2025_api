using AMSeCommerce.Communication.Response.Home;
using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Domain.Contracts.Home;

public interface IHomeSectionReadOnlyRepository
{
    Task<List<HomeSection>> GetHomeSections();
}