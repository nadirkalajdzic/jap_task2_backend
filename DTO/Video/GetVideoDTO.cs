using jap_task2_backend.DTO.Rating;
using System;
using System.Collections.Generic;

namespace jap_task2_backend.DTO.Video
{
    public class GetVideoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image_Url { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<GetRatingOnlyDTO> Ratings { get; set; } = new List<GetRatingOnlyDTO>();
    }
}
