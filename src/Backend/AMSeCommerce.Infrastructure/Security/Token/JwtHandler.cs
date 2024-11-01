using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AMSeCommerce.Infrastructure.Security.Token;

public abstract class JwtHandler
{
    protected static SymmetricSecurityKey ConvertToSecurityKey(string signKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
    }
}
