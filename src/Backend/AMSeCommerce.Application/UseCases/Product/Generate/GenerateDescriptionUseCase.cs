using AMSeCommerce.Communication.Request.GPT;
using AMSeCommerce.Communication.Response.GPT;
using AMSeCommerce.Domain.Services.GPT;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.Application.UseCases.Product.Generate;

public class GenerateDescriptionUseCase(IGenerateDescriptionAi generateDescriptionAi) : IGenerateDescriptionUseCase
{
    private readonly IGenerateDescriptionAi _generateDescriptionAi = generateDescriptionAi;
    public Task<ResponseGenerateDescription> Execute(RequestGenerateDescription request)
    {
        return _generateDescriptionAi.GenerateDescription(request);
    }
}