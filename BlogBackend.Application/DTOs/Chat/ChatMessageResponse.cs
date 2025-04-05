using System;

namespace BlogBackend.Application.DTOs.Chat
{
    public class ChatMessageResponse
    {
        public Guid SenderId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
} 