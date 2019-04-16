using System;

namespace Masterchef.Core.Authentication.Jwt
{
    public class JwtUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
