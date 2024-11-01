using AMS_News.Domain.Contracts.Token;

namespace AMSeCommerce.API.Token;

public class HttpContextTokenValue(IHttpContextAccessor httpContextAccessor) : ITokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    public string Value()
    {
        var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        return authorization["Bearer ".Length..].Trim();
    }
}