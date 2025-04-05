using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BlogBackend.Application.DTOs.Chat;
using BlogBackend.Application.Interfaces;

namespace BlogBackend.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(ChatMessageRequest request)
        {
            await _chatService.SaveMessageAsync(request);

            var response = new ChatMessageResponse
            {
                SenderId = request.SenderId,
                Message = request.Message,
                SentAt = DateTime.UtcNow
            };

            await Clients.All.SendAsync("ReceiveMessage", response);
        }

        public async Task GetChatHistory()
        {
            var chatHistory = await _chatService.GetChatHistoryAsync();
            await Clients.Caller.SendAsync("LoadChatHistory", chatHistory);
        }
    }
} 