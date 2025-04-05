using System;

namespace BlogBackend.Application.DTOs.Tickets
{
    public class UpdateTicketRequest
    {
        public Guid TicketId { get; set; }
        public string Status { get; set; } = "Pending"; // Open, InProgress, Resolved, Closed
    }
} 