namespace jap_task2_backend.Models
{
    public class MoviesWithMostSoldTicketsReport
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ScreeningName { get; set; }
        public int SoldTickets { get; set; }
    }
}
