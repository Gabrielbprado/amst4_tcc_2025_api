using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.Product;
using AMSeCommerce.Application.UseCases.Product.DashBoard;
using AMSeCommerce.Application.UseCases.Product.GetById;
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
    [HttpGet]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFromDashBoard(
        [FromServices] IGetDashBoardProductUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseProductJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFromDashBoard(
        [FromServices] IGetByIdProductUseCase useCase,[FromRoute] long id)
    {
        var response = await useCase.Execute(id);
        return Ok(response);
    }
}