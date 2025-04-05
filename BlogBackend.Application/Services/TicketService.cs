using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackend.Application.DTOs.Tickets;
using BlogBackend.Application.Interfaces;
using BlogBackend.Domain.Entities;
using BlogBackend.Domain.Interfaces;

namespace BlogBackend.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketResponse?> CreateTicketAsync(CreateTicketRequest request)
        {
            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UserId = request.UserId
            };

            await _ticketRepository.AddAsync(ticket);

            return new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt
            };
        }

        public async Task<bool> UpdateTicketStatusAsync(UpdateTicketRequest request)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);
            if (ticket == null) return false;

            ticket.Status = request.Status;
            await _ticketRepository.UpdateAsync(ticket);
            return true;
        }

        public async Task<IEnumerable<TicketResponse>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return tickets.Select(ticket => new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt
            });
        }

        public async Task<TicketResponse?> GetTicketByIdAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null) return null;

            return new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt
            };
        }
    }
} 