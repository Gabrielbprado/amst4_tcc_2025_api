using AMSeCommerce.Communication.Request.GPT;
using AMSeCommerce.Communication.Response.GPT;

namespace AMSeCommerce.Domain.Services.GPT;

public interface IGenerateDescriptionAi
{
    Task<ResponseGenerateDescription> GenerateDescription(RequestGenerateDescription request);
    Task<ResponseGenerateDescription> GenerateDescriptionLocal(RequestGenerateDescription request);

}