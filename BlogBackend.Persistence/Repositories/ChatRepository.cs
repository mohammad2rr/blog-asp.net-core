using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;
using BlogBackend.Persistence.Data;

namespace BlogBackend.Persistence.Repositories
{
    public class ChatRepository : Repository<ChatMessage>, IChatRepository
    {
        public ChatRepository(BlogDbContext context) : base(context) { }

        public async Task<IEnumerable<ChatMessage>> GetMessagesAsync(Guid senderId, Guid receiverId) =>
            await _context.ChatMessages
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();

        public async Task AddMessageAsync(ChatMessage message)
        {
            await _context.ChatMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
} 