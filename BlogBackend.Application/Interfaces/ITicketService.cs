using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Tickets;

namespace BlogBackend.Application.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponse?> CreateTicketAsync(CreateTicketRequest request);
        Task<bool> UpdateTicketStatusAsync(UpdateTicketRequest request);
        Task<IEnumerable<TicketResponse>> GetAllTicketsAsync();
        Task<TicketResponse?> GetTicketByIdAsync(Guid ticketId);
    }
} 