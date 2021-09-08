using System;
using System.Collections.Generic;

namespace jap_task2_backend.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image_Url { get; set; }
        public short Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public List<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
