using System;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using BlogBackend.Application.DTOs.Auth;
using BlogBackend.Application.Interfaces;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BlogBackend.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return null;
            }

            var token = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.UserExistsAsync(request.Email))
                return false;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hashedPassword
            };

            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            if (!_tokenService.ValidateToken(refreshToken))
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Invalid refresh token"
                };
            }

            var userId = _tokenService.GetUserIdFromToken(refreshToken);
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userId));
            if (user == null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToArray();
            var accessToken = _tokenService.GenerateAccessToken(userId, roles);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                Success = true,
                Token = accessToken,
                RefreshToken = newRefreshToken,
                Message = "Token refreshed successfully"
            };
        }

        public async Task<bool> RevokeTokenAsync(string refreshToken)
        {
            if (!_tokenService.ValidateToken(refreshToken))
            {
                return false;
            }

            // Implement token revocation logic here
            // This could involve adding the token to a blacklist or invalidating it in some way
            return true;
        }
    }
} 