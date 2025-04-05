using System;
using System.Threading.Tasks;
using BlogBackend.Domain.Entities;

namespace BlogBackend.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> UserExistsAsync(string email);
    }
} 