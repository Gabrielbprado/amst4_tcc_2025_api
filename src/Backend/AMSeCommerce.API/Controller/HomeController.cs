using AMSeCommerce.Application.UseCases.Home;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class HomeController : AmsEcommerceBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetHomeSections([FromServices] IHomeSectionsUseCase useCase)
    {
        var result = await useCase.GetHomeSections();
        return Ok(result);
    }
}