using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Domain.Entities;

namespace BlogBackend.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
    }
} 