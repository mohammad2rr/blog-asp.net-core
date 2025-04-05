using System;

namespace BlogBackend.Application.DTOs.Chat
{
    public class ChatMessageRequest
    {
        public Guid SenderId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
} 