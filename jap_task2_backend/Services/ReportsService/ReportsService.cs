using jap_task2_backend.Data;
using jap_task2_backend.DTO.Reports;
using jap_task2_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.ReportsService
{
    public class ReportsService : IReportsService
    {
        private readonly DataContext _context;

        public ReportsService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MostRatedMoviesReport>>> MostRatedMoviesReport()
        {
            var serviceResponse = new ServiceResponse<List<MostRatedMoviesReport>>
            {
                Data = await _context.MostRatedMoviesReports.FromSqlRaw("EXEC [dbo].[getTop10MoviesWithMostRatings];")
                                                            .ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MoviesWithMostScreeningsReport>>> MoviesWithMostScreeningsReport(DateIntervalDTO dateIntervalDTO)
        {
            var serviceResponse = new ServiceResponse<List<MoviesWithMostScreeningsReport>>
            {
                Data = await _context.MoviesWithMostScreeningsReports
                     .FromSqlRaw("EXEC [dbo].[getTop10MoviesWithMostScreenings] {0}, {1};", dateIntervalDTO.StartDate, dateIntervalDTO.EndDate)
                     .ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MoviesWithMostSoldTicketsReport>>> MoviesWithMostSoldTicketsReport()
        {
            var serviceResponse = new ServiceResponse<List<MoviesWithMostSoldTicketsReport>>
            {
                Data = await _context.MoviesWithMostSoldTicketsReports.FromSqlRaw("EXEC [dbo].[getMoviesWithMostSoldTicketsNoRating]")
                                                                      .ToListAsync()
            };

            return serviceResponse;
        }
    }
}
