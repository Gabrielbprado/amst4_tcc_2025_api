using AMS_News.Communication.Response;
using AMS_News.Domain.Contracts.Token;
using AMSeCommerce.Domain.Contracts.User;
using AMSeCommerce.Exceptions;
using AMSeCommerce.Exceptions.BaseExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace AMSeCommerce.API.Filters;

public class AuthenticatedUserAttributeFilter(ITokenValidator validator,IUserReadOnlyRepository repository) : IAsyncAuthorizationFilter
{
    private readonly ITokenValidator _validator = validator;
    private readonly IUserReadOnlyRepository _repository = repository;
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = GetTokenFromHeader(context);
            var userIdentifier = _validator.ValidateTokenAndReturnUserIdentifier(token);
            var exist = await _repository.ExistUserActiveWithId(userIdentifier);
            if (exist is false)
            {
                throw new NewsException(ErrorMessage.USER_WITHOUT_PERMISSION);
            }
        }
        catch (NewsException ex)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorMessageJson(ex.Message));
        }
        catch(SecurityTokenExpiredException)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorMessageJson("Token expired")
            {
                TokenIsExpired = true
            });
        }
        catch
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorMessageJson(ErrorMessage.USER_WITHOUT_PERMISSION));
        }
        
    }
    
    private static string GetTokenFromHeader(AuthorizationFilterContext context)
    {
        var authentication = context.HttpContext.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authentication))
        {
            throw new NewsException(ErrorMessage.NO_TOKEN);
        }
        var token = authentication["Bearer ".Length..].Trim();
        return token;
    }
}