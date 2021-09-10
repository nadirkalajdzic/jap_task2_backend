using jap_task2_backend.DTO.Actor;
using jap_task2_backend.DTO.Category;
using jap_task2_backend.DTO.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jap_task2_backend.DTO.Video
{
    public class GetVideoFullInfoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image_Url { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float AverageRating { get; set; }
        public List<GetActorForVideoDTO> Actors { get; set; } = new List<GetActorForVideoDTO>();
        public List<GetCategoryForVideoDTO> Categories { get; set; } = new List<GetCategoryForVideoDTO>();
    }
}
