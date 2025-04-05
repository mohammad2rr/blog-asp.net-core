using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Chat;

namespace BlogBackend.Application.Interfaces
{
    public interface IChatService
    {
        Task<List<ChatMessageResponse>> GetChatHistoryAsync();
        Task SaveMessageAsync(ChatMessageRequest request);
    }
} 