using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.Order.DoBoletoOrder;
using AMSeCommerce.Application.UseCases.Order.DoCardOrder;
using AMSeCommerce.Application.UseCases.Order.DoPixOrder;
using AMSeCommerce.Application.UseCases.Order.GetOrders;
using AMSeCommerce.Application.UseCases.Order.GetPayment;
using AMSeCommerce.Application.UseCases.Order.GetPaymentMethod;
using AMSeCommerce.Application.UseCases.Order.UpdateStatus;
using AMSeCommerce.Communication.Request.BankAPI;
using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Response.Order;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class OrderController : AmsEcommerceBaseController
{
    [HttpPost("pix-payment")]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> DoPixOrder([FromServices] IDoPixOrderUseCase useCase, [FromBody] RequestOrderJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
    
    [HttpPost("card-payment")]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DoCardOrder([FromServices] IDoCardOrderUseCase useCase, [FromBody] RequestOrderJson request)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
    
    [HttpPost("billet-payment")]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DoBoletoOrder([FromServices] IDoBoletoOrderUseCase useCase, [FromBody] RequestOrderJson request)
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
    
    [HttpGet("my-orders")]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> GetOrders([FromServices] IGetOrdersUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }
    
    [HttpGet("my-payments-method")]
    [ProducesResponseType(typeof(ResponseCardInfoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> GetPaymentMethod([FromServices] IGetPaymentMethodUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(ResponseCardInfoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [AuthenticatedUser]
    public async Task<IActionResult> UpdateStatusOrder([FromServices] IUpdateOrderUseCase useCase,[FromBody] RequestChangeStatus status)
    {
        await useCase.Execute(status);
        return NoContent();
    }
}