using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OndeTaMotoBusiness
{
    public class TokenService : ITokenService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _minutes;

        public TokenService(string key, string issuer, string audience, int minutes)
        {
            if (string.IsNullOrWhiteSpace(key) || Encoding.UTF8.GetBytes(key).Length < 32)
                throw new ArgumentException("Jwt key must be at least 32 bytes long.", nameof(key));

            _key = key;
            _issuer = issuer;
            _audience = audience;
            _minutes = minutes;
        }

        public TokenResult GenerateToken(string userId, string username, string role)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            var jti = Guid.NewGuid().ToString();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            };

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _issuer,
                Audience = _audience,
                Expires = DateTime.UtcNow.AddMinutes(_minutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            };

            var token = handler.CreateToken(descriptor);
            var tokenString = handler.WriteToken(token);

            return new TokenResult
            {
                AccessToken = tokenString,
                ExpiresAt = descriptor.Expires!.Value,
                Jti = jti
            };
        }
    }
}