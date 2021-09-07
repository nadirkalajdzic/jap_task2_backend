using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jap_task2_backend.Migrations
{
    public partial class InitialMigrate : Migration
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
                    { 69, "Lorraine", "Bracco" },
                    { 68, "James", "Gandolfini" },
                    { 67, "Kit", "Harington" },
                    { 66, "Peter", "Dinklage" },
                    { 65, "Emilia", "Clarke" },
                    { 54, "Roger", "Horrocks" },
                    { 64, "Jonathan", "Fahn" },
                    { 62, "Carl", "Sagan" },
                    { 61, "Mae", "Whitman" },
                    { 60, "Zach", "Tyler" },
                    { 59, "Dee", "Bradley Baker" },
                    { 58, "Neil", "deGrasse Tyson" },
                    { 57, "Piotr", "Michael" },
                    { 63, "Jaromir", "Hanzlik" },
                    { 36, "Elliot", "Page" },
                    { 56, "Stoney", "Emshwiller" },
                    { 34, "Leonardo", "DiCaprio" },
                    { 14, "Martin", "Balsam" },
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
                    { 2, "Bob", "Gunton" },
                    { 35, "Joseph", "Gordon-Levitt" },
                    { 7, "Robert", "De Niro" },
                    { 17, "Ben", "Kingsley" },
                    { 15, "Liam", "Neeson" },
                    { 19, "Viggo", "Mortensen" },
                    { 33, "Gary", "Sinise" },
                    { 32, "Robin", "Wright" },
                    { 31, "Tom", "Hanks" },
                    { 30, "Meat", "Loaf" },
                    { 29, "Edward", "Norton" },
                    { 18, "Elijah", "Wood" },
                    { 27, "Orlando", "Bloom" },
                    { 26, "Lee", "Van Cleef" },
                    { 28, "Brad", "Pitt" },
                    { 24, "Clint", "Eastwood" },
                    { 23, "Samuel", "L. Jackson" },
                    { 22, "Uma", "Thurman" },
                    { 21, "John", "Travolta" },
                    { 20, "Ian", "McKellen" },
                    { 25, "Eli", "Wallach" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "BIOGRAPHY" },
                    { 14, "HISTORY" },
                    { 13, "DOCUMENTARY" },
                    { 12, "SCI-FI" },
                    { 15, "ANIMATION" },
                    { 11, "ROMANCE" },
                    { 9, "WESTERN" },
                    { 4, "DRAMA" },
                    { 7, "BIOGRAPHY" },
                    { 6, "CRIME" },
                    { 5, "TRAGEDY" },
                    { 3, "THRILLER" },
                    { 2, "COMEDY" },
                    { 1, "ACTION" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "ADVENTURE" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Hash", "Name", "Salt", "Surname" },
                values: new object[] { 1, "admin@gmail.com", new byte[] { 93, 207, 145, 137, 210, 98, 24, 181, 230, 14, 130, 171, 74, 194, 112, 248, 174, 175, 146, 154, 80, 121, 254, 24, 161, 121, 11, 61, 37, 172, 196, 130, 42, 97, 248, 143, 31, 212, 136, 242, 50, 164, 17, 135, 156, 169, 22, 249, 229, 151, 217, 102, 141, 241, 165, 174, 74, 207, 253, 209, 86, 90, 216, 236 }, "Admin", new byte[] { 73, 245, 31, 219, 82, 34, 53, 125, 147, 131, 106, 159, 181, 101, 19, 144, 125, 112, 182, 103, 47, 100, 36, 147, 126, 155, 33, 251, 8, 43, 13, 147, 77, 184, 72, 188, 141, 157, 70, 202, 175, 216, 192, 255, 217, 27, 126, 17, 38, 0, 64, 229, 211, 157, 50, 140, 144, 182, 71, 13, 228, 192, 250, 251, 176, 248, 243, 175, 180, 209, 35, 237, 213, 179, 23, 220, 7, 213, 237, 20, 97, 55, 115, 139, 9, 82, 107, 56, 196, 159, 206, 41, 17, 111, 226, 97, 181, 168, 182, 85, 43, 85, 56, 165, 55, 221, 244, 239, 86, 32, 190, 191, 180, 241, 35, 192, 76, 233, 84, 215, 175, 127, 33, 238, 216, 22, 237, 81 }, "Admin" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Description", "Image_Url", "ReleaseDate", "Title", "Type" },
                values: new object[,]
                {
                    { 15, "Emmy Award-winning, 11 episodes, five years in the making, the most expensive nature documentary series ever commissioned by the BBC, and the first to be filmed in high definition.", "https://m.media-amazon.com/images/I/91X9p6+58KL._SY445_.jpg", new DateTime(2010, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planet Earth", (short)1 },
                    { 16, "A high school chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine in order to secure his family's future.", "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ggFHVNu6YYI5L9pCfOacjizRGt.jpg", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breaking Bad", (short)1 },
                    { 17, "The story of Easy Company of the U.S. Army 101st Airborne Division and their mission in World War II Europe, from Operation Overlord to V-J Day.", "https://i.dailymail.co.uk/i/pix/2017/02/13/01/3D24EF6B00000578-4215748-image-a-63_1486948627611.jpg", new DateTime(2001, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Band of Brothers", (short)1 },
                    { 18, "In April 1986, an explosion at the Chernobyl nuclear power plant in the Union of Soviet Socialist Republics becomes one of the world's worst man-made catastrophes.", "https://i.redd.it/bv5isr69yr531.png", new DateTime(1986, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chernobyl", (short)1 },
                    { 22, "An exploration of our discovery of the laws of nature and coordinates in space and time.", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/5945/5945188_sa.jpg;maxHeight=640;maxWidth=550", new DateTime(2014, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmos: A Spacetime Odyssey", (short)1 },
                    { 20, "David Attenborough returns to the world's oceans in this sequel to the acclaimed documentary filming rare and unusual creatures of the deep, as well as documenting the problems our oceans face.", "https://cdn.shopify.com/s/files/1/0747/3829/products/mL1006_1024x1024.jpg?v=1571445246", new DateTime(2017, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Planet II", (short)1 },
                    { 21, "Documentary series focusing on the breadth of the diversity of habitats around the world, from the remote Arctic wilderness and mysterious deep oceans to the vast landscapes of Africa and diverse jungles of South America.", "https://www.penguin.co.uk/content/dam/prh/books/111/1115210/9780593079768.jpg.transform/PRHDesktopWide_small/image.jpg", new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Our Planet", (short)1 },
                    { 14, "Wildlife documentary series with David Attenborough, beginning with a look at the remote islands which offer sanctuary to some of the planet's rarest creatures, to the beauty of cities, which are home to humans, and animals..", "https://blackwells.co.uk/jacket/l/9781785943041.jpg", new DateTime(2016, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planet Earth II", (short)1 },
                    { 23, "In a war-torn world of elemental magic, a young boy reawakens to undertake a dangerous mystic quest to fulfill his destiny as the Avatar, and bring peace to the world.", "https://images-na.ssl-images-amazon.com/images/I/914eUC4XPML.jpg", new DateTime(2005, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar: The Last Airbender", (short)1 },
                    { 24, "Astronomer Carl Sagan leads us on an engaging guided tour of the various elements and cosmological theories of the universe.", "https://www.themoviedb.org/t/p/original/4WJ9kNejI8apl3f8hMNwo8V3hGT.jpg", new DateTime(1980, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmos", (short)1 },
                    { 19, "The Baltimore drug scene, as seen through the eyes of drug dealers and law enforcement.", "https://tvshows.today/wp-content/uploads/the-wire-season-1-poster.jpg", new DateTime(2008, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wire", (short)1 },
                    { 13, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "https://m.media-amazon.com/images/I/81p+xe8cbnL._SY445_.jpg", new DateTime(2010, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", (short)0 },
                    { 9, "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.", "https://upload.wikimedia.org/wikipedia/en/4/45/Good_the_bad_and_the_ugly_poster.jpg", new DateTime(1996, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Good, the Bad and the Ugly", (short)0 },
                    { 11, "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg", new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club", (short)0 },
                    { 10, "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", "https://images.moviesanywhere.com/198e228b071c60f5ad57e5f62fe60029/ff22cad6-2218-414d-b853-3f95d76905c7.jpg?h=375&resize=fit&w=250", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Fellowship of the Ring", (short)0 },
                    { 8, "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction", (short)0 },
                    { 7, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "https://img.discogs.com/MsgjJVAxVCXb1w86ffIbaNRr2BY=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-728620-1512923411-4779.jpeg.jpg", new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King", (short)0 },
                    { 6, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/c617e634647543.56d846b10d56f.jpg", new DateTime(1994, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List", (short)0 },
                    { 5, "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg", new DateTime(1957, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12 Angry Men", (short)0 },
                    { 4, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "https://upload.wikimedia.org/wikipedia/sh/8/83/Dark_knight_rises_poster.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", (short)0 },
                    { 3, "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "https://shotonwhat.com/images/0071562-med.jpg", new DateTime(1974, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather: Part II", (short)0 },
                    { 2, "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", "https://www.reelviews.net/resources/img/posters/thumbs/godfather_poster.jpg", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather", (short)0 },
                    { 1, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "https://swank.azureedge.net/swank/prod-film/3560cd8a-9491-4ab9-876c-8a8d6b84a6dd/f8e7c904-669a-4c9f-ac29-d19b64b43e33/one-sheet.jpg?width=335&height=508&mode=crop", new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption", (short)0 },
                    { 25, "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.", "https://m.media-amazon.com/images/M/MV5BYTRiNDQwYzAtMzVlZS00NTI5LWJjYjUtMzkwNTUzMWMxZTllXkEyXkFqcGdeQXVyNDIzMzcwNjc@._V1_FMjpg_UX1000_.jpg", new DateTime(2011, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game of Thrones", (short)1 },
                    { 12, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/37a5b434647543.56d846b10ca45.jpg", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump", (short)0 },
                    { 26, "New Jersey mob boss Tony Soprano deals with personal and professional issues in his home and business life that affect his mental state, leading him to seek professional psychiatric counseling.", "https://m.media-amazon.com/images/M/MV5BZGJjYzhjYTYtMDBjYy00OWU1LTg5OTYtNmYwOTZmZjE3ZDdhXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_FMjpg_UX1000_.jpg", new DateTime(1999, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sopranos", (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "UserId", "Value", "VideoId" },
                values: new object[,]
                {
                    { 1, 1, 4.6f, 1 },
                    { 24, 1, 4.1f, 24 },
                    { 23, 1, 4.1f, 23 },
                    { 22, 1, 4.1f, 22 },
                    { 21, 1, 4.2f, 21 },
                    { 20, 1, 4.3f, 20 },
                    { 19, 1, 4.4f, 19 },
                    { 18, 1, 4.5f, 18 },
                    { 17, 1, 4.6f, 17 },
                    { 16, 1, 4.6f, 16 },
                    { 15, 1, 4.6f, 15 },
                    { 14, 1, 4.7f, 14 },
                    { 13, 1, 4.1f, 13 },
                    { 12, 1, 4.1f, 12 },
                    { 11, 1, 4.2f, 11 },
                    { 10, 1, 4.2f, 10 },
                    { 9, 1, 4.2f, 9 },
                    { 8, 1, 4.2f, 8 },
                    { 7, 1, 4.3f, 7 },
                    { 6, 1, 4.35f, 6 },
                    { 5, 1, 4.4f, 5 },
                    { 4, 1, 4.5f, 4 },
                    { 3, 1, 4.5f, 3 },
                    { 2, 1, 4.5f, 2 },
                    { 25, 1, 4f, 25 },
                    { 26, 1, 3.9f, 26 }
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
                { 70, 26 }
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
                { 6,  26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorVideo_VideosId",
                table: "ActorVideo",
                column: "VideosId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorVideo");

            migrationBuilder.DropTable(
                name: "CategoryVideo");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
