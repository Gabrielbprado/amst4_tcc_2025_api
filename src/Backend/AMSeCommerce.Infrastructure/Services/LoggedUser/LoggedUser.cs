using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AMS_News.Domain.Contracts.Token;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Services.LoggedUser;

public class LoggedUser(AmsEcommerceContext context,ITokenProvider provider) : ILoggedUser
{
    private readonly AmsEcommerceContext _context = context;
    private readonly ITokenProvider _provider = provider;
    public async Task<Customers?> User()
    {
        var token = _provider.Value();
        var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
        var userIdentifier = Guid.Parse(jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value);
        return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(u => u.UserIdentifier == userIdentifier)!;
    }
}