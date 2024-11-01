using AMSeCommerce.Communication.Request.Category;
using AMSeCommerce.Communication.Response.Category;

namespace AMSeCommerce.Application.UseCases.Category;

public interface IRegisterCategoryUseCase
{
    Task<ResponseCategoryJson> Execute(RequestCategoryJson request);
}