using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jap_task2_backend.DTO.Rating
{
    public class AddRatingDTO
    {
        public float Value { get; set; }
        public int VideoId { get; set; }
    }
}
