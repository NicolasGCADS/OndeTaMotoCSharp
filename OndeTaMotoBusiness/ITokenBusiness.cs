using OndeTaMotoModel;

namespace OndeTaMotoBusiness
{
    public class TokenResult
    {
        public string AccessToken { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
        public string Jti { get; set; } = null!;
    }

    public interface ITokenService
    {
        TokenResult GenerateToken(string userId, string username, string role);
    }
}
