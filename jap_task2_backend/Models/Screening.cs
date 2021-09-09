using System;
using System.Collections.Generic;

namespace jap_task2_backend.Models
{
    public class Screening
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VideoId { get; set; }
        public int AvailableTickets { get; set; }
        public int SoldTickets { get; set; }
        public DateTime ScreeningDate { get; set; }
        public float Duration { get; set; } // duration in minutes
        public List<BoughtTicket> BoughtTickets { get; set; } = new List<BoughtTicket>();
    }
}
