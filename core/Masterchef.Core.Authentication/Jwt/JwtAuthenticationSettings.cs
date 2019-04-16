namespace Masterchef.Core.Authentication.Jwt
{
    public class JwtAuthenticationSettings
    {
        public string Key { get; set; }
        public int LoginExpireInHours { get; set; }
        public JwtUser User { get; set; }
    }
}
