using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.Product.Generate;
using AMSeCommerce.Communication.Request.GPT;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class GptController : AmsEcommerceBaseController
{
    [HttpPost]
    [AuthenticatedUser]
    public async Task<IActionResult> Generate([FromServices] IGenerateDescriptionUseCase useCase, [FromBody] RequestGenerateDescription request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty,response);
    }
}