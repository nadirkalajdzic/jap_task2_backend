using jap_task2_backend.DTO.Ticket;
using jap_task2_backend.Models;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.TicketsService
{
    public interface ITicketsService
    {
        Task<ServiceResponse<bool>> BuyTickets(BuyTicketDTO buyTicketDTO);
    }
}
