using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.Product;
using AMSeCommerce.Communication.Request.Product;
using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class ProductController : AmsEcommerceBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredProductJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterProductUseCase useCase,
        [FromForm] RequestProductJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
}