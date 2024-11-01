using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.Category;
using AMSeCommerce.Communication.Request.Category;
using AMSeCommerce.Communication.Response.Category;
using AMSeCommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class CategoryController() : AmsEcommerceBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCategoryJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> Register([FromServices] IRegisterCategoryUseCase useCase,
        [FromBody] RequestCategoryJson request)
    {
        var category = await useCase.Execute(request);
        return Created(string.Empty, category);
    }
}