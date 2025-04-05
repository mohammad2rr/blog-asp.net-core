using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Domain.Entities;

namespace BlogBackend.Domain.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetByAuthorIdAsync(Guid authorId);
        Task<IEnumerable<Post>> GetRecentPostsAsync(int count);
    }
} 