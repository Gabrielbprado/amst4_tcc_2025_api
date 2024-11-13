using AMSeCommerce.Application.UseCases.Product.Generate;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class GptController : AmsEcommerceBaseController
{
    [HttpPost]
    public async Task<IActionResult> Generate([FromServices] IGenerateDescriptionUseCase useCase, [FromBody] string request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
}