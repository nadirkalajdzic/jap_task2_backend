using jap_task2_backend.Models;
using jap_task2_backend.Services.AuthService;
using Microsoft.EntityFrameworkCore;
using System;

namespace jap_task2_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<BoughtTicket> BoughtTickets { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<MostRatedMoviesReport> MostRatedMoviesReports { get; set; }
        public DbSet<MoviesWithMostScreeningsReport> MoviesWithMostScreeningsReports { get; set; }
        public DbSet<MoviesWithMostSoldTicketsReport> MoviesWithMostSoldTicketsReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Category static data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "ACTION"},
                new Category { Id = 2, Name = "COMEDY" },
                new Category { Id = 3, Name = "THRILLER" },
                new Category { Id = 4, Name = "DRAMA" },
                new Category { Id = 5, Name = "TRAGEDY" },
                new Category { Id = 6, Name = "CRIME" },
                new Category { Id = 7, Name = "BIOGRAPHY" },
                new Category { Id = 8, Name = "ADVENTURE" },
                new Category { Id = 9, Name = "WESTERN" },
                new Category { Id = 10, Name = "BIOGRAPHY" },
                new Category { Id = 11, Name = "ROMANCE" },
                new Category { Id = 12, Name = "SCI-FI" },
                new Category { Id = 13, Name = "DOCUMENTARY" },
                new Category { Id = 14, Name = "HISTORY" },
                new Category { Id = 15, Name = "ANIMATION" }
            );
            #endregion

            #region Actor static data
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Morgan", Surname= "Freeman" },
                new Actor { Id = 2, Name = "Bob", Surname = "Gunton" },
                new Actor { Id = 3, Name = "Tim", Surname = "Robbins" },
                new Actor { Id = 4, Name = "Marlon", Surname = "Brando" },
                new Actor { Id = 5, Name = "Al", Surname = "Pacino" },
                new Actor { Id = 6, Name = "James", Surname = "Caan" },
                new Actor { Id = 7, Name = "Robert", Surname = "De Niro" },
                new Actor { Id = 8, Name = "Robert", Surname = "Duvall" },
                new Actor { Id = 9, Name = "Christian", Surname = "Bale" },
                new Actor { Id = 10, Name = "Heath", Surname = "Ledger" },
                new Actor { Id = 11, Name = "Aaron", Surname = "Eckhart" },
                new Actor { Id = 12, Name = "Henry", Surname = "Fonda" },
                new Actor { Id = 13, Name = "Lee", Surname = "J. Cobb" },
                new Actor { Id = 14, Name = "Martin", Surname = "Balsam" },
                new Actor { Id = 15, Name = "Liam", Surname = "Neeson" },
                new Actor { Id = 16, Name = "Ralph", Surname = "Fiennes" },
                new Actor { Id = 17, Name = "Ben", Surname = "Kingsley" },
                new Actor { Id = 18, Name = "Elijah", Surname = "Wood" },
                new Actor { Id = 19, Name = "Viggo", Surname = "Mortensen" },
                new Actor { Id = 20, Name = "Ian", Surname = "McKellen" },
                new Actor { Id = 21, Name = "John", Surname = "Travolta" },
                new Actor { Id = 22, Name = "Uma", Surname = "Thurman" },
                new Actor { Id = 23, Name = "Samuel", Surname = "L. Jackson" },
                new Actor { Id = 24, Name = "Clint", Surname = "Eastwood" },
                new Actor { Id = 25, Name = "Eli", Surname = "Wallach" },
                new Actor { Id = 26, Name = "Lee", Surname = "Van Cleef" },
                new Actor { Id = 27, Name = "Orlando", Surname = "Bloom" },
                new Actor { Id = 28, Name = "Brad", Surname = "Pitt" },
                new Actor { Id = 29, Name = "Edward", Surname = "Norton" },
                new Actor { Id = 30, Name = "Meat", Surname = "Loaf" },
                new Actor { Id = 31, Name = "Tom", Surname = "Hanks" },
                new Actor { Id = 32, Name = "Robin", Surname = "Wright" },
                new Actor { Id = 33, Name = "Gary", Surname = "Sinise" },
                new Actor { Id = 34, Name = "Leonardo", Surname = "DiCaprio" },
                new Actor { Id = 35, Name = "Joseph", Surname = "Gordon-Levitt" },
                new Actor { Id = 36, Name = "Elliot", Surname = "Page" },
                new Actor { Id = 37, Name = "David", Surname = "Attenborough" },
                new Actor { Id = 38, Name = "Sigourney", Surname = "Weaver" },
                new Actor { Id = 39, Name = "Nikolay", Surname = "Drozdov" },
                new Actor { Id = 40, Name = "Bryan", Surname = "Cranston" },
                new Actor { Id = 41, Name = "Aaron", Surname = "Paul" },
                new Actor { Id = 42, Name = "Anna", Surname = "Gunn" },
                new Actor { Id = 43, Name = "Scott", Surname = "Grimes" },
                new Actor { Id = 44, Name = "Damian", Surname = "Lewis" },
                new Actor { Id = 45, Name = "Ron", Surname = "Livingston" },
                new Actor { Id = 46, Name = "Jessie", Surname = "Buckley" },
                new Actor { Id = 47, Name = "Jared", Surname = "Harris" },
                new Actor { Id = 48, Name = "Stellan", Surname = "Skarsgard" },
                new Actor { Id = 49, Name = "Jessie", Surname = "Buckley" },
                new Actor { Id = 50, Name = "Dominic", Surname = "West" },
                new Actor { Id = 51, Name = "Lance", Surname = "Reddick" },
                new Actor { Id = 52, Name = "Sonja", Surname = "Sohn" },
                new Actor { Id = 53, Name = "Peter", Surname = "Drost" },
                new Actor { Id = 54, Name = "Roger", Surname = "Horrocks" },
                new Actor { Id = 55, Name = "Neil", Surname = "deGrasse Tyson" },
                new Actor { Id = 56, Name = "Stoney", Surname = "Emshwiller" },
                new Actor { Id = 57, Name = "Piotr", Surname = "Michael" },
                new Actor { Id = 58, Name = "Neil", Surname = "deGrasse Tyson" },
                new Actor { Id = 59, Name = "Dee", Surname = "Bradley Baker" },
                new Actor { Id = 60, Name = "Zach", Surname = "Tyler" },
                new Actor { Id = 61, Name = "Mae", Surname = "Whitman" },
                new Actor { Id = 62, Name = "Carl", Surname = "Sagan" },
                new Actor { Id = 63, Name = "Jaromir", Surname = "Hanzlik" },
                new Actor { Id = 64, Name = "Jonathan", Surname = "Fahn" },
                new Actor { Id = 65, Name = "Emilia", Surname = "Clarke" },
                new Actor { Id = 66, Name = "Peter", Surname = "Dinklage" },
                new Actor { Id = 67, Name = "Kit", Surname = "Harington" },
                new Actor { Id = 68, Name = "James", Surname = "Gandolfini" },
                new Actor { Id = 69, Name = "Lorraine", Surname = "Bracco" },
                new Actor { Id = 70, Name = "Eddie", Surname = "Falco" }
            );
            #endregion

            #region Movies and Series static data
            modelBuilder.Entity<Video>().HasData(
                //movies
                new Video 
                { 
                    Id = 1, Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", 
                    Image_Url= "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", 
                    Type=0, 
                    ReleaseDate=new DateTime(1994, 9, 22) 
                },
                new Video
                {
                    Id = 2,
                    Title = "The Godfather",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 3,
                    Title = "The Godfather: Part II",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 4,
                    Title = "The Dark Knight",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                new Video
                {
                    Id = 5,
                    Title = "12 Angry Men",
                    Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1957, 4, 1)
                },
                new Video
                {
                    Id = 6,
                    Title = "Schindler's List",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 2, 4)
                },
                new Video
                {
                    Id = 7,
                    Title = "The Lord of the Rings: The Return of the King",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image_Url = "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2003, 12, 1)
                },
                new Video
                {
                    Id = 8,
                    Title = "Pulp Fiction",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 9,
                    Title = "The Good, the Bad and the Ugly",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 10,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Image_Url = "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250",
                    Type = 0,
                    ReleaseDate = new DateTime(2001, 12, 19)
                },
                new Video
                {
                    Id = 11,
                    Title = "Fight Club",
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Image_Url = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1999, 11, 11)
                },
                new Video
                {
                    Id = 12,
                    Title = "Forrest Gump",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 13,
                    Title = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },

                // series
                new Video
                {
                    Id = 14,
                    Title = "Planet Earth II",
                    Description = "Wildlife documentary series with David Attenborough, beginning with a look at the remote islands which offer sanctuary to some of the planet's rarest creatures, to the beauty of cities, which are home to humans, and animals..",
                    Image_Url = "https://blackwells.co.uk/jacket/l/9781785943041.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2016, 11, 6)
                },
                new Video
                {
                    Id = 15,
                    Title = "Planet Earth",
                    Description = "Emmy Award-winning, 11 episodes, five years in the making, the most expensive nature documentary series ever commissioned by the BBC, and the first to be filmed in high definition.",
                    Image_Url = "https://m.media-amazon.com/images/I/91X9p6+58KL._SY445_.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2010, 4, 5)
                },
                new Video
                {
                    Id = 16,
                    Title = "Breaking Bad",
                    Description = "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.",
                    Image_Url = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ggFHVNu6YYI5L9pCfOacjizRGt.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2008, 1, 20)
                },
                new Video
                {
                    Id = 17,
                    Title = "Band of Brothers",
                    Description = "The story of Easy Company of the U.S. Army 101st Airborne Division and their mission in World War II Europe, from Operation Overlord to V-J Day.",
                    Image_Url = "https://i.dailymail.co.uk/i/pix/2017/02/13/01/3D24EF6B00000578-4215748-image-a-63_1486948627611.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2001, 9, 9)
                },
                new Video
                {
                    Id = 18,
                    Title = "Chernobyl",
                    Description = "In April 1986, an explosion at the Chernobyl nuclear power plant in the Union of Soviet Socialist Republics becomes one of the world's worst man-made catastrophes.",
                    Image_Url = "https://i.redd.it/bv5isr69yr531.png",
                    Type = 1,
                    ReleaseDate = new DateTime(1986, 4, 26)
                },
                new Video
                {
                    Id = 19,
                    Title = "The Wire",
                    Description = "The Baltimore drug scene, as seen through the eyes of drug dealers and law enforcement.",
                    Image_Url = "https://tvshows.today/wp-content/uploads/the-wire-season-1-poster.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2008, 4, 9)
                },
                new Video
                {
                    Id = 20,
                    Title = "Blue Planet II",
                    Description = "David Attenborough returns to the world's oceans in this sequel to the acclaimed documentary filming rare and unusual creatures of the deep, as well as documenting the problems our oceans face.",
                    Image_Url = "https://cdn.shopify.com/s/files/1/0747/3829/products/mL1006_1024x1024.jpg?v=1571445246",
                    Type = 1,
                    ReleaseDate = new DateTime(2017, 10, 29)
                },
                new Video
                {
                    Id = 21,
                    Title = "Our Planet",
                    Description = "Documentary series focusing on the breadth of the diversity of habitats around the world, from the remote Arctic wilderness and mysterious deep oceans to the vast landscapes of Africa and diverse jungles of South America.",
                    Image_Url = "https://www.penguin.co.uk/content/dam/prh/books/111/1115210/9780593079768.jpg.transform/PRHDesktopWide_small/image.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2019, 4, 5)
                },
                new Video
                {
                    Id = 22,
                    Title = "Cosmos: A Spacetime Odyssey",
                    Description = "An exploration of our discovery of the laws of nature and coordinates in space and time.",
                    Image_Url = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/5945/5945188_sa.jpg;maxHeight=640;maxWidth=550",
                    Type = 1,
                    ReleaseDate = new DateTime(2014, 4, 9)
                },
                new Video
                {
                    Id = 23,
                    Title = "Avatar: The Last Airbender",
                    Description = "In a war-torn world of elemental magic, a young boy reawakens to undertake a dangerous mystic quest to fulfill his destiny as the Avatar, and bring peace to the world.",
                    Image_Url = "https://images-na.ssl-images-amazon.com/images/I/914eUC4XPML.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2005, 2, 21)
                },
                new Video
                {
                    Id = 24,
                    Title = "Cosmos",
                    Description = "Astronomer Carl Sagan leads us on an engaging guided tour of the various elements and cosmological theories of the universe.",
                    Image_Url = "https://www.themoviedb.org/t/p/original/4WJ9kNejI8apl3f8hMNwo8V3hGT.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(1980, 12, 21)
                },
                new Video
                {
                    Id = 25,
                    Title = "Game of Thrones",
                    Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                    Image_Url = "https://m.media-amazon.com/images/M/MV5BYTRiNDQwYzAtMzVlZS00NTI5LWJjYjUtMzkwNTUzMWMxZTllXkEyXkFqcGdeQXVyNDIzMzcwNjc@._V1_FMjpg_UX1000_.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(2011, 4, 17)
                },
                new Video
                {
                    Id = 26,
                    Title = "The Sopranos",
                    Description = "New Jersey mob boss Tony Soprano deals with personal and professional issues in his home and business life that affect his mental state, leading him to seek professional psychiatric counseling.",
                    Image_Url = "https://m.media-amazon.com/images/M/MV5BZGJjYzhjYTYtMDBjYy00OWU1LTg5OTYtNmYwOTZmZjE3ZDdhXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_FMjpg_UX1000_.jpg",
                    Type = 1,
                    ReleaseDate = new DateTime(1999, 1, 10)
                },
                //movies
                new Video
                {
                    Id = 27,
                    Title = "The Shawshank Redemption 2",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 28,
                    Title = "The Godfather 2",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 29,
                    Title = "The Godfather: Part II 2",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 30,
                    Title = "The Dark Knight 2",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                new Video
                {
                    Id = 31,
                    Title = "12 Angry Men 2",
                    Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1957, 4, 1)
                },
                new Video
                {
                    Id = 32,
                    Title = "Schindler's List 2",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 2, 4)
                },
                new Video
                {
                    Id = 33,
                    Title = "The Lord of the Rings: The Return of the King 2",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image_Url = "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2003, 12, 1)
                },
                new Video
                {
                    Id = 34,
                    Title = "Pulp Fiction 2",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 35,
                    Title = "The Good, the Bad and the Ugly 2",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 36,
                    Title = "The Lord of the Rings: The Fellowship of the Ring 2",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Image_Url = "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250",
                    Type = 0,
                    ReleaseDate = new DateTime(2001, 12, 19)
                },
                new Video
                {
                    Id = 37,
                    Title = "Fight Club 2",
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Image_Url = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1999, 11, 11)
                },
                new Video
                {
                    Id = 38,
                    Title = "Forrest Gump 2",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 39,
                    Title = "Inception 2",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                //
                new Video
                {
                    Id = 40,
                    Title = "The Shawshank Redemption 3",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 41,
                    Title = "The Godfather 3",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 42,
                    Title = "The Godfather: Part II 3",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 43,
                    Title = "The Dark Knight 3",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                new Video
                {
                    Id = 44,
                    Title = "12 Angry Men 3",
                    Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1957, 4, 1)
                },
                new Video
                {
                    Id = 45,
                    Title = "Schindler's List 3",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 2, 4)
                },
                new Video
                {
                    Id = 46,
                    Title = "The Lord of the Rings: The Return of the King 3",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image_Url = "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2003, 12, 1)
                },
                new Video
                {
                    Id = 47,
                    Title = "Pulp Fiction 3",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 48,
                    Title = "The Good, the Bad and the Ugly 3",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 49,
                    Title = "The Lord of the Rings: The Fellowship of the Ring 3",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Image_Url = "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250",
                    Type = 0,
                    ReleaseDate = new DateTime(2001, 12, 19)
                },
                new Video
                {
                    Id = 50,
                    Title = "Fight Club 3",
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Image_Url = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1999, 11, 11)
                },
                new Video
                {
                    Id = 51,
                    Title = "Forrest Gump 3",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 52,
                    Title = "Inception 3",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                //
                new Video
                {
                    Id = 53,
                    Title = "The Shawshank Redemption 4",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 54,
                    Title = "The Godfather 4",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 55,
                    Title = "The Godfather: Part II 4",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 56,
                    Title = "The Dark Knight 4",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                new Video
                {
                    Id = 57,
                    Title = "12 Angry Men 4",
                    Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1957, 4, 1)
                },
                new Video
                {
                    Id = 58,
                    Title = "Schindler's List 4",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 2, 4)
                },
                new Video
                {
                    Id = 59,
                    Title = "The Lord of the Rings: The Return of the King 4",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image_Url = "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2003, 12, 1)
                },
                new Video
                {
                    Id = 60,
                    Title = "Pulp Fiction 4",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 61,
                    Title = "The Good, the Bad and the Ugly 4",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 62,
                    Title = "The Lord of the Rings: The Fellowship of the Ring 4",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Image_Url = "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250",
                    Type = 0,
                    ReleaseDate = new DateTime(2001, 12, 19)
                },
                new Video
                {
                    Id = 63,
                    Title = "Fight Club 4",
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Image_Url = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1999, 11, 11)
                },
                new Video
                {
                    Id = 64,
                    Title = "Forrest Gump 4",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 65,
                    Title = "Inception 4",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                //
                new Video
                {
                    Id = 66,
                    Title = "Inception 4444",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                new Video
                {
                    Id = 67,
                    Title = "The Shawshank Redemption 5",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 68,
                    Title = "The Godfather 5",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 69,
                    Title = "The Godfather: Part II 5",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 70,
                    Title = "The Dark Knight 5",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                new Video
                {
                    Id = 71,
                    Title = "12 Angry Men 5",
                    Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1957, 4, 1)
                },
                new Video
                {
                    Id = 72,
                    Title = "Schindler's List 5",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 2, 4)
                },
                new Video
                {
                    Id = 73,
                    Title = "The Lord of the Rings: The Return of the King 5",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image_Url = "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2003, 12, 1)
                },
                new Video
                {
                    Id = 74,
                    Title = "Pulp Fiction 5",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 75,
                    Title = "Pulp Fiction 51",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 76,
                    Title = "Pulp Fiction 52",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 77,
                    Title = "Pulp Fiction 53",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 78,
                    Title = "The Good, the Bad and the Ugly 5",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 79,
                    Title = "The Good, the Bad and the Ugly 51",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 80,
                    Title = "The Lord of the Rings: The Fellowship of the Ring 5",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Image_Url = "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250",
                    Type = 0,
                    ReleaseDate = new DateTime(2001, 12, 19)
                },
                new Video
                {
                    Id = 81,
                    Title = "Fight Club 5",
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Image_Url = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1999, 11, 11)
                },
                new Video
                {
                    Id = 82,
                    Title = "Forrest Gump 5",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 83,
                    Title = "Inception 5",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                //
                new Video
                {
                    Id = 84,
                    Title = "The Shawshank Redemption 6",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 85,
                    Title = "The Godfather 6",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 86,
                    Title = "The Godfather: Part II 6",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 87,
                    Title = "The Dark Knight 6",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                new Video
                {
                    Id = 88,
                    Title = "12 Angry Men 6",
                    Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1957, 4, 1)
                },
                new Video
                {
                    Id = 89,
                    Title = "Schindler's List 6",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 2, 4)
                },
                new Video
                {
                    Id = 90,
                    Title = "The Lord of the Rings: The Return of the King 6",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Image_Url = "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2003, 12, 1)
                },
                new Video
                {
                    Id = 91,
                    Title = "Pulp Fiction 6",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    Image_Url = "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Video
                {
                    Id = 92,
                    Title = "The Good, the Bad and the Ugly 6",
                    Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1996, 12, 23)
                },
                new Video
                {
                    Id = 93,
                    Title = "The Lord of the Rings: The Fellowship of the Ring 6",
                    Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                    Image_Url = "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250",
                    Type = 0,
                    ReleaseDate = new DateTime(2001, 12, 19)
                },
                new Video
                {
                    Id = 94,
                    Title = "Fight Club 6",
                    Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                    Image_Url = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1999, 11, 11)
                },
                new Video
                {
                    Id = 95,
                    Title = "Forrest Gump 6",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 96,
                    Title = "Inception 6",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                //
                new Video
                {
                    Id = 97,
                    Title = "The Shawshank Redemption 7",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 98,
                    Title = "The Godfather 7",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 99,
                    Title = "The Godfather: Part II 7",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 100,
                    Title = "The Dark Knight 7",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                },
                //
                new Video
                {
                    Id = 101,
                    Title = "Forrest Gump 66",
                    Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Image_Url = "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Video
                {
                    Id = 102,
                    Title = "Inception 66",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Image_Url = "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2010, 7, 22)
                },
                //
                new Video
                {
                    Id = 103,
                    Title = "The Shawshank Redemption 76",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Image_Url = "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop",
                    Type = 0,
                    ReleaseDate = new DateTime(1994, 9, 22)
                },
                new Video
                {
                    Id = 104,
                    Title = "The Godfather 76",
                    Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                    Image_Url = "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1972, 3, 24)
                },
                new Video
                {
                    Id = 105,
                    Title = "The Godfather: Part II 76",
                    Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                    Image_Url = "https://shotonwhat.com/images/0071562-med.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(1974, 12, 20)
                },
                new Video
                {
                    Id = 106,
                    Title = "The Dark Knight 76",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Image_Url = "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg",
                    Type = 0,
                    ReleaseDate = new DateTime(2008, 7, 18)
                }
            );
            #endregion

            #region Admin user
            AuthService.CreatePasswordHash("admin", out byte[] passHash, out byte[] passSalt);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Surname="Admin", Email="admin@gmail.com",  Salt = passSalt, Hash= passHash}
                
            );
            #endregion

            #region Ratings
            modelBuilder.Entity<Rating>().HasData(
                //show ratings
                new Rating { Id = 1, Value = 4.6F, VideoId = 1, UserId = 1 },
                new Rating { Id = 2, Value = 4.5F, VideoId = 2, UserId = 1 },
                new Rating { Id = 3, Value = 4.5F, VideoId = 3, UserId = 1 },
                new Rating { Id = 4, Value = 4.5F, VideoId = 4, UserId = 1 },
                new Rating { Id = 5, Value = 4.4F, VideoId = 5, UserId = 1 },
                new Rating { Id = 6, Value = 4.35F, VideoId = 6, UserId = 1 },
                new Rating { Id = 7, Value = 4.3F, VideoId = 7, UserId = 1 },
                new Rating { Id = 8, Value = 4.2F, VideoId = 8, UserId = 1 },
                new Rating { Id = 9, Value = 4.2F, VideoId = 9, UserId = 1 },
                new Rating { Id = 10, Value = 4.2F, VideoId = 10, UserId = 1 },
                new Rating { Id = 11, Value = 4.2F, VideoId = 11, UserId = 1 },
                new Rating { Id = 12, Value = 4.1F, VideoId = 12, UserId = 1 },
                new Rating { Id = 13, Value = 4.1F, VideoId = 13, UserId = 1 },
                //movie ratings
                new Rating { Id = 14, Value = 4.7F, VideoId = 14, UserId = 1 },
                new Rating { Id = 15, Value = 4.6F, VideoId = 15, UserId = 1 },
                new Rating { Id = 16, Value = 4.6F, VideoId = 16, UserId = 1 },
                new Rating { Id = 17, Value = 4.6F, VideoId = 17, UserId = 1 },
                new Rating { Id = 18, Value = 4.5F, VideoId = 18, UserId = 1 },
                new Rating { Id = 19, Value = 4.4F, VideoId = 19, UserId = 1 },
                new Rating { Id = 20, Value = 4.3F, VideoId = 20, UserId = 1 },
                new Rating { Id = 21, Value = 4.2F, VideoId = 21, UserId = 1 },
                new Rating { Id = 22, Value = 4.1F, VideoId = 22, UserId = 1 },
                new Rating { Id = 23, Value = 4.1F, VideoId = 23, UserId = 1 },
                new Rating { Id = 24, Value = 4.1F, VideoId = 24, UserId = 1 },
                new Rating { Id = 25, Value = 4F, VideoId = 25, UserId = 1 },
                new Rating { Id = 26, Value = 3.9F, VideoId = 26, UserId = 1 },
                //
                new Rating { Id = 27, Value = 4.7F, VideoId = 27, UserId = 1 },
                new Rating { Id = 28, Value = 4.6F, VideoId = 28, UserId = 1 },
                new Rating { Id = 29, Value = 4.6F, VideoId = 29, UserId = 1 },
                new Rating { Id = 30, Value = 4.6F, VideoId = 30, UserId = 1 },
                new Rating { Id = 31, Value = 4.5F, VideoId = 31, UserId = 1 },
                new Rating { Id = 32, Value = 4.4F, VideoId = 32, UserId = 1 },
                new Rating { Id = 33, Value = 4.3F, VideoId = 33, UserId = 1 },
                new Rating { Id = 34, Value = 4.2F, VideoId = 34, UserId = 1 },
                new Rating { Id = 35, Value = 4.1F, VideoId = 35, UserId = 1 },
                new Rating { Id = 36, Value = 4.1F, VideoId = 36, UserId = 1 },
                new Rating { Id = 37, Value = 4.1F, VideoId = 37, UserId = 1 },
                new Rating { Id = 38, Value = 4F, VideoId = 38, UserId = 1 },
                new Rating { Id = 39, Value = 3.9F, VideoId = 39, UserId = 1 },
                //
                new Rating { Id = 40, Value = 4.7F, VideoId = 40, UserId = 1 },
                new Rating { Id = 41, Value = 4.6F, VideoId = 41, UserId = 1 },
                new Rating { Id = 42, Value = 4.6F, VideoId = 42, UserId = 1 },
                new Rating { Id = 43, Value = 4.6F, VideoId = 43, UserId = 1 },
                new Rating { Id = 44, Value = 4.5F, VideoId = 44, UserId = 1 },
                new Rating { Id = 45, Value = 4.4F, VideoId = 45, UserId = 1 },
                new Rating { Id = 46, Value = 4.3F, VideoId = 46, UserId = 1 },
                new Rating { Id = 47, Value = 4.2F, VideoId = 47, UserId = 1 },
                new Rating { Id = 48, Value = 4.1F, VideoId = 48, UserId = 1 },
                new Rating { Id = 49, Value = 4.1F, VideoId = 49, UserId = 1 },
                new Rating { Id = 50, Value = 4.1F, VideoId = 50, UserId = 1 },
                new Rating { Id = 51, Value = 4F, VideoId = 51, UserId = 1 },
                new Rating { Id = 52, Value = 3.9F, VideoId = 52, UserId = 1 },
                //
                new Rating { Id = 53, Value = 4.7F, VideoId = 53, UserId = 1 },
                new Rating { Id = 54, Value = 4.6F, VideoId = 54, UserId = 1 },
                new Rating { Id = 55, Value = 4.6F, VideoId = 55, UserId = 1 },
                new Rating { Id = 56, Value = 4.6F, VideoId = 56, UserId = 1 },
                new Rating { Id = 57, Value = 4.5F, VideoId = 57, UserId = 1 },
                new Rating { Id = 58, Value = 4.4F, VideoId = 58, UserId = 1 },
                new Rating { Id = 59, Value = 4.3F, VideoId = 59, UserId = 1 },
                new Rating { Id = 60, Value = 4.2F, VideoId = 60, UserId = 1 },
                new Rating { Id = 61, Value = 4.1F, VideoId = 61, UserId = 1 },
                new Rating { Id = 62, Value = 4.1F, VideoId = 62, UserId = 1 },
                new Rating { Id = 63, Value = 4.1F, VideoId = 63, UserId = 1 },
                new Rating { Id = 64, Value = 4F, VideoId = 64, UserId = 1 },
                new Rating { Id = 65, Value = 3.9F, VideoId = 65, UserId = 1 },
                //
                new Rating { Id = 66, Value = 4.7F, VideoId = 66, UserId = 1 },
                new Rating { Id = 67, Value = 4.6F, VideoId = 67, UserId = 1 },
                new Rating { Id = 68, Value = 4.6F, VideoId = 68, UserId = 1 },
                new Rating { Id = 69, Value = 4.6F, VideoId = 69, UserId = 1 },
                new Rating { Id = 70, Value = 4.5F, VideoId = 70, UserId = 1 },
                new Rating { Id = 71, Value = 4.4F, VideoId = 71, UserId = 1 },
                new Rating { Id = 72, Value = 4.3F, VideoId = 72, UserId = 1 },
                new Rating { Id = 73, Value = 4.2F, VideoId = 73, UserId = 1 },
                new Rating { Id = 74, Value = 4.1F, VideoId = 74, UserId = 1 },
                new Rating { Id = 75, Value = 4.1F, VideoId = 75, UserId = 1 },
                new Rating { Id = 76, Value = 4.1F, VideoId = 76, UserId = 1 },
                new Rating { Id = 77, Value = 4F,   VideoId = 77, UserId = 1 },
                new Rating { Id = 78, Value = 3.9F, VideoId = 78, UserId = 1 },
                //
                new Rating { Id = 79, Value = 4.7F, VideoId = 79, UserId = 1 },
                new Rating { Id = 80, Value = 4.6F, VideoId = 80, UserId = 1 },
                new Rating { Id = 81, Value = 4.6F, VideoId = 81, UserId = 1 },
                new Rating { Id = 82, Value = 4.6F, VideoId = 82, UserId = 1 },
                new Rating { Id = 83, Value = 4.5F, VideoId = 83, UserId = 1 },
                new Rating { Id = 84, Value = 4.4F, VideoId = 84, UserId = 1 },
                new Rating { Id = 85, Value = 4.3F, VideoId = 85, UserId = 1 },
                new Rating { Id = 86, Value = 4.2F, VideoId = 86, UserId = 1 },
                new Rating { Id = 87, Value = 4.1F, VideoId = 87, UserId = 1 },
                new Rating { Id = 88, Value = 4.1F, VideoId = 88, UserId = 1 },
                new Rating { Id = 89, Value = 4.1F, VideoId = 89, UserId = 1 },
                new Rating { Id = 90, Value = 4F, VideoId = 90, UserId = 1 },
                new Rating { Id = 91, Value = 3.9F, VideoId = 91, UserId = 1 },
                //
                new Rating { Id = 92, Value = 4.7F, VideoId = 92, UserId = 1 },
                new Rating { Id = 93, Value = 4.6F, VideoId = 93, UserId = 1 },
                new Rating { Id = 94, Value = 4.6F, VideoId = 94, UserId = 1 },
                new Rating { Id = 95, Value = 4.6F, VideoId = 95, UserId = 1 },
                new Rating { Id = 96, Value = 4.5F, VideoId = 96, UserId = 1 },
                new Rating { Id = 97, Value = 4.4F, VideoId = 97, UserId = 1 },
                new Rating { Id = 98, Value = 4.3F, VideoId = 98, UserId = 1 },
                new Rating { Id = 99, Value = 4.2F, VideoId = 99, UserId = 1 },
                new Rating { Id = 100, Value = 4.1F, VideoId = 100, UserId = 1 },
                //   
                new Rating { Id = 101, Value = 5F, VideoId = 100, UserId = 1 },
                new Rating { Id = 102, Value = 5F, VideoId = 100, UserId = 1 },
                new Rating { Id = 103, Value = 5F, VideoId = 100, UserId = 1 },
                //
                new Rating { Id = 104, Value = 5F, VideoId = 10, UserId = 1 },
                new Rating { Id = 105, Value = 5F, VideoId = 67, UserId = 1 },
                new Rating { Id = 106, Value = 5F, VideoId = 67, UserId = 1 },
                new Rating { Id = 107, Value = 5F, VideoId = 44, UserId = 1 },
                new Rating { Id = 108, Value = 5F, VideoId = 17, UserId = 1 },
                new Rating { Id = 109, Value = 5F, VideoId = 17, UserId = 1 },
                //
                new Rating { Id = 110, Value = 5F, VideoId = 7, UserId = 1 }
            );
            #endregion

            #region Screenings, duration is in minutes
            modelBuilder.Entity<Screening>().HasData(
                new Screening { Id = 1, Name = "Screening 1", VideoId = 1, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300},
                new Screening { Id = 2, Name = "Screening 2", VideoId = 2, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 3, Name = "Screening 3", VideoId = 3, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 4, Name = "Screening 4", VideoId = 4, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 5, Name = "Screening 5", VideoId = 5, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 6, Name = "Screening 6", VideoId = 6, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 7, Name = "Screening 7", VideoId = 7, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 8, Name = "Screening 8", VideoId = 8, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 9, Name = "Screening 9", VideoId = 9, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 10, Name = "Screening 10", VideoId = 10, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 11, Name = "Screening 11", VideoId = 11, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 12, Name = "Screening 12", VideoId = 12, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },
                new Screening { Id = 13, Name = "Screening 13", VideoId = 13, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 14, Name = "Screening 14", VideoId = 14, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 15, Name = "Screening 15", VideoId = 15, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 16, Name = "Screening 16", VideoId = 16, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 17, Name = "Screening 17", VideoId = 17, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 18, Name = "Screening 18", VideoId = 18, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 19, Name = "Screening 19", VideoId = 19, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 20, Name = "Screening 20", VideoId = 20, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 21, Name = "Screening 21", VideoId = 21, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 22, Name = "Screening 22", VideoId = 22, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 23, Name = "Screening 23", VideoId = 23, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 24, Name = "Screening 24", VideoId = 24, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },

                new Screening { Id = 25, Name = "Screening 25", VideoId = 25, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 26, Name = "Screening 26", VideoId = 26, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 27, Name = "Screening 27", VideoId = 27, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 28, Name = "Screening 28", VideoId = 28, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 29, Name = "Screening 29", VideoId = 29, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 30, Name = "Screening 30", VideoId = 30, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 31, Name = "Screening 31", VideoId = 31, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 32, Name = "Screening 32", VideoId = 32, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 33, Name = "Screening 33", VideoId = 33, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 34, Name = "Screening 34", VideoId = 34, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 35, Name = "Screening 35", VideoId = 35, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 36, Name = "Screening 36", VideoId = 36, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },
                new Screening { Id = 37, Name = "Screening 37", VideoId = 37, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 38, Name = "Screening 38", VideoId = 38, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 39, Name = "Screening 39", VideoId = 39, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 40, Name = "Screening 40", VideoId = 40, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 41, Name = "Screening 41", VideoId = 41, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 42, Name = "Screening 42", VideoId = 42, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 43, Name = "Screening 43", VideoId = 43, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 44, Name = "Screening 44", VideoId = 44, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 45, Name = "Screening 45", VideoId = 45, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 46, Name = "Screening 46", VideoId = 46, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 47, Name = "Screening 47", VideoId = 47, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 48, Name = "Screening 48", VideoId = 48, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },

                new Screening { Id = 49, Name = "Screening 49", VideoId = 49, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 50, Name = "Screening 50", VideoId = 50, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 51, Name = "Screening 51", VideoId = 51, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 52, Name = "Screening 52", VideoId = 52, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 53, Name = "Screening 53", VideoId = 53, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 54, Name = "Screening 54", VideoId = 54, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 55, Name = "Screening 55", VideoId = 55, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 56, Name = "Screening 56", VideoId = 56, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 57, Name = "Screening 57", VideoId = 57, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 58, Name = "Screening 58", VideoId = 58, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 59, Name = "Screening 59", VideoId = 59, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 60, Name = "Screening 60", VideoId = 60, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },
                new Screening { Id = 61, Name = "Screening 61", VideoId = 61, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 62, Name = "Screening 62", VideoId = 62, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 63, Name = "Screening 63", VideoId = 63, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 64, Name = "Screening 64", VideoId = 64, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 65, Name = "Screening 65", VideoId = 65, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 66, Name = "Screening 66", VideoId = 66, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 67, Name = "Screening 67", VideoId = 67, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 68, Name = "Screening 68", VideoId = 68, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 69, Name = "Screening 69", VideoId = 69, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 70, Name = "Screening 70", VideoId = 70, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 71, Name = "Screening 71", VideoId = 71, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 72, Name = "Screening 72", VideoId = 72, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },

                new Screening { Id = 73, Name = "Screening 73", VideoId = 73, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 74, Name = "Screening 74", VideoId = 74, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 75, Name = "Screening 75", VideoId = 75, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 76, Name = "Screening 76", VideoId = 76, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 77, Name = "Screening 77", VideoId = 77, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 78, Name = "Screening 78", VideoId = 78, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 79, Name = "Screening 79", VideoId = 79, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 80, Name = "Screening 80", VideoId = 80, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 81, Name = "Screening 81", VideoId = 81, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 82, Name = "Screening 82", VideoId = 82, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 83, Name = "Screening 83", VideoId = 83, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 84, Name = "Screening 84", VideoId = 84, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },
                new Screening { Id = 85, Name = "Screening 85", VideoId = 85, AvailableTickets = 11, SoldTickets = 7, ScreeningDate = DateTime.Now.AddDays(30), Duration = 300 },
                new Screening { Id = 86, Name = "Screening 86", VideoId = 86, AvailableTickets = 12, SoldTickets = 6, ScreeningDate = DateTime.Now.AddDays(20), Duration = 200 },
                new Screening { Id = 87, Name = "Screening 87", VideoId = 87, AvailableTickets = 13, SoldTickets = 5, ScreeningDate = DateTime.Now.AddDays(10), Duration = 100 },
                new Screening { Id = 88, Name = "Screening 88", VideoId = 88, AvailableTickets = 14, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(5), Duration = 400 },
                new Screening { Id = 89, Name = "Screening 89", VideoId = 89, AvailableTickets = 15, SoldTickets = 3, ScreeningDate = DateTime.Now.AddDays(1), Duration = 500 },
                new Screening { Id = 90, Name = "Screening 90", VideoId = 90, AvailableTickets = 16, SoldTickets = 2, ScreeningDate = new DateTime(2015, 10, 10), Duration = 320 },
                new Screening { Id = 91, Name = "Screening 91", VideoId = 91, AvailableTickets = 10, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(30), Duration = 40 },
                new Screening { Id = 92, Name = "Screening 92", VideoId = 92, AvailableTickets = 19, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(29), Duration = 50 },
                new Screening { Id = 93, Name = "Screening 93", VideoId = 93, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 94, Name = "Screening 94", VideoId = 94, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 95, Name = "Screening 95", VideoId = 95, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 96, Name = "Screening 96", VideoId = 96, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },

                new Screening { Id = 97, Name = "Screening 97", VideoId = 97, AvailableTickets = 102, SoldTickets = 2, ScreeningDate = DateTime.Now.AddDays(1), Duration = 310 },
                new Screening { Id = 98, Name = "Screening 98", VideoId = 98, AvailableTickets = 4, SoldTickets = 4, ScreeningDate = DateTime.Now.AddDays(21), Duration = 200 },
                new Screening { Id = 99, Name = "Screening 99", VideoId = 99, AvailableTickets = 10, SoldTickets = 4, ScreeningDate = new DateTime(2010, 11, 10), Duration = 210 },
                new Screening { Id = 100, Name = "Screening 100", VideoId = 100, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2012, 1, 1), Duration = 220 },
                new Screening { Id = 101, Name = "Screening 101", VideoId = 100, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2025, 1, 1, 0, 0, 0, 0), Duration = 220 },
                new Screening { Id = 102, Name = "Screening 102", VideoId = 100, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2025, 1, 1, 0, 0, 0, 0), Duration = 220 },
                new Screening { Id = 103, Name = "Screening 103", VideoId = 100, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2025, 1, 1, 0, 0, 0, 0), Duration = 220 },

                new Screening { Id = 104, Name = "Screening 104", VideoId = 104, AvailableTickets = 22, SoldTickets = 22, ScreeningDate = new DateTime(2015, 1, 1, 0, 0, 0, 0), Duration = 120 },
                new Screening { Id = 105, Name = "Screening 105", VideoId = 105, AvailableTickets = 22, SoldTickets = 21, ScreeningDate = new DateTime(2021, 1, 1, 0, 0, 0, 0), Duration = 100 },
                new Screening { Id = 106, Name = "Screening 106", VideoId = 106, AvailableTickets = 22, SoldTickets = 11, ScreeningDate = new DateTime(2022, 1, 1, 0, 0, 0, 0), Duration = 90 }
            );
            #endregion

            modelBuilder.Entity<MostRatedMoviesReport>().HasNoKey();

            modelBuilder.Entity<MoviesWithMostScreeningsReport>().HasNoKey();

            modelBuilder.Entity<MoviesWithMostSoldTicketsReport>().HasNoKey();
        }
    }
}
