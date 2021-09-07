using jap_task2_backend.DTO.Video;
using jap_task2_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.VideosService
{
    public interface IVideosService
    {
        Task<ServiceResponse<List<GetVideoDTO>>> GetTopVideos(int type);
        Task<ServiceResponse<List<GetVideoDTO>>> GetTop10Videos(int type);
        Task<ServiceResponse<GetVideoFullInfoDTO>> GetVideo(int Id);
        Task<ServiceResponse<List<GetVideoTextAttributesDTO>>> GetFilteredVideos(string Search);
    }
}
