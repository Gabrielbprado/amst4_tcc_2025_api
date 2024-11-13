using AMS_News.Application.Login;
using AMS_News.Communication.Response.User;
using AMSeCommerce.Communication.Request;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class LoginController : AmsEcommerceBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Login([FromBody] RequestLoginUserJson request,[FromServices] IDoLoginUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Ok(response);
    }
}