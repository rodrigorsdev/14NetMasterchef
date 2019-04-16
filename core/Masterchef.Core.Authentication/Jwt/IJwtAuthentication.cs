namespace Masterchef.Core.Authentication.Jwt
{
    public interface IJwtAuthentication
    {
        string Authenticate(JwtAuthenticationSettings settings);
    }
}
