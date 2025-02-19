using AMSeCommerce.Communication.Response.Home;
using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Application.UseCases.Home;

public interface IHomeSectionsUseCase
{
    Task<List<ResponseHomeSectionJson>> GetHomeSections();
}