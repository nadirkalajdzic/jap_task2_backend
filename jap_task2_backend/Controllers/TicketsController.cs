using jap_task2_backend.DTO.Ticket;
using jap_task2_backend.Services.TicketsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jap_task2_backend.Controllers
{
    [Authorize]
    [Route("tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpPost("buy_tickets")]
        public async Task<IActionResult> BuyTickets([FromBody] BuyTicketDTO buyTicketDTO)
        {
            var response = await _ticketsService.BuyTickets(buyTicketDTO);

            return response.Success ? Ok(response) : BadRequest(response);
      
        }
    }
}
