using jap_task2_backend.Data;
using jap_task2_backend.DTO.Ticket;
using jap_task2_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.TicketsService
{
    public class TicketsService : ITicketsService
    {
        private readonly DataContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public TicketsService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<bool>> BuyTickets(BuyTicketDTO buyTicketDTO)
        {
            var serviceResponse = new ServiceResponse<bool>();

            if (buyTicketDTO.NumberOfTickets <= 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = false;
                serviceResponse.Message = "Number of tickets cannot be zero or negative!";
                return serviceResponse;
            }
            
            var userId = GetUserId();
            var screening = await _context.Screenings.FirstOrDefaultAsync(x => x.Id == buyTicketDTO.ScreeningId);

            if(screening == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = false;
                serviceResponse.Message = "Screening does not exist!";
            } 
            else if(screening.SoldTickets + buyTicketDTO.NumberOfTickets > screening.AvailableTickets)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = false;
                serviceResponse.Message = "Cannot buy that many tickets. There are not that many tickets available!";
            } else
            {
                screening.SoldTickets += buyTicketDTO.NumberOfTickets;
                await _context.SaveChangesAsync();

                await _context.BoughtTickets
                    .AddAsync(new BoughtTicket
                    {
                        ScreeningId = buyTicketDTO.ScreeningId,
                        UserId = userId,
                        BoughtTickets = buyTicketDTO.NumberOfTickets
                    });
                await _context.SaveChangesAsync();

                serviceResponse.Success = true;
                serviceResponse.Data = true;
                serviceResponse.Message = "Successfully bought tickets!";
            }

            return serviceResponse;
        }
    }
}
