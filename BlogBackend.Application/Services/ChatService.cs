using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Chat;
using BlogBackend.Application.Interfaces;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;

namespace BlogBackend.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepository<ChatMessage> _chatRepository;

        public ChatService(IRepository<ChatMessage> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<ChatMessageResponse>> GetChatHistoryAsync()
        {
            var messages = await _chatRepository.GetAllAsync();
            return messages.Select(m => new ChatMessageResponse
            {
                SenderId = m.SenderId,
                Message = m.Message,
                SentAt = m.SentAt
            }).ToList();
        }

        public async Task SaveMessageAsync(ChatMessageRequest request)
        {
            var message = new ChatMessage
            {
                SenderId = request.SenderId,
                Message = request.Message,
                SentAt = DateTime.UtcNow
            };

            await _chatRepository.AddAsync(message);
        }
    }
} 