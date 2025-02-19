using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AMS_News.Domain.Contracts.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace AMSeCommerce.Infrastructure.Security.Token.Access.Generate
{
    public class JwtAccessTokenGenerator : JwtHandler, ITokenGenerator
    {
        private readonly uint _expirationTokenInMinutes;
        private readonly string _signKey;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtAccessTokenGenerator(uint expirationTokenInMinutes, string signKey, IHttpContextAccessor httpContextAccessor)
        {
            _expirationTokenInMinutes = expirationTokenInMinutes;
            _signKey = signKey;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Generate(Guid userIdentifier)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, userIdentifier.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_expirationTokenInMinutes),
                SigningCredentials = new SigningCredentials(ConvertToSecurityKey(_signKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(securityToken);

            // Armazena o token em um cookie HttpOnly
            _httpContextAccessor.HttpContext.Response.Cookies.Append("jwt", tokenString, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(_expirationTokenInMinutes)
            });

            return tokenString;
        }
    }
}