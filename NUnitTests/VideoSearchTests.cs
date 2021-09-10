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
    [TestFixture]
    public class VideoSearchTests
    {
        DataContext _context;
        IVideosService _videosService;
        IMapper _mapper;

        [SetUp]
        public async Task OneTimeSetupAsync()
        {
            // database setup
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "temp_moviesapp3")
                .Options;

            _context = new DataContext(options);

            // - add data

            AuthService.CreatePasswordHash("admin", out byte[] passHash, out byte[] passSalt);
            _context.Users.Add(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@gmail.com",
                    Salt = passSalt,
                    Hash = passHash
                }
            );

            _context.Videos.Add(new Video
            {
                Id = 1,
                Title = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                Type = 0,
                ReleaseDate = new DateTime(1994, 9, 22),
                Ratings = new List<Rating>
                {
                    new Rating { Id = 1, Value = 4.6F, VideoId = 1, UserId = 1 },
                    new Rating { Id = 2, Value = 4F, VideoId = 1, UserId = 1 }
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
                Ratings = new List<Rating>
                {
                    new Rating { Id = 3, Value = 2.6F, VideoId = 2, UserId = 1 }
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
                Ratings = new List<Rating>
                {
                    new Rating { Id = 4, Value = 3.6F, VideoId = 3, UserId = 1 }
                }
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
        public async Task VideoSearchTests_InputNormalFilmTitle_ReturnListOf1()
        {
            var list = (await _videosService.GetFilteredVideos("The s")).Data;

            //should only be one from the three given movies
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(list[0].Title, "The Shawshank Redemption");
        }

        [Test]
        public async Task VideoSearchTests_InputAfter1970_ReturnListOf1()
        {
            var list = (await _videosService.GetFilteredVideos("after 1980")).Data;

            //should only be one from the three given movies
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public async Task VideoSearchTests_InputAfter72EdgeCase_ReturnListOf2()
        {
            var list = (await _videosService.GetFilteredVideos("after 1972")).Data;

            //movie with the release year 1972 should not be included
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public async Task VideoSearchTests_InputDescriptionWord_ReturnListOf1()
        {
            var list = (await _videosService.GetFilteredVideos("Vito Corleone")).Data;

            //should only be one from the three given movies
            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(list[0].Description.Contains("Vito Corleone"));
        }

        [Test]
        public async Task VideoSearchTests_InputExactRating_ReturnListOf1()
        {
            var list = (await _videosService.GetFilteredVideos("4.3 stars")).Data;

            //should only be one from the three given movies
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public async Task VideoSearchTests_InputRatingAtLeast_ReturnListOf1()
        {
            var list = (await _videosService.GetFilteredVideos("at least 4 stars")).Data;

            //should only be one from the three given movies
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public async Task VideoSearchTests_InputRatingAtLeastEdgeCase_ReturnListOf2()
        {
            var list = (await _videosService.GetFilteredVideos("at least 3.6 stars")).Data;

            //should only be one from the three given movies
            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public async Task VideoSearchTests_InputOlderThan_ReturnListOf2()
        {
            var list = (await _videosService.GetFilteredVideos("older than " + (DateTime.Now.Year - 1993) + " years")).Data;

            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public async Task VideoSearchTests_InputOlderThanEdgeCase_ReturnListOf1()
        {
            var list = (await _videosService.GetFilteredVideos("older than " + (DateTime.Now.Year - 1994) + " years")).Data;

            //films with the year 1994 should not be included in the result
            Assert.AreEqual(2, list.Count);
        }
    }
}
