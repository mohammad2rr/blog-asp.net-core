using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;
using BlogBackend.Persistence.Data;

namespace BlogBackend.Persistence.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context) : base(context) { }

        public async Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId) => 
            await _context.Comments.Where(c => c.PostId == postId).OrderBy(c => c.CreatedAt).ToListAsync();
    }
} 