using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BlogBackend.Application.Interfaces;

namespace BlogBackend.Api.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<IActionResult> GetChatHistory()
        {
            var chatHistory = await _chatService.GetChatHistoryAsync();
            return Ok(chatHistory);
        }
    }
} 