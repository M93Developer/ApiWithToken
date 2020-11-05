using Api.Data;
using Api.Model;
using Api.Services.Contracts;
using Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthOptions AuthOptions;
        private readonly ApiContext DataContext;

        public AuthService(IOptions<AuthOptions> options, ApiContext context)
        {
            AuthOptions = options.Value;
            DataContext = context;
        }

        public async Task<bool> ValidateLogin(ApiUser user)
        {
            if (!string.IsNullOrWhiteSpace(user.ApUsuName) && !string.IsNullOrWhiteSpace(user.ApUsuPass))
            {
                var passEncode = Sha1Util.GetSHA1(user.ApUsuPass);
                return await DataContext.ApiUser.AnyAsync(i => i.ApUsuName == user.ApUsuName && i.ApUsuPass == passEncode);
            }
            return false;
        }

        public string GenerateToken(DateTime startDateTime, ApiUser user, DateTime expireDateTime)
        {
            
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.ApUsuName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(
                    JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(startDateTime).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64
                )//,
                //new Claim("roles", "Cliente"),
                //new Claim("roles", "Administrador")
            };
            for (int i = 0; i < AuthOptions.Roles.Length; i++)
            {   
                claims.Add(new Claim("roles", AuthOptions.Roles[i]));
            }
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthOptions.SigningKey)),
                SecurityAlgorithms.HmacSha256Signature
            );

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                notBefore: startDateTime,
                expires: expireDateTime,
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

    }
}
