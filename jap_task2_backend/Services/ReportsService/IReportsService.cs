using jap_task2_backend.DTO.Reports;
using jap_task2_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.ReportsService
{
    public interface IReportsService
    {
        Task<ServiceResponse<List<MostRatedMoviesReport>>> MostRatedMoviesReport();
        Task<ServiceResponse<List<MoviesWithMostScreeningsReport>>> MoviesWithMostScreeningsReport(DateIntervalDTO dateIntervalDTO);
        Task<ServiceResponse<List<MoviesWithMostSoldTicketsReport>>> MoviesWithMostSoldTicketsReport();
    }
}
