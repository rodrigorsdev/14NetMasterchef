using System;

namespace Masterchef.Application.Usuario.ViewModel
{
    public class UserLogInResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
