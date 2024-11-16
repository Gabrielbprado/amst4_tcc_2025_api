using AMSeCommerce.Application.UseCases.Order;
using AMSeCommerce.Application.UseCases.Order.DoCardOrder;
using AMSeCommerce.Application.UseCases.Order.DoPixOrder;
using AMSeCommerce.Application.UseCases.Order.GetPayment;
using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Response.Order;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class OrderController : AmsEcommerceBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DoPixOrder([FromServices] IDoPixOrderUseCase useCase, [FromBody] RequestOrderJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
    
    [HttpPost("card")]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DoCardOrder([FromServices] IDoCardOrderUseCase useCase, [FromBody] RequestOrderJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
    
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ResponsePixJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPayment([FromServices] IGetPaymentUseCase useCase, [FromRoute] long Id)
    {
        var response = await useCase.Execute(Id);
        return Ok(response);
    }
}