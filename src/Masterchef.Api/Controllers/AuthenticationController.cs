using Masterchef.Application.Usuario.ViewModel;
using Masterchef.Core.Authentication.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Masterchef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthentication _jwtAuthentication;

        public AuthenticationController(
            IJwtAuthentication jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LogIn([FromBody]UserLoginRequest vmodel)
        {
            UserLogInResponse response = new UserLogInResponse();

            if (!string.IsNullOrEmpty(vmodel.Username) && !string.IsNullOrEmpty(vmodel.Password) &&
                vmodel.Username.Equals("admin") && vmodel.Password.Equals("admin"))
            {
                var id = Guid.NewGuid();
                var username = "admin";

                response.Token = _jwtAuthentication.Authenticate(new JwtAuthenticationSettings
                {
                    Key = "r2development@123",
                    LoginExpireInHours = 8,
                    User = new JwtUser
                    {
                        Id = id,
                        Username = "admin"
                    }
                });
                response.Id = id;
                response.Username = username;
            }


            return Ok(response);
        }
    }
}
