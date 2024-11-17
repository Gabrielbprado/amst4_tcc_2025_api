using AMSeCommerce.Communication.Request.Category;
using AMSeCommerce.Communication.Response.Category;

namespace AMSeCommerce.Application.UseCases.Category.Register;

public interface IRegisterCategoryUseCase
{
    Task<ResponseCategoryJson> Execute(RequestCategoryJson request);
}