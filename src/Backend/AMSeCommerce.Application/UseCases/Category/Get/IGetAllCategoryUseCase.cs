using AMSeCommerce.Communication.Response.Category;

namespace AMSeCommerce.Application.UseCases.Category.Get;

public interface IGetAllCategoryUseCase
{
    Task<IList<ResponseCategoryJson>> Execute();
}