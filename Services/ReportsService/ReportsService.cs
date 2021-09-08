using jap_task2_backend.Data;
using jap_task2_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
    }
}
