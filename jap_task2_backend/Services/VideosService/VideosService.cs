using AutoMapper;
using jap_task2_backend.Data;
using jap_task2_backend.DTO.Actor;
using jap_task2_backend.DTO.Category;
using jap_task2_backend.DTO.Video;
using jap_task2_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jap_task2_backend.Services.VideosService
{
    public class VideosService : IVideosService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public VideosService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetVideoDTO>>> GetTopVideos(int type)
        {
            var serviceResponse = new ServiceResponse<List<GetVideoDTO>>
            {
                Data = await _context.Videos.Include(x => x.Ratings)
                                                 .AsSplitQuery()
                                                 .Where(x => x.Type == type)
                                                 .Select(x => new GetVideoDTO
                                                 {
                                                     Id = x.Id,
                                                     Title = x.Title,
                                                     Description = x.Description,
                                                     Image_Url = x.Image_Url,
                                                     ReleaseDate = x.ReleaseDate,
                                                     AverageRating = x.Ratings.Select(x => x.Value).DefaultIfEmpty().Average()
                                                 })
                                                 .OrderByDescending(x => x.AverageRating)
                                                 .ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideoDTO>>> GetTop10Videos(int type)
        {
            var serviceResponse = new ServiceResponse<List<GetVideoDTO>>
            {
                Data = await _context.Videos.Include(x => x.Ratings)
                                                 .AsSplitQuery()
                                                 .Where(x => x.Type == type)
                                                 .Select(x => new GetVideoDTO
                                                 {
                                                     Id = x.Id,
                                                     Title = x.Title,
                                                     Description = x.Description,
                                                     Image_Url = x.Image_Url,
                                                     ReleaseDate = x.ReleaseDate,
                                                     AverageRating = x.Ratings.Select(x => x.Value).DefaultIfEmpty().Average()
                                                 })
                                                 .OrderByDescending(x => x.AverageRating)
                                                 .Take(10)
                                                 .ToListAsync()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideoFullInfoDTO>> GetVideo(int Id)
        {
            ServiceResponse<GetVideoFullInfoDTO> serviceResponse = new ServiceResponse<GetVideoFullInfoDTO>();

            var video = await _context.Videos
                .Include(x => x.Actors)
                .Include(x => x.Categories)
                .Include(x => x.Ratings)
                .Select(x => new GetVideoFullInfoDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Image_Url = x.Image_Url,
                    ReleaseDate = x.ReleaseDate,
                    AverageRating = x.Ratings.Select(x => x.Value).DefaultIfEmpty().Average(),
                    Actors = x.Actors.Select(x => new GetActorForVideoDTO{ Name = x.Name, Surname = x.Surname }).ToList(),
                    Categories = x.Categories.Select(x => new GetCategoryForVideoDTO { Name = x.Name }).ToList()
                })
                .FirstOrDefaultAsync(x => x.Id == Id);

            serviceResponse.Data = _mapper.Map<GetVideoFullInfoDTO>(video);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVideoTextAttributesDTO>>> GetFilteredVideos(string Search)
        {

            ServiceResponse<List<GetVideoTextAttributesDTO>> serviceResponse = new();

            var query = _context.Videos.AsQueryable();
            AddFiltersForVideoSearch(Search, ref query);

            serviceResponse.Data = await query.OrderByDescending(x => x.Ratings.Select(x => x.Value)
                                    .DefaultIfEmpty().Average())
                                    .Select(x => _mapper.Map<GetVideoTextAttributesDTO>(x)).ToListAsync();

            return serviceResponse;
        }

        private static void AddFiltersForVideoSearch(string Search, ref IQueryable<Video> query)
        {

            var searchQuery = Regex.Split(Search, @"\s+").ToList();

            if (searchQuery.Count < 2)
            {
                query = query = query.Where(x => x.Title.ToUpper().Contains(Search.ToUpper())
                                  || x.Description.ToUpper().Contains(Search.ToUpper()));
                return;
            }

            bool containingStringStar(string s) => s.ToUpper().Equals("STAR") || s.ToUpper().Equals("STARS");
            bool containingStringYear(string s) => s.ToUpper().Equals("YEAR") || s.ToUpper().Equals("YEARS");

            if (searchQuery.Count == 2) 
            {
                if (searchQuery[0].ToUpper().Equals("AFTER") && int.TryParse(searchQuery[1], out int ratingForSearchAfter))
                    query = query.Where(x => x.ReleaseDate.Year > ratingForSearchAfter);
                else if (containingStringStar(searchQuery[1]) && float.TryParse(searchQuery[0], out float exactRating))
                    query = query.Where(x => x.Ratings.Select(x => x.Value).Average() == exactRating);
                else
                    query = query.Where(x => x.Title.ToUpper().Contains(Search.ToUpper())
                                  || x.Description.ToUpper().Contains(Search.ToUpper()));
            } 
            else if(searchQuery.Count == 4)
            {
                if (searchQuery[0].ToUpper().Equals("AT") && searchQuery[1].ToUpper().Equals("LEAST")
                 && float.TryParse(searchQuery[2], out float ratingForSearchAtLeast) 
                 && containingStringStar(searchQuery[3]))
                {
                    query = query.Where(x => x.Ratings.Select(x => x.Value).Average() >= ratingForSearchAtLeast);
                } 
                else if (searchQuery[0].ToUpper().Equals("OLDER") && searchQuery[1].ToUpper().Equals("THAN")
                        && int.TryParse(searchQuery[2], out int dateForSearchOlderThan) 
                        && containingStringYear(searchQuery[3]))
                {
                    query = query.Where(x => DateTime.Now.Year - x.ReleaseDate.Year > dateForSearchOlderThan);
                } 
            }
            else query = query.Where(x => x.Title.ToUpper().Contains(Search.ToUpper()) 
                                  || x.Description.ToUpper().Contains(Search.ToUpper()));

        }



    }
}
