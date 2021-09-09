namespace jap_task2_backend.Models
{
    public class BoughtTicket
    {
        public int Id { get; set; }
        public int ScreeningId { get; set; }
        public int UserId { get; set; }
        public int BoughtTickets { get; set; }
    }
}
