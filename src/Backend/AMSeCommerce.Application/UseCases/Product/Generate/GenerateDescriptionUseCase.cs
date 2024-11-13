using AMSeCommerce.Domain.Services.GPT;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.Application.UseCases.Product.Generate;

public class GenerateDescriptionUseCase(IGenerateDescriptionAi generateDescriptionAi) : IGenerateDescriptionUseCase
{
    private readonly IGenerateDescriptionAi _generateDescriptionAi = generateDescriptionAi;
    public Task<string> Execute(string request)
    {
        return _generateDescriptionAi.GenerateDescription(request);
    }
}