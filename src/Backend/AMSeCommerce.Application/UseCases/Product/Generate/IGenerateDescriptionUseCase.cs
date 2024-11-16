using AMSeCommerce.Communication.Request.GPT;
using AMSeCommerce.Communication.Response.GPT;

namespace AMSeCommerce.Application.UseCases.Product.Generate;

public interface IGenerateDescriptionUseCase
{
    Task<ResponseGenerateDescription> Execute(RequestGenerateDescription request);
}