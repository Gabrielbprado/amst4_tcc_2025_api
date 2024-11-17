using AMSeCommerce.Application.UseCases.Address;
using AMSeCommerce.Communication.Request.Address;
using AMSeCommerce.Communication.Response.Address;
using AMSeCommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class AddressController : AmsEcommerceBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseAddressJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAddress([FromServices] IAddAddressUseCase useCase, [FromBody] RequestAddressJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty,response);
    }
}