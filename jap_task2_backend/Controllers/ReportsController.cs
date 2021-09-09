using jap_task2_backend.DTO.Reports;
using jap_task2_backend.Models;
using jap_task2_backend.Services.ReportsService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jap_task2_backend.Controllers
{
    [Route("reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("most_rated_movies")]
        public async Task<ActionResult<ServiceResponse<List<MostRatedMoviesReport>>>> GetMostRatedMoviesReport()
        {
            return Ok(await _reportsService.MostRatedMoviesReport());
        }

        [HttpPost("movies_with_most_screenings")]
        public async Task<ActionResult<ServiceResponse<List<MostRatedMoviesReport>>>> MoviesWithMostScreeningsReport([FromBody] DateIntervalDTO dateIntervalDTO)
        {
            return Ok(await _reportsService.MoviesWithMostScreeningsReport(dateIntervalDTO));
        }

        [HttpGet("movies_with_most_sold_tickets")]
        public async Task<ActionResult<ServiceResponse<List<MoviesWithMostSoldTicketsReport>>>> MoviesWithMostSoldTicketsReport()
        {
            return Ok(await _reportsService.MoviesWithMostSoldTicketsReport());
        }

    }
}
