using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Auth;

namespace BlogBackend.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthResponse?> LoginAsync(LoginRequest request);
        Task<bool> RegisterAsync(RegisterRequest request);
    }
} 