using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Domain.Entities;

namespace BlogBackend.Domain.Interfaces
{
    public interface IChatRepository : IRepository<ChatMessage>
    {
        Task<IEnumerable<ChatMessage>> GetConversationAsync(Guid userId1, Guid userId2);
        Task<IEnumerable<ChatMessage>> GetUnreadMessagesAsync(Guid userId);
        Task<IEnumerable<ChatMessage>> GetRecentMessagesAsync(Guid userId, int count = 20);
    }
} 