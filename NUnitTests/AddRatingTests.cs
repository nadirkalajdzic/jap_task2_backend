using jap_task2_backend.Data;
using jap_task2_backend.Models;
using jap_task2_backend.Services.AuthService;
using jap_task2_backend.Services.RatingsService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUnitTests
{
    [TestFixture]
    public class AddRatingTests
    {
        DataContext _context;
        IRatingsService _ratingsService;
        IAuthService _authService;

        [SetUp]
        public async Task SetupAsync()
        {
            // database setup
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "temp_moviesapp4")
                .Options;

            _context = new DataContext(options);

            // - add data

            AuthService.CreatePasswordHash("admin", out byte[] passHashAdmin, out byte[] passSaltAdmin);
            _context.Users.Add(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@gmail.com",
                    Salt = passSaltAdmin,
                    Hash = passHashAdmin
                }
            );

            AuthService.CreatePasswordHash("user", out byte[] passHashUser, out byte[] passSaltUser);
            _context.Users.Add(
                new User
                {
                    Id = 2,
                    Name = "User",
                    Surname = "User",
                    Email = "user@gmail.com",
                    Salt = passSaltUser,
                    Hash = passHashUser
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


            // IConfiguration setup
            var inMemoryConfigurationSettings = new Dictionary<string, string>
            {
               {"AppSettings:Token", "6673d1b96a3661ae9a2f9a04243291d8f181e016a877358658d16627d5677e33aa85d672a75b0286508ac8c94cbc27e49eddf38abcf88d3027c98a981c25fc62"}
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryConfigurationSettings)
                .Build();
            // --------------------


            //auth service setup
            _authService = new AuthService(_context, configuration);

            // login to get token and setup the httpContext, so it can be passed for the ticketsService
            var userLogin = await _authService.Login("user@gmail.com", "user");

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(x => x.HttpContext.Request.Headers.Add("Authorization", @"Bearer $userLogin.Data.Token"));

            // - add claims
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, "2"),
                new Claim(ClaimTypes.Name, "user@gmail.com")
            };
            var identity = new ClaimsIdentity(claims, "User");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var context = new DefaultHttpContext
            {
                User = claimsPrincipal
            };

            context.Request.Headers["Authorization"] = "Bearer " + userLogin.Data.Token;
            mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);

            _ratingsService = new RatingsService(_context, mockHttpContextAccessor.Object);
            // ----------------------------------------------------------------------------------------

        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        [Test]
        public async Task AddRatingTest_InputValidRatingAdd_ReturnTrue()
        {
            var response = await _ratingsService.AddRating(4.1F, 2);

            //Is the rating added?
            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Message, "Successfully added rating");

            var ratingAfter = (await _context.Ratings.Where(x => x.VideoId == 1).ToListAsync()).Average(x => x.Value);
            
            Assert.AreEqual(4.3F, ratingAfter, .1);
        }

        [Test]
        public async Task AddRatingTest_InputInValidRatingAdd_ReturnFalse()
        {
            var response1 = await _ratingsService.AddRating(4.1F, 2);
            var response2 = await _ratingsService.AddRating(4.1F, 2);

            //Is the rating added?

            //first one needs to be added
            Assert.IsTrue(response1.Success);
            Assert.AreEqual(response1.Message, "Successfully added rating");

            //second time it shouldn't. one user cannot rate the same film/show twice!
            Assert.IsFalse(response2.Success);
            Assert.AreEqual(response2.Message, "You already rated this item");

            var ratingAfter = (await _context.Ratings.Where(x => x.VideoId == 1).ToListAsync()).Average(x => x.Value);

            Assert.AreEqual(4.3F, ratingAfter, .1);
        }
    }
}
