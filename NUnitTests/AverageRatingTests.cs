using AutoMapper;
using jap_task2_backend;
using jap_task2_backend.Data;
using jap_task2_backend.Models;
using jap_task2_backend.Services.AuthService;
using jap_task2_backend.Services.VideosService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnitTests
{
    public class AverageRatingTests
    {
        DataContext _context;
        IVideosService _videosService;
        IMapper _mapper;

        [SetUp]
        public async Task OneTimeSetupAsync()
        {
            // database setup
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "temp_moviesapp2")
                .Options;

            _context = new DataContext(options);

            // - add data

            _context.Videos.Add(new Video
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                Type = 0,
                ReleaseDate = new DateTime(1994, 9, 22),
                Actors= new List<Actor>
                {
                    new Actor { Id = 1, Name = "Morgan", Surname = "Freeman" },
                    new Actor { Id = 2, Name = "Bob", Surname = "Gunton" },
                },
                Categories = new List<Category>
                {
                    new Category { Id = 1, Name = "ACTION"},
                    new Category { Id = 2, Name = "COMEDY" }
                },
                Ratings = new List<Rating>
                {
                    new Rating { Id = 1, Value = 4.6F, VideoId = 1, UserId = 1 },
                    new Rating { Id = 2, Value = 3.6F, VideoId = 1, UserId = 1 },
                    new Rating { Id = 3, Value = 4.1F, VideoId = 1, UserId = 1 }
                }
            });
            _context.Videos.Add(new Video
            {
                Id = 2,
                Title = "The Godfather",
                Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                Type = 0,
                ReleaseDate = new DateTime(1972, 3, 24),
                Actors = new List<Actor>
                {
                    new Actor { Id = 3, Name = "Morgan", Surname = "Freeman" },
                    new Actor { Id = 4, Name = "Bob", Surname = "Gunton" }
                },
                Categories = new List<Category>
                {
                    new Category { Id = 3, Name = "ACTION"},
                    new Category { Id = 4, Name = "COMEDY" }
                },
                Ratings = new List<Rating>
                {
                    new Rating { Id = 4, Value = 4.4F, VideoId = 2, UserId = 1 }
                }
            });
            _context.Videos.Add(new Video
            {
                Id = 3,
                Title = "The Godfather: Part II",
                Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                Type = 0,
                ReleaseDate = new DateTime(1974, 12, 20),
                Actors = new List<Actor>
                {
                    new Actor { Id = 5, Name = "Morgan", Surname = "Freeman" },
                    new Actor { Id = 6, Name = "Bob", Surname = "Gunton" }
                },
                Categories = new List<Category>
                {
                    new Category { Id = 5, Name = "ACTION"},
                    new Category { Id = 6, Name = "COMEDY" }
                },
                Ratings = new List<Rating>()
            });

            await _context.SaveChangesAsync();

            // --------------

            IConfiguration configuration = new ConfigurationBuilder().Build();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            _mapper = mappingConfig.CreateMapper();

            _videosService = new VideosService(_mapper, _context);
            
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        [Test]
        public async Task RatingTest_NormalCase_ReturnsValid()
        {
            var videosList = (await _videosService.GetTopVideos(0)).Data;

            var film1 = videosList.Find(x => x.Id == 1);
            Assert.AreEqual(4.10, film1.AverageRating, .1);
        }

        [Test]
        public async Task RatingTest_NoRatings_Returns0()
        {
            var videosList = (await _videosService.GetTopVideos(0)).Data;

            var film1 = videosList.Find(x => x.Id == 3);
            Assert.AreEqual(0, film1.AverageRating);
        }

        [Test]
        public async Task RatingTest_RangeCheck_ReturnsNumberPositiveOrZero()
        {
            var videosList = (await _videosService.GetTopVideos(0)).Data;

            // every average rating needs to be between 0 and 5 (0 and 5 are included)
            videosList.ForEach(x =>
            {
                Assert.IsTrue(x.AverageRating >= 0 && x.AverageRating <= 5);
            });

        }
    }
}
