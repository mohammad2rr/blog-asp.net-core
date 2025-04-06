using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Enums;

namespace BlogBackend.Domain.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(TicketStatus status);
        Task<IEnumerable<Ticket>> GetTicketsByAssigneeAsync(Guid assigneeId);
        Task<IEnumerable<Ticket>> GetTicketsByCreatorAsync(Guid creatorId);
        Task<IEnumerable<Ticket>> GetOverdueTicketsAsync();
    }
} 