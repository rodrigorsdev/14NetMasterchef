using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Masterchef.Core.Authentication.Jwt
{
    public class JwtAuthentication : IJwtAuthentication
    {
        public string Authenticate(JwtAuthenticationSettings settings)
        {
            SecurityKey secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Key));
            SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            SecurityToken tokenOptions = new JwtSecurityToken(
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, settings.User.Id.ToString())
                },
                expires: DateTime.Now.AddHours(settings.LoginExpireInHours),
                signingCredentials: signinCredentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}