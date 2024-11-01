using AMS_News.Communication.Request.User;
using AMS_News.Communication.Response;
using AMS_News.Communication.Response.User;
using AMSeCommerce.API.Attribute;
using AMSeCommerce.Application.UseCases.User.ChangePassword;
using AMSeCommerce.Application.UseCases.User.Profile;
using AMSeCommerce.Application.UseCases.User.Register;
using AMSeCommerce.Application.UseCases.User.Update;
using Microsoft.AspNetCore.Mvc;

namespace AMSeCommerce.API.Controller;

public class CustomerController : AmsEcommerceBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson),StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase registerUserUseCase, [FromBody] RequestRegisterUserJson requestRegisterUserJson)
    {
        var response = await registerUserUseCase.Execute(requestRegisterUserJson);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
    [AuthenticatedUser]
    public async Task<IActionResult> GetUserProfile([FromServices] IGetProfileUserUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
    [AuthenticatedUser]
    public async Task<IActionResult> Update([FromServices] IUpdateUserUseCase useCase,[FromBody] RequestUpdateUserJson request)
    {
         await useCase.Execute(request);
        return NoContent();
    }
    
    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
    [AuthenticatedUser]
    public async Task<IActionResult> ChangePassword([FromServices] IChangePasswordUseCase useCase,[FromBody] RequestChangePasswordJson request)
    {
         await useCase.Execute(request);
        return NoContent();
    }

}