using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;
using BlogBackend.Persistence.Data;

namespace BlogBackend.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context) { }

        public async Task<IEnumerable<Post>> GetByAuthorIdAsync(Guid authorId) => 
            await _context.Posts.Where(p => p.AuthorId == authorId).ToListAsync();

        public async Task<IEnumerable<Post>> GetRecentPostsAsync(int count) => 
            await _context.Posts.OrderByDescending(p => p.CreatedAt).Take(count).ToListAsync();
    }
} 