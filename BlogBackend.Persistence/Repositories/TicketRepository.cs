using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;
using BlogBackend.Domain.Enums;
using BlogBackend.Persistence.Data;

namespace BlogBackend.Persistence.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ticket>> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByStatusAsync(TicketStatus status)
        {
            return await _dbSet.Where(t => t.Status == status).ToListAsync();
        }
    }
} 