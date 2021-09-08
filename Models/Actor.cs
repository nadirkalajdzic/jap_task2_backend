using System.Collections.Generic;

namespace jap_task2_backend.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Video> Videos { get; set; } = new List<Video>();
    }
}
