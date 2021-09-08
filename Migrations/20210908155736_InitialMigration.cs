using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jap_task2_backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MostRatedMoviesReports",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfRatings = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MoviesWithMostScreeningsReports",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfScreenings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MoviesWithMostSoldTicketsReports",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreeningName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Hash = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorVideo",
                columns: table => new
                {
                    ActorsId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorVideo", x => new { x.ActorsId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_ActorVideo_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorVideo_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryVideo",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVideo", x => new { x.CategoriesId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_CategoryVideo_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVideo_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false),
                    SoldTickets = table.Column<int>(type: "int", nullable: false),
                    ScreeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoughtTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreeningId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BoughtTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoughtTickets_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoughtTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Morgan", "Freeman" },
                    { 51, "Lance", "Reddick" },
                    { 50, "Dominic", "West" },
                    { 49, "Jessie", "Buckley" },
                    { 48, "Stellan", "Skarsgard" },
                    { 47, "Jared", "Harris" },
                    { 46, "Jessie", "Buckley" },
                    { 52, "Sonja", "Sohn" },
                    { 45, "Ron", "Livingston" },
                    { 43, "Scott", "Grimes" },
                    { 42, "Anna", "Gunn" },
                    { 41, "Aaron", "Paul" },
                    { 40, "Bryan", "Cranston" },
                    { 39, "Nikolay", "Drozdov" },
                    { 38, "Sigourney", "Weaver" },
                    { 44, "Damian", "Lewis" },
                    { 37, "David", "Attenborough" },
                    { 53, "Peter", "Drost" },
                    { 55, "Neil", "deGrasse Tyson" },
                    { 70, "Eddie", "Falco" },
                    { 68, "James", "Gandolfini" },
                    { 67, "Kit", "Harington" },
                    { 66, "Peter", "Dinklage" },
                    { 65, "Emilia", "Clarke" },
                    { 64, "Jonathan", "Fahn" },
                    { 54, "Roger", "Horrocks" },
                    { 63, "Jaromir", "Hanzlik" },
                    { 61, "Mae", "Whitman" },
                    { 60, "Zach", "Tyler" },
                    { 59, "Dee", "Bradley Baker" },
                    { 58, "Neil", "deGrasse Tyson" },
                    { 57, "Piotr", "Michael" },
                    { 56, "Stoney", "Emshwiller" },
                    { 62, "Carl", "Sagan" },
                    { 36, "Elliot", "Page" },
                    { 69, "Lorraine", "Bracco" },
                    { 34, "Leonardo", "DiCaprio" },
                    { 15, "Liam", "Neeson" },
                    { 13, "Lee", "J. Cobb" },
                    { 12, "Henry", "Fonda" },
                    { 11, "Aaron", "Eckhart" },
                    { 10, "Heath", "Ledger" }
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 9, "Christian", "Bale" },
                    { 16, "Ralph", "Fiennes" },
                    { 8, "Robert", "Duvall" },
                    { 6, "James", "Caan" },
                    { 5, "Al", "Pacino" },
                    { 4, "Marlon", "Brando" },
                    { 3, "Tim", "Robbins" },
                    { 35, "Joseph", "Gordon-Levitt" },
                    { 2, "Bob", "Gunton" },
                    { 7, "Robert", "De Niro" },
                    { 17, "Ben", "Kingsley" },
                    { 14, "Martin", "Balsam" },
                    { 19, "Viggo", "Mortensen" },
                    { 33, "Gary", "Sinise" },
                    { 32, "Robin", "Wright" },
                    { 31, "Tom", "Hanks" },
                    { 30, "Meat", "Loaf" },
                    { 18, "Elijah", "Wood" },
                    { 28, "Brad", "Pitt" },
                    { 27, "Orlando", "Bloom" },
                    { 29, "Edward", "Norton" },
                    { 25, "Eli", "Wallach" },
                    { 24, "Clint", "Eastwood" },
                    { 23, "Samuel", "L. Jackson" },
                    { 22, "Uma", "Thurman" },
                    { 21, "John", "Travolta" },
                    { 20, "Ian", "McKellen" },
                    { 26, "Lee", "Van Cleef" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "BIOGRAPHY" },
                    { 15, "ANIMATION" },
                    { 14, "HISTORY" },
                    { 13, "DOCUMENTARY" },
                    { 12, "SCI-FI" },
                    { 11, "ROMANCE" },
                    { 9, "WESTERN" },
                    { 4, "DRAMA" },
                    { 7, "BIOGRAPHY" },
                    { 6, "CRIME" },
                    { 5, "TRAGEDY" },
                    { 8, "ADVENTURE" },
                    { 3, "THRILLER" },
                    { 2, "COMEDY" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ACTION" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Hash", "Name", "Salt", "Surname" },
                values: new object[] { 1, "admin@gmail.com", new byte[] { 179, 89, 126, 101, 155, 38, 85, 8, 219, 209, 215, 47, 3, 137, 54, 103, 167, 193, 70, 54, 227, 31, 8, 20, 99, 121, 28, 154, 90, 107, 152, 38, 50, 211, 236, 197, 232, 200, 154, 254, 38, 123, 221, 168, 222, 61, 146, 47, 146, 237, 77, 33, 141, 108, 32, 130, 119, 209, 248, 189, 190, 19, 240, 139 }, "Admin", new byte[] { 115, 110, 208, 249, 74, 66, 174, 187, 129, 40, 49, 36, 196, 102, 242, 46, 72, 18, 240, 134, 215, 164, 198, 94, 244, 106, 127, 80, 237, 167, 44, 25, 76, 207, 208, 2, 191, 50, 222, 167, 238, 53, 107, 221, 148, 198, 137, 133, 241, 141, 90, 149, 108, 102, 113, 183, 107, 138, 248, 243, 124, 243, 163, 53, 117, 50, 108, 157, 225, 179, 225, 147, 186, 105, 171, 201, 60, 79, 12, 193, 224, 136, 52, 128, 56, 63, 10, 179, 64, 254, 194, 142, 111, 136, 141, 194, 25, 217, 210, 157, 160, 233, 180, 199, 32, 120, 215, 61, 34, 136, 2, 106, 169, 110, 218, 145, 250, 209, 175, 200, 209, 52, 234, 112, 173, 129, 50, 162 }, "Admin" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Description", "Image_Url", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { 69, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 5", (short)0 },
                    { 70, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 5", (short)0 },
                    { 71, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men 5", (short)0 },
                    { 72, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List 5", (short)0 },
                    { 75, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 51", (short)0 },
                    { 74, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 5", (short)0 },
                    { 68, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 5", (short)0 },
                    { 76, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 52", (short)0 },
                    { 77, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 53", (short)0 },
                    { 73, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King 5", (short)0 },
                    { 67, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 5", (short)0 },
                    { 63, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club 4", (short)0 },
                    { 65, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 4", (short)0 },
                    { 64, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump 4", (short)0 },
                    { 62, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring 4", (short)0 },
                    { 61, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly 4", (short)0 },
                    { 60, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 4", (short)0 },
                    { 59, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King 4", (short)0 },
                    { 58, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List 4", (short)0 },
                    { 57, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men 4", (short)0 },
                    { 56, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 4", (short)0 },
                    { 55, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 4", (short)0 },
                    { 78, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly 5", (short)0 },
                    { 66, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 4444", (short)0 },
                    { 79, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly 51", (short)0 },
                    { 104, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 76", (short)0 },
                    { 81, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club 5", (short)0 },
                    { 54, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 4", (short)0 },
                    { 103, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 76", (short)0 },
                    { 102, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 66", (short)0 },
                    { 101, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump 66", (short)0 },
                    { 100, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 7", (short)0 },
                    { 99, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 7", (short)0 },
                    { 98, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 7", (short)0 },
                    { 97, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 7", (short)0 },
                    { 96, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 6", (short)0 },
                    { 95, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump 6", (short)0 },
                    { 94, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club 6", (short)0 },
                    { 93, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring 6", (short)0 },
                    { 92, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly 6", (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Description", "Image_Url", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { 91, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 6", (short)0 },
                    { 90, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King 6", (short)0 },
                    { 89, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List 6", (short)0 },
                    { 88, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men 6", (short)0 },
                    { 87, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 6", (short)0 },
                    { 86, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 6", (short)0 },
                    { 85, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 6", (short)0 },
                    { 84, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 6", (short)0 },
                    { 83, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 5", (short)0 },
                    { 82, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump 5", (short)0 },
                    { 80, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring 5", (short)0 },
                    { 53, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 4", (short)0 },
                    { 10, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring", (short)0 },
                    { 51, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump 3", (short)0 },
                    { 23, "In a war-torn world of elemental magic, a young boy reawakens to undertake a dangerous mystic quest to fulfill his destiny as the Avatar, and bring peace to the world.", "https://images-na.ssl-images-amazon.com/images/I/914eUC4XPML.jpg", new DateTime(2005, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar: The Last Airbender", (short)1 },
                    { 22, "An exploration of our discovery of the laws of nature and coordinates in space and time.", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/5945/5945188_sa.jpg;maxHeight=640;maxWidth=550", new DateTime(2014, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmos: A Spacetime Odyssey", (short)1 },
                    { 21, "Documentary series focusing on the breadth of the diversity of habitats around the world, from the remote Arctic wilderness and mysterious deep oceans to the vast landscapes of Africa and diverse jungles of South America.", "https://www.penguin.co.uk/content/dam/prh/books/111/1115210/9780593079768.jpg.transform/PRHDesktopWide_small/image.jpg", new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our Planet", (short)1 },
                    { 20, "David Attenborough returns to the world's oceans in this sequel to the acclaimed documentary filming rare and unusual creatures of the deep, as well as documenting the problems our oceans face.", "https://cdn.shopify.com/s/files/1/0747/3829/products/mL1006_1024x1024.jpg?v=1571445246", new DateTime(2017, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Planet II", (short)1 },
                    { 19, "The Baltimore drug scene, as seen through the eyes of drug dealers and law enforcement.", "https://tvshows.today/wp-content/uploads/the-wire-season-1-poster.jpg", new DateTime(2008, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wire", (short)1 },
                    { 18, "In April 1986, an explosion at the Chernobyl nuclear power plant in the Union of Soviet Socialist Republics becomes one of the world's worst man-made catastrophes.", "https://i.redd.it/bv5isr69yr531.png", new DateTime(1986, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chernobyl", (short)1 },
                    { 17, "The story of Easy Company of the U.S. Army 101st Airborne Division and their mission in World War II Europe, from Operation Overlord to V-J Day.", "https://i.dailymail.co.uk/i/pix/2017/02/13/01/3D24EF6B00000578-4215748-image-a-63_1486948627611.jpg", new DateTime(2001, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Band of Brothers", (short)1 },
                    { 16, "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.", "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ggFHVNu6YYI5L9pCfOacjizRGt.jpg", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breaking Bad", (short)1 },
                    { 15, "Emmy Award-winning, 11 episodes, five years in the making, the most expensive nature documentary series ever commissioned by the BBC, and the first to be filmed in high definition.", "https://m.media-amazon.com/images/I/91X9p6+58KL._SY445_.jpg", new DateTime(2010, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planet Earth", (short)1 },
                    { 14, "Wildlife documentary series with David Attenborough, beginning with a look at the remote islands which offer sanctuary to some of the planet's rarest creatures, to the beauty of cities, which are home to humans, and animals..", "https://blackwells.co.uk/jacket/l/9781785943041.jpg", new DateTime(2016, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planet Earth II", (short)1 },
                    { 13, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", (short)0 },
                    { 12, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump", (short)0 },
                    { 11, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club", (short)0 },
                    { 105, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 76", (short)0 },
                    { 9, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly", (short)0 },
                    { 8, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction", (short)0 },
                    { 7, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King", (short)0 },
                    { 6, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List", (short)0 },
                    { 5, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men", (short)0 },
                    { 4, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", (short)0 },
                    { 3, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II", (short)0 },
                    { 2, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather", (short)0 },
                    { 1, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption", (short)0 },
                    { 24, "Astronomer Carl Sagan leads us on an engaging guided tour of the various elements and cosmological theories of the universe.", "https://www.themoviedb.org/t/p/original/4WJ9kNejI8apl3f8hMNwo8V3hGT.jpg", new DateTime(1980, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmos", (short)1 },
                    { 52, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 3", (short)0 },
                    { 25, "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.", "https://m.media-amazon.com/images/M/MV5BYTRiNDQwYzAtMzVlZS00NTI5LWJjYjUtMzkwNTUzMWMxZTllXkEyXkFqcGdeQXVyNDIzMzcwNjc@._V1_FMjpg_UX1000_.jpg", new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game of Thrones", (short)1 },
                    { 27, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 2", (short)0 },
                    { 50, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club 3", (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Description", "Image_Url", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { 49, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring 3", (short)0 },
                    { 48, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly 3", (short)0 },
                    { 47, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 3", (short)0 },
                    { 46, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King 3", (short)0 },
                    { 45, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List 3", (short)0 },
                    { 44, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men 3", (short)0 },
                    { 43, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 3", (short)0 },
                    { 42, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 3", (short)0 },
                    { 41, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 3", (short)0 },
                    { 40, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption 3", (short)0 },
                    { 39, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception 2", (short)0 },
                    { 38, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump 2", (short)0 },
                    { 37, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club 2", (short)0 },
                    { 36, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring 2", (short)0 },
                    { 35, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly 2", (short)0 },
                    { 34, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction 2", (short)0 },
                    { 33, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King 2", (short)0 },
                    { 32, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List 2", (short)0 },
                    { 31, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men 2", (short)0 },
                    { 30, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 2", (short)0 },
                    { 29, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II 2", (short)0 },
                    { 28, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather 2", (short)0 },
                    { 26, "New Jersey mob boss Tony Soprano deals with personal and professional issues in his home and business life that affect his mental state, leading him to seek professional psychiatric counseling.", "https://m.media-amazon.com/images/M/MV5BZGJjYzhjYTYtMDBjYy00OWU1LTg5OTYtNmYwOTZmZjE3ZDdhXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_FMjpg_UX1000_.jpg", new DateTime(1999, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sopranos", (short)1 },
                    { 106, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight 76", (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "UserId", "Value", "VideoId" },
                values: new object[,]
                {
                    { 1, 1, 4.6f, 1 },
                    { 68, 1, 4.6f, 68 },
                    { 67, 1, 4.6f, 67 },
                    { 66, 1, 4.7f, 66 },
                    { 65, 1, 3.9f, 65 },
                    { 64, 1, 4f, 64 },
                    { 63, 1, 4.1f, 63 },
                    { 62, 1, 4.1f, 62 },
                    { 61, 1, 4.1f, 61 },
                    { 60, 1, 4.2f, 60 },
                    { 59, 1, 4.3f, 59 },
                    { 58, 1, 4.4f, 58 },
                    { 57, 1, 4.5f, 57 },
                    { 56, 1, 4.6f, 56 },
                    { 55, 1, 4.6f, 55 },
                    { 69, 1, 4.6f, 69 },
                    { 54, 1, 4.6f, 54 },
                    { 51, 1, 4f, 51 },
                    { 50, 1, 4.1f, 50 },
                    { 49, 1, 4.1f, 49 },
                    { 48, 1, 4.1f, 48 },
                    { 47, 1, 4.2f, 47 },
                    { 46, 1, 4.3f, 46 },
                    { 45, 1, 4.4f, 45 },
                    { 44, 1, 4.5f, 44 },
                    { 43, 1, 4.6f, 43 },
                    { 42, 1, 4.6f, 42 },
                    { 41, 1, 4.6f, 41 },
                    { 40, 1, 4.7f, 40 },
                    { 39, 1, 3.9f, 39 },
                    { 38, 1, 4f, 38 },
                    { 52, 1, 3.9f, 52 },
                    { 70, 1, 4.5f, 70 },
                    { 71, 1, 4.4f, 71 },
                    { 72, 1, 4.3f, 72 },
                    { 103, 1, 1.5f, 100 },
                    { 102, 1, 2.3f, 100 },
                    { 101, 1, 1f, 100 },
                    { 100, 1, 4.1f, 100 },
                    { 99, 1, 4.2f, 99 },
                    { 98, 1, 4.3f, 98 },
                    { 97, 1, 4.4f, 97 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "UserId", "Value", "VideoId" },
                values: new object[,]
                {
                    { 96, 1, 4.5f, 96 },
                    { 95, 1, 4.6f, 95 },
                    { 94, 1, 4.6f, 94 },
                    { 93, 1, 4.6f, 93 },
                    { 92, 1, 4.7f, 92 },
                    { 91, 1, 3.9f, 91 },
                    { 90, 1, 4f, 90 },
                    { 89, 1, 4.1f, 89 },
                    { 88, 1, 4.1f, 88 },
                    { 87, 1, 4.1f, 87 },
                    { 73, 1, 4.2f, 73 },
                    { 74, 1, 4.1f, 74 },
                    { 75, 1, 4.1f, 75 },
                    { 76, 1, 4.1f, 76 },
                    { 77, 1, 4f, 77 },
                    { 78, 1, 3.9f, 78 },
                    { 37, 1, 4.1f, 37 },
                    { 79, 1, 4.7f, 79 },
                    { 81, 1, 4.6f, 81 },
                    { 82, 1, 4.6f, 82 },
                    { 83, 1, 4.5f, 83 },
                    { 84, 1, 4.4f, 84 },
                    { 85, 1, 4.3f, 85 },
                    { 86, 1, 4.2f, 86 },
                    { 80, 1, 4.6f, 80 },
                    { 36, 1, 4.1f, 36 },
                    { 53, 1, 4.7f, 53 },
                    { 18, 1, 4.5f, 18 },
                    { 29, 1, 4.6f, 29 },
                    { 10, 1, 4.2f, 10 },
                    { 20, 1, 4.3f, 20 },
                    { 28, 1, 4.6f, 28 },
                    { 6, 1, 4.35f, 6 },
                    { 12, 1, 4.1f, 12 },
                    { 27, 1, 4.7f, 27 },
                    { 7, 1, 4.3f, 7 },
                    { 21, 1, 4.2f, 21 },
                    { 26, 1, 3.9f, 26 },
                    { 8, 1, 4.2f, 8 },
                    { 16, 1, 4.6f, 16 },
                    { 11, 1, 4.2f, 11 },
                    { 25, 1, 4f, 25 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "UserId", "Value", "VideoId" },
                values: new object[,]
                {
                    { 22, 1, 4.1f, 22 },
                    { 9, 1, 4.2f, 9 },
                    { 24, 1, 4.1f, 24 },
                    { 5, 1, 4.4f, 5 },
                    { 13, 1, 4.1f, 13 },
                    { 23, 1, 4.1f, 23 },
                    { 30, 1, 4.6f, 30 },
                    { 19, 1, 4.4f, 19 },
                    { 2, 1, 4.5f, 2 },
                    { 14, 1, 4.7f, 14 },
                    { 34, 1, 4.2f, 34 },
                    { 32, 1, 4.4f, 32 },
                    { 3, 1, 4.5f, 3 },
                    { 17, 1, 4.6f, 17 },
                    { 15, 1, 4.6f, 15 },
                    { 31, 1, 4.5f, 31 },
                    { 4, 1, 4.5f, 4 },
                    { 35, 1, 4.1f, 35 },
                    { 33, 1, 4.3f, 33 }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AvailableTickets", "Duration", "Name", "ScreeningDate", "SoldTickets", "VideoId" },
                values: new object[,]
                {
                    { 84, 22, 220f, "Screening 84", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 84 },
                    { 75, 13, 100f, "Screening 75", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1922), 5, 75 },
                    { 10, 4, 200f, "Screening 10", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1729), 4, 10 },
                    { 85, 11, 300f, "Screening 85", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1942), 7, 85 },
                    { 76, 14, 400f, "Screening 76", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1925), 4, 76 },
                    { 11, 10, 210f, "Screening 11", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 11 },
                    { 77, 15, 500f, "Screening 77", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1927), 3, 77 },
                    { 83, 10, 210f, "Screening 83", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 83 },
                    { 82, 4, 200f, "Screening 82", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1938), 4, 82 },
                    { 81, 102, 310f, "Screening 81", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1936), 2, 81 },
                    { 78, 16, 320f, "Screening 78", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 78 },
                    { 12, 22, 220f, "Screening 12", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 12 },
                    { 13, 11, 300f, "Screening 13", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1733), 7, 13 },
                    { 79, 10, 40f, "Screening 79", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1930), 2, 79 },
                    { 14, 12, 200f, "Screening 14", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1736), 6, 14 },
                    { 80, 19, 50f, "Screening 80", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1933), 2, 80 },
                    { 89, 15, 500f, "Screening 89", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1952), 3, 89 },
                    { 9, 102, 310f, "Screening 9", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1726), 2, 9 },
                    { 104, 22, 120f, "Screening 104", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 104 },
                    { 103, 22, 220f, "Screening 103", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 100 },
                    { 102, 22, 220f, "Screening 102", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 100 },
                    { 101, 22, 220f, "Screening 101", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 100 },
                    { 100, 22, 220f, "Screening 100", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 100 }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AvailableTickets", "Duration", "Name", "ScreeningDate", "SoldTickets", "VideoId" },
                values: new object[,]
                {
                    { 1, 11, 300f, "Screening 1", new DateTime(2021, 10, 8, 17, 57, 36, 239, DateTimeKind.Local).AddTicks(2778), 7, 1 },
                    { 2, 12, 200f, "Screening 2", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1679), 6, 2 },
                    { 99, 10, 210f, "Screening 99", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 99 },
                    { 3, 13, 100f, "Screening 3", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1710), 5, 3 },
                    { 98, 4, 200f, "Screening 98", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1971), 4, 98 },
                    { 97, 102, 310f, "Screening 97", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1968), 2, 97 },
                    { 4, 14, 400f, "Screening 4", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1714), 4, 4 },
                    { 96, 22, 220f, "Screening 96", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 96 },
                    { 95, 10, 210f, "Screening 95", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 95 },
                    { 5, 15, 500f, "Screening 5", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1717), 3, 5 },
                    { 94, 4, 200f, "Screening 94", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1964), 4, 94 },
                    { 93, 102, 310f, "Screening 93", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1962), 2, 93 },
                    { 6, 16, 320f, "Screening 6", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 92, 19, 50f, "Screening 92", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1959), 2, 92 },
                    { 91, 10, 40f, "Screening 91", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1956), 2, 91 },
                    { 7, 10, 40f, "Screening 7", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1721), 2, 7 },
                    { 90, 16, 320f, "Screening 90", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 90 },
                    { 8, 19, 50f, "Screening 8", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1724), 2, 8 },
                    { 88, 14, 400f, "Screening 88", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1949), 4, 88 },
                    { 87, 13, 100f, "Screening 87", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1947), 5, 87 },
                    { 86, 12, 200f, "Screening 86", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1945), 6, 86 },
                    { 15, 13, 100f, "Screening 15", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1739), 5, 15 },
                    { 35, 10, 210f, "Screening 35", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 35 },
                    { 73, 11, 300f, "Screening 73", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1917), 7, 73 },
                    { 52, 14, 400f, "Screening 52", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1873), 4, 52 },
                    { 26, 12, 200f, "Screening 26", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1761), 6, 26 },
                    { 51, 13, 100f, "Screening 51", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1870), 5, 51 },
                    { 50, 12, 200f, "Screening 50", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1867), 6, 50 },
                    { 27, 13, 100f, "Screening 27", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1817), 5, 27 },
                    { 49, 11, 300f, "Screening 49", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1864), 7, 49 },
                    { 48, 22, 220f, "Screening 48", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 48 },
                    { 28, 14, 400f, "Screening 28", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1821), 4, 28 },
                    { 47, 10, 210f, "Screening 47", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 47 },
                    { 46, 4, 200f, "Screening 46", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1860), 4, 46 },
                    { 29, 15, 500f, "Screening 29", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1823), 3, 29 },
                    { 45, 102, 310f, "Screening 45", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1858), 2, 45 },
                    { 105, 22, 100f, "Screening 105", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 105 },
                    { 44, 19, 50f, "Screening 44", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1855), 2, 44 },
                    { 43, 10, 40f, "Screening 43", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1852), 2, 43 },
                    { 42, 16, 320f, "Screening 42", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 42 },
                    { 31, 10, 40f, "Screening 31", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1827), 2, 31 },
                    { 41, 15, 500f, "Screening 41", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1849), 3, 41 }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "AvailableTickets", "Duration", "Name", "ScreeningDate", "SoldTickets", "VideoId" },
                values: new object[,]
                {
                    { 40, 14, 400f, "Screening 40", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1846), 4, 40 },
                    { 32, 19, 50f, "Screening 32", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1830), 2, 32 },
                    { 39, 13, 100f, "Screening 39", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1844), 5, 39 },
                    { 38, 12, 200f, "Screening 38", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1841), 6, 38 },
                    { 33, 102, 310f, "Screening 33", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1832), 2, 33 },
                    { 37, 11, 300f, "Screening 37", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1839), 7, 37 },
                    { 36, 22, 220f, "Screening 36", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 36 },
                    { 34, 4, 200f, "Screening 34", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1835), 4, 34 },
                    { 30, 16, 320f, "Screening 30", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 30 },
                    { 53, 15, 500f, "Screening 53", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1875), 3, 53 },
                    { 54, 16, 320f, "Screening 54", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 54 },
                    { 25, 11, 300f, "Screening 25", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1759), 7, 25 },
                    { 16, 14, 400f, "Screening 16", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1742), 4, 16 },
                    { 72, 22, 220f, "Screening 72", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 72 },
                    { 71, 10, 210f, "Screening 71", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 71 },
                    { 17, 15, 500f, "Screening 17", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1744), 3, 17 },
                    { 70, 4, 200f, "Screening 70", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1913), 4, 70 },
                    { 69, 102, 310f, "Screening 69", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1910), 2, 69 },
                    { 18, 16, 320f, "Screening 18", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 18 },
                    { 68, 19, 50f, "Screening 68", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1908), 2, 68 },
                    { 67, 10, 40f, "Screening 67", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1905), 2, 67 },
                    { 19, 10, 40f, "Screening 19", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1747), 2, 19 },
                    { 66, 16, 320f, "Screening 66", new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 66 },
                    { 65, 15, 500f, "Screening 65", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1902), 3, 65 },
                    { 20, 19, 50f, "Screening 20", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1750), 2, 20 },
                    { 64, 14, 400f, "Screening 64", new DateTime(2021, 9, 13, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1899), 4, 64 },
                    { 63, 13, 100f, "Screening 63", new DateTime(2021, 9, 18, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1897), 5, 63 },
                    { 21, 102, 310f, "Screening 21", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1752), 2, 21 },
                    { 62, 12, 200f, "Screening 62", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1894), 6, 62 },
                    { 61, 11, 300f, "Screening 61", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1891), 7, 61 },
                    { 22, 4, 200f, "Screening 22", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1755), 4, 22 },
                    { 60, 22, 220f, "Screening 60", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 60 },
                    { 59, 10, 210f, "Screening 59", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 59 },
                    { 23, 10, 210f, "Screening 23", new DateTime(2010, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 23 },
                    { 58, 4, 200f, "Screening 58", new DateTime(2021, 9, 29, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1887), 4, 58 },
                    { 57, 102, 310f, "Screening 57", new DateTime(2021, 9, 9, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1884), 2, 57 },
                    { 24, 22, 220f, "Screening 24", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 24 },
                    { 56, 19, 50f, "Screening 56", new DateTime(2021, 10, 7, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1881), 2, 56 },
                    { 55, 10, 40f, "Screening 55", new DateTime(2021, 10, 8, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1878), 2, 55 },
                    { 74, 12, 200f, "Screening 74", new DateTime(2021, 9, 28, 17, 57, 36, 241, DateTimeKind.Local).AddTicks(1919), 6, 74 },
                    { 106, 22, 90f, "Screening 106", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 106 }
                });

            migrationBuilder.InsertData(
                table: "ActorVideo",
                columns: new[] { "ActorsId", "VideosId" },
                values: new object[,]
                {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 2 },
                { 5, 2 },
                { 6, 2 },
                { 5, 3 },
                { 7, 3 },
                { 8, 3 },
                { 9, 4 },
                { 10, 4 },
                { 11, 4 },
                { 12, 5 },
                { 13, 5 },
                { 14, 5 },
                { 15, 6 },
                { 16, 6 },
                { 17, 6 },
                { 18, 7 },
                { 19, 7 },
                { 20, 7 },
                { 21, 8 },
                { 22, 8 },
                { 23, 8 },
                { 24, 9 },
                { 25, 9 },
                { 26, 9 },
                { 18, 10 },
                { 20, 10 },
                { 27, 10 },
                { 28, 11 },
                { 29, 11 },
                { 30, 11 },
                { 31, 12 },
                { 32, 12 },
                { 33, 12 },
                { 34, 13 },
                { 35, 13 },
                { 36, 13 },
                { 37, 14 },
                { 37, 15 },
                { 38, 15 },
                { 39, 15 },
                { 40, 16 },
                { 41, 16 },
                { 42, 16 },
                { 43, 17 },
                { 44, 17 },
                { 45, 17 },
                { 46, 18 },
                { 47, 18 },
                { 48, 18 },
                { 50, 19 },
                { 51, 19 },
                { 52, 19 },
                { 37, 20 },
                { 53, 20 },
                { 54, 20 },
                { 37, 21 },
                { 56, 22 },
                { 57, 22 },
                { 58, 22 },
                { 59, 23 },
                { 60, 23 },
                { 61, 23 },
                { 62, 24 },
                { 63, 24 },
                { 64, 24 },
                { 65, 25 },
                { 66, 25 },
                { 67, 25 },
                { 68, 26 },
                { 69, 26 },
                { 70, 26 },

                { 1, 27 },
                { 2, 27 },
                { 3, 27 },
                { 4, 28 },
                { 5, 28 },
                { 6, 28 },
                { 5, 29 },
                { 7, 29 },
                { 8, 29 },
                { 9, 30 },
                { 10, 30 },
                { 11, 30 },
                { 12, 31 },
                { 13, 31 },
                { 14, 31 },
                { 15, 32 },
                { 16, 32 },
                { 17, 32 },
                { 18, 33 },
                { 19, 34 },
                { 20, 35 },
                { 21, 36 },
                { 22, 36 },
                { 23, 36 },
                { 24, 37 },
                { 25, 37 },
                { 26, 37 },
                { 18, 38 },
                { 20, 39 },
                { 27, 39 },
                { 28, 40 },
                { 29, 40 },
                { 30, 40 },
                { 31, 41 },
                { 32, 41 },
                { 33, 41 },
                { 34, 42 },
                { 35, 42 },
                { 36, 42 },
                { 37, 43 },
                { 37, 44 },
                { 38, 44 },
                { 39, 44 },
                { 40, 45 },
                { 41, 45 },
                { 42, 45 },
                { 43, 46 },
                { 44, 46 },
                { 45, 46 },
                { 46, 47 },
                { 47, 47 },
                { 48, 47 },
                { 50, 48 },
                { 51, 48 },
                { 52, 48 },
                { 37, 49 },
                { 53, 49 },
                { 54, 49 },
                { 37, 50 },
                { 56, 51 },
                { 57, 51 },
                { 58, 51 },
                { 59, 52 },
                { 60, 52 },
                { 61, 52 },
                { 62, 53 },
                { 63, 53 },
                { 64, 53 },
                { 65, 54 },
                { 66, 54 },
                { 67, 54 },
                { 68, 55 },
                { 69, 55 },
                { 70, 55 },

                { 1, 56 },
                { 2, 56 },
                { 3, 56 },
                { 4, 57 },
                { 5, 57 },
                { 6, 57 },
                { 5, 58 },
                { 7, 58 },
                { 8, 58 },
                { 9, 59 },
                { 10, 59 },
                { 11, 59 },
                { 12, 60 },
                { 13, 60 },
                { 14, 60 },
                { 15, 61 },
                { 16, 61 },
                { 17, 61 },
                { 18, 62 },
                { 19, 62 },
                { 20, 62 },
                { 21, 63 },
                { 22, 63 },
                { 23, 63 },
                { 24, 64 },
                { 25, 64 },
                { 26, 64 },
                { 18, 65 },
                { 20, 65 },
                { 27, 65 },
                { 28, 66 },
                { 29, 66 },
                { 30, 66 },
                { 31, 67 },
                { 32, 67 },
                { 33, 67 },
                { 34, 68 },
                { 35, 68 },
                { 36, 68 },
                { 37, 69 },
                { 37, 70 },
                { 38, 71 },
                { 39, 71 },
                { 40, 72 },
                { 41, 72 },
                { 42, 72 },
                { 43, 73 },
                { 44, 73 },
                { 45, 74 },
                { 46, 75 },
                { 47, 75 },
                { 48, 75 },
                { 50, 76 },
                { 51, 76 },
                { 52, 76 },
                { 37, 77 },
                { 53, 77 },
                { 54, 77 },
                { 37, 78 },
                { 56, 79 },
                { 57, 80 },
                { 58, 81 },
                { 59, 82 },
                { 60, 82 },
                { 61, 82 },
                { 62, 83 },
                { 63, 83 },
                { 64, 84 },
                { 65, 85 },
                { 66, 85 },
                { 67, 86 },
                { 68, 87 },
                { 69, 87 },
                { 70, 88 },

                { 1, 89 },
                { 2, 89 },
                { 3, 89 },
                { 4, 90 },
                { 5, 91 },
                { 6, 92 },
                { 5, 92 },
                { 7, 93 },
                { 8, 94 },
                { 9, 94 },
                { 10, 94 },
                { 11, 95 },
                { 12, 95 },
                { 13, 95 },
                { 14, 95 },
                { 15, 96 },
                { 16, 96 },
                { 17, 96 },
                { 18, 97 },
                { 19, 97 },
                { 20, 97 },
                { 21, 98 },
                { 22, 98 },
                { 23, 89 },
                { 24, 99 },
                { 25, 99 },
                { 26, 99 },
                { 18, 100 },
                { 20, 100 },
                { 27, 100 }
            });

            migrationBuilder.InsertData(
                table: "CategoryVideo",
                columns: new[] { "CategoriesId", "VideosId" },
                values: new object[,]
                {
                { 4,  1 },
                { 6,  2 },
                { 4,  2 },
                { 4,  3 },
                { 6,  3 },
                { 4,  4 },
                { 6,  4 },
                { 1,  4 },
                { 4,  5 },
                { 6,  5 },
                { 4,  6 },
                { 7,  6 },
                { 14,  6 },
                { 4,  7 },
                { 8,  7 },
                { 1,  7 },
                { 4,  8 },
                { 6,  8 },
                { 9,  9 },
                { 4,  10 },
                { 8,  10 },
                { 1,  10 },
                { 4,  11 },
                { 4,  12 },
                { 4,  13 },
                { 11,  13 },
                { 13,  14 },
                { 13,  15 },
                { 4,  16 },
                { 6,  16 },
                { 3,  16 },
                { 4,  17 },
                { 1,  17 },
                { 14,  17 },
                { 4,  18 },
                { 14,  18 },
                { 3,  18 },
                { 4,  19 },
                { 6,  19 },
                { 3,  19 },
                { 13,  20 },
                { 13,  21 },
                { 13,  22 },
                { 15,  23 },
                { 1,  23 },
                { 8,  23 },
                { 13,  24 },
                { 1,  25 },
                { 8,  25 },
                { 4,  25 },
                { 4,  26 },
                { 6,  26 },

                { 4,  27 },
                { 6,  28 },
                { 4,  29 },
                { 4,  30 },
                { 6,  31 },
                { 4,  32 },
                { 6,  33 },
                { 1,  34 },
                { 4,  35 },
                { 6,  36 },
                { 4,  37 },
                { 7,  38 },
                { 14, 39 },
                { 4,  40 },
                { 8,  41 },
                { 1,  42 },
                { 4,  43 },
                { 6,  44 },
                { 9,  45 },
                { 4,  46 },
                { 8,  47 },
                { 1,  48 },
                { 4,  49 },
                { 4,  50 },
                { 4,  51 },
                { 11, 52 },
                { 13, 53 },
                { 13, 54 },
                { 4,  55 },
                { 6,  56 },
                { 3,  57 },
                { 4,  58 },
                { 1,  59 },
                { 14, 60 },
                { 4,  61 },
                { 14, 62 },
                { 3,  63 },
                { 4,  64 },
                { 6,  65 },
                { 3,  66 },
                { 13, 67 },
                { 13, 68 },
                { 13, 69 },
                { 15, 70 },
                { 1,  71 },
                { 8,  72 },
                { 13, 73 },
                { 1,  74 },
                { 8,  75 },
                { 4,  76 },
                { 4,  77 },
                { 6,  78 },

                { 4,  79 },
                { 6,  80 },
                { 4,  81 },
                { 4,  82 },
                { 6,  83 },
                { 4,  84 },
                { 6,  85 },
                { 1,  86 },
                { 4,  87 },
                { 6,  88 },
                { 4,  89 },
                { 7,  90 },
                { 14, 91 },
                { 4,  92 },
                { 8,  93 },
                { 1,  94 },
                { 4,  95 },
                { 6,  96 },
                { 9,  97 },
                { 4,  98 },
                { 8,  99 },
                { 1,  100 }
            });

            migrationBuilder.CreateIndex(
                name: "IX_ActorVideo_VideosId",
                table: "ActorVideo",
                column: "VideosId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtTickets_ScreeningId",
                table: "BoughtTickets",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtTickets_UserId",
                table: "BoughtTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVideo_VideosId",
                table: "CategoryVideo",
                column: "VideosId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VideoId",
                table: "Ratings",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_VideoId",
                table: "Screenings",
                column: "VideoId");

            string getTop10MoviesWithMostRatings = @"CREATE PROCEDURE getTop10MoviesWithMostRatings
                                                     AS
                                                     BEGIN
	                                                    SELECT TOP(10) v.Id as MovieId, v.Title as MovieName, COUNT(r.Value) AS NumberOfRatings, AVG(r.Value) AS AverageRating
	                                                    FROM videos v, ratings r
	                                                    WHERE v.Id = r.VideoId AND TYPE = 0
	                                                    GROUP BY v.Id, v.Title
	                                                    ORDER BY COUNT(r.Value) DESC, AVG(r.Value) DESC
                                                     END;";

            string getTop10MoviesWithMostScreenings = @"CREATE PROCEDURE getTop10MoviesWithMostScreenings
                                                        @start_date Date,
                                                        @end_date Date
                                                        AS
                                                        BEGIN
	                                                        SELECT TOP(10) v.Id as MovieId, v.Title as MovieName, COUNT(s.Id) AS NumberOfScreenings
	                                                        FROM Videos v, Screenings s
	                                                        WHERE v.Id = s.VideoId AND v.TYPE = 0 
	                                                        AND @start_date <= DATEADD(MINUTE, s.Duration, s.ScreeningDate) 
	                                                        AND DATEADD(MINUTE, s.Duration, s.ScreeningDate) <= @end_date
	                                                        GROUP BY v.Id, v.Title
	                                                        ORDER BY COUNT(s.Id) DESC
                                                        END;";

            string getMoviesWithMostSoldTicketsNoRating = @"CREATE PROCEDURE getMoviesWithMostSoldTicketsNoRating
                                                            AS
                                                            BEGIN
	                                                            SELECT v.Id as MovieId, v.Title as MovieName, s.Name as ScreeningName, s.SoldTickets as SoldTickets
	                                                            FROM Videos v, Screenings s
	                                                            WHERE (SELECT COUNT(*) 
		                                                               FROM Ratings r 
		                                                               WHERE r.VideoId = v.Id) = 0 
	                                                            AND v.Id = s.VideoId
                                                                AND v.Type = 0
	                                                            ORDER BY s.SoldTickets DESC
                                                            END;";


            migrationBuilder.Sql(getTop10MoviesWithMostRatings);
            migrationBuilder.Sql(getTop10MoviesWithMostScreenings);
            migrationBuilder.Sql(getMoviesWithMostSoldTicketsNoRating);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorVideo");

            migrationBuilder.DropTable(
                name: "BoughtTickets");

            migrationBuilder.DropTable(
                name: "CategoryVideo");

            migrationBuilder.DropTable(
                name: "MostRatedMoviesReports");

            migrationBuilder.DropTable(
                name: "MoviesWithMostScreeningsReports");

            migrationBuilder.DropTable(
                name: "MoviesWithMostSoldTicketsReports");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");

            string getTop10MoviesWithMostRatings = @"DROP PROCEDURE getTop10MoviesWithMostRatings";
            string getTop10MoviesWithMostScreenings = @"DROP PROCEDURE getTop10MoviesWithMostScreenings";
            string getMoviesWithMostSoldTicketsNoRating = @"DROP PROCEDURE getMoviesWithMostSoldTicketsNoRating";

            migrationBuilder.Sql(getTop10MoviesWithMostRatings);
            migrationBuilder.Sql(getTop10MoviesWithMostScreenings);
            migrationBuilder.Sql(getMoviesWithMostSoldTicketsNoRating);
            
        }
    }
}
