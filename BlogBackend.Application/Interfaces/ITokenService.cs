using BlogBackend.Domain.Entities;

namespace BlogBackend.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        bool ValidateToken(string token);
        string GetUserIdFromToken(string token);
    }
} 