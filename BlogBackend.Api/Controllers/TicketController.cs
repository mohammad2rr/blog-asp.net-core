using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogBackend.Application.DTOs.Tickets;
using BlogBackend.Application.Interfaces;

namespace BlogBackend.Api.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("create")]
        [Authorize] // Any logged-in user can create a ticket
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
        {
            var ticket = await _ticketService.CreateTicketAsync(request);
            return ticket != null ? Ok(ticket) : BadRequest("Failed to create ticket");
        }

        [HttpPut("update")]
        [Authorize(Policy = "AdminPolicy")] // Only admins can update tickets
        public async Task<IActionResult> UpdateTicketStatus([FromBody] UpdateTicketRequest request)
        {
            var success = await _ticketService.UpdateTicketStatusAsync(request);
            return success ? Ok("Ticket status updated") : NotFound("Ticket not found");
        }

        [HttpGet("all")]
        [Authorize(Policy = "AdminPolicy")] // Admins can view all tickets
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{ticketId}")]
        [Authorize] // Any logged-in user can view their ticket
        public async Task<IActionResult> GetTicketById(Guid ticketId)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(ticketId);
            return ticket != null ? Ok(ticket) : NotFound("Ticket not found");
        }
    }
} 