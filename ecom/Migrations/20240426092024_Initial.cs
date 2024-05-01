using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecom.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsTopTrader = table.Column<bool>(type: "bit", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingSum = table.Column<int>(type: "int", nullable: false),
                    FollowedProductIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    OfferCount = table.Column<int>(type: "int", nullable: false),
                    AuctionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsSeeded = table.Column<bool>(type: "bit", nullable: false),
                    IsHighlighted = table.Column<bool>(type: "bit", nullable: false),
                    IsAdvertised = table.Column<bool>(type: "bit", nullable: false),
                    HasExtraPictures = table.Column<bool>(type: "bit", nullable: false),
                    IsStartTimeAdjusted = table.Column<bool>(type: "bit", nullable: false),
                    IsEndTimeAdjusted = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    FollowerCount = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayName", "Keywords", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "Kolekcionarstvo", "kolekcije,kolekcija", "Kolekcionarstvo", "" },
                    { 2, "Numizmatika", "novac", "Numizmatika", "" },
                    { 3, "Antikviteti", "starine", "Antikviteti", "" },
                    { 4, "Umjetnost", "umjetnine", "Umjetnost", "" },
                    { 5, "Knjige i tisak", "", "Knjige-tisak", "" },
                    { 6, "Glazba i film", "", "Glazba-film", "" },
                    { 7, "Audio / video", "multimedija,av tehnika, audio video tehnika, audio i video tehnika,a/v tehnika", "Audio-video", "" },
                    { 8, "Računala i mobiteli", "", "Racunala-mobiteli", "" },
                    { 9, "Konzole i igrice", "igrice", "Konzole-igrice", "" },
                    { 10, "Odjeća i obuća", "", "Odjeca-obuca", "" },
                    { 11, "Nakit i satovi", "", "Nakit-satovi", "" },
                    { 12, "Modni dodaci", "accessories", "Modni-dodaci", "" },
                    { 13, "Ljepota i zdravlje", "", "Ljepota-zdravlje", "" },
                    { 14, "Sport i oprema", "sportska oprema", "Sport-oprema", "" },
                    { 15, "Dom i vrt", "za kuću,za kucu,za dom,kuća,stan,kuca", "Dom-vrt", "" },
                    { 16, "Igre i igračke", "igracke", "Igre-igracke", "" },
                    { 17, "Škola i posao", "", "Skola-posao", "" },
                    { 18, "Ostalo", "", "Ostalo", "Predmeti koji nemaju posebnu kategoriju." }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "DisplayName", "Keywords", "Name", "ParentCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Militarija", "", "Militarija", "Kolekcionarstvo" },
                    { 2, 1, "Filatelija", "", "Filatelija", "Kolekcionarstvo" },
                    { 3, 1, "Figurice", "figure", "Figurice", "Kolekcionarstvo" },
                    { 4, 1, "Sličice, karte i albumi", "slicice,kartice,igraće karte,igrace karte", "Slicice-karte-albumi", "Kolekcionarstvo" },
                    { 5, 1, "Razglednice", "", "Razglednice", "Kolekcionarstvo" },
                    { 6, 1, "Modeli i makete", "modelarstvo,maketarstvo,autići,autici,modeli auta", "Modeli-makete", "Kolekcionarstvo" },
                    { 7, 1, "Suveniri", "", "Suveniri", "Kolekcionarstvo" },
                    { 8, 1, "Privjesci", "privesci,privjesci za ključeve,privjesci za kljuceve", "Privjesci", "Kolekcionarstvo" },
                    { 9, 1, "Ulaznice i karte", "", "Ulaznice-karte", "Kolekcionarstvo" },
                    { 10, 1, "Telefonske kartice", "", "Telefonske-kartice", "Kolekcionarstvo" },
                    { 11, 1, "Pehari i medalje", "trofeji,kolajne", "Pehari-medalje", "Kolekcionarstvo" },
                    { 12, 1, "Registracijske tablice", "registracije,registarske tablice", "Registracijske-tablice", "Kolekcionarstvo" },
                    { 13, 1, "Zastave", "zastavice", "Zastave", "Kolekcionarstvo" },
                    { 14, 1, "Salvete", "salvetice", "Salvete", "Kolekcionarstvo" },
                    { 15, 1, "Lotovi", "", "Lotovi", "Kolekcionarstvo" },
                    { 16, 1, "Ostalo - kolekcionarstvo", "", "Ostalo-kolekcionarstvo", "Kolekcionarstvo" },
                    { 17, 2, "Kovanice", "novčići,novcici", "Kovanice", "Numizmatika" },
                    { 18, 2, "Novčanice", "novcanice", "Novcanice", "Numizmatika" },
                    { 19, 2, "Bonovi", "", "Bonovi", "Numizmatika" },
                    { 20, 2, "Žetoni", "", "Zetoni", "Numizmatika" },
                    { 21, 2, "Ostalo - numizmatika", "", "Ostalo-numizmatika", "Numizmatika" },
                    { 22, 3, "Keramika, porculan i staklo", "", "Keramika-porculan-staklo", "Antikviteti" },
                    { 23, 3, "Stari namještaj", "starinski", "Stari-namjestaj", "Antikviteti" },
                    { 24, 3, "Stari uređaji i aparati", "", "Stari-uredaji-aparati", "Antikviteti" },
                    { 25, 3, "Stari pribor i oprema", "", "Stari-pribor-oprema", "Antikviteti" },
                    { 26, 3, "Stara odjeća i obuća", "", "Stara-odjeca-obuca", "Antikviteti" },
                    { 27, 3, "Stari nakit i satovi", "starinski nakit", "Stari-nakit-satovi", "Antikviteti" },
                    { 28, 3, "Stare knjige i dokumenti", "", "Stare-knjige-dokumenti", "Antikviteti" },
                    { 29, 3, "Ostalo - antikviteti", "", "Ostalo-antikviteti", "Antikviteti" },
                    { 30, 4, "Umjetničke slike", "", "Umjetnicke-slike", "Umjetnost" },
                    { 31, 4, "Fotografije", "", "Fotografije", "Umjetnost" },
                    { 32, 4, "Ikone", "", "Ikone", "Umjetnost" },
                    { 33, 4, "Skulpture", "", "Skulpture", "Umjetnost" },
                    { 34, 4, "Gobleni", "", "Gobleni", "Umjetnost" },
                    { 35, 4, "Ostalo - umjetnost", "", "Ostalo-umjetnost", "Umjetnost" },
                    { 36, 5, "Književnost", "", "Knjizevnost", "Knjige-tisak" },
                    { 37, 5, "Znanost i enciklopedije", "", "Znanost-enciklopedije", "Knjige-tisak" },
                    { 38, 5, "Atlasi i karte", "", "Atlasi-karte", "Knjige-tisak" },
                    { 39, 5, "Magazini i časopisi", "", "Magazini-casopisi", "Knjige-tisak" },
                    { 40, 5, "Stripovi", "", "Stripovi", "Knjige-tisak" },
                    { 41, 5, "Dječja literatura", "", "Djecja-literatura", "Knjige-tisak" },
                    { 42, 5, "Ostalo - tisak", "", "Ostalo-tisak", "Knjige-tisak" },
                    { 43, 6, "Glazbeni instrumenti", "muzički,instrumenti", "Glazbeni-instrumenti", "Glazba-film" },
                    { 44, 6, "CDovi", "", "CDovi", "Glazba-film" },
                    { 45, 6, "Audio kasete", "", "Audio-Kasete", "Glazba-film" },
                    { 46, 6, "Gramofonske ploče", "", "Gramofonske-ploce", "Glazba-film" },
                    { 47, 6, "DVD i BluRay", "", "DVD-BluRay", "Glazba-film" },
                    { 48, 6, "VHS", "", "VHS", "Glazba-film" },
                    { 49, 6, "Ostalo - glazba i film", "", "Ostalo-glazba-film", "Glazba-film" },
                    { 50, 7, "TV i oprema", "Televizori", "TV-oprema", "Audio-video" },
                    { 51, 7, "Fotoaparati i kamere", "", "Fotoaparati-kamere", "Audio-video" },
                    { 52, 7, "Dronovi", "", "Dronovi", "Audio-video" },
                    { 53, 7, "Radio i telefoni", "radioprijemnik,radioprijemnici", "Radio-telefoni", "Audio-video" },
                    { 54, 7, "Zvučnici i pojačala", "zvučnik,pojačalo", "Zvucnici-pojacala", "Audio-video" },
                    { 55, 7, "Linije i kasetofoni", "kazetofoni", "Linije-kasetofoni", "Audio-video" },
                    { 56, 7, "Kućna kina i DVD playeri", "kućno kino", "Kucno-kino-dvd-playeri", "Audio-video" },
                    { 57, 7, "MP3, walkmani, iPodi", "mp3 playeri", "MP3-walkman-ipod", "Audio-video" },
                    { 58, 7, "Ostalo - audio / video", "", "Ostalo-audio-video", "Audio-video" },
                    { 59, 8, "Desktop računala,pc,kompjuteri,kompjutori", "", "Desktop-racunala", "Racunala-mobiteli" },
                    { 60, 8, "Laptopi", "", "Laptopi", "Racunala-mobiteli" },
                    { 61, 8, "Računalna oprema", "kompjuterska oprema", "Racunalna-oprema", "Racunala-mobiteli" },
                    { 62, 8, "Mobiteli", "mobilni telefoni", "Mobiteli", "Racunala-mobiteli" },
                    { 63, 8, "Punjači i oprema za mobitele", "", "Punjaci-oprema-mobiteli", "Racunala-mobiteli" },
                    { 64, 8, "Pametni satovi", "", "Pametni-satovi", "Racunala-mobiteli" },
                    { 65, 8, "Tableti", "", "Tableti", "Racunala-mobiteli" },
                    { 66, 8, "Ostalo - računala i mobiteli", "", "Ostalo-racunala-mobiteli", "Racunala-mobiteli" },
                    { 67, 9, "Konzole", "konzola", "Konzole", "Konzole-igrice" },
                    { 68, 9, "Videoigre", "igrice,videoigrice", "Videoigre", "Konzole-igrice" },
                    { 69, 9, "Oprema i dodaci", "", "Oprema-dodaci-konzole", "Konzole-igrice" },
                    { 70, 10, "Ženska odjeća", "Odjeca za zene,Odjeća za žene", "Zenska-odjeca", "Odjeca-obuca" },
                    { 71, 10, "Ženska obuća", "Obuca za zene,", "Zenska-obuca", "Odjeca-obuca" },
                    { 72, 10, "Muška odjeća", "", "Muska-odjeca", "Odjeca-obuca" },
                    { 73, 10, "Muška obuća", "", "Muska-obuca", "Odjeca-obuca" },
                    { 74, 10, "Dječja odjeća i obuća", "odjeca za djecu,odjeća za djecu", "Djecja-odjeca-obuca", "Odjeca-obuca" },
                    { 75, 11, "Nakit", "", "Nakit", "Nakit-satovi" },
                    { 76, 11, "Ručni satovi", "", "Rucni-satovi", "Nakit-satovi" },
                    { 77, 11, "Zidni satovi", "", "Zidni-satovi", "Nakit-satovi" },
                    { 78, 11, "Broševi i bedževi", "", "Brosevi-bedzevi", "Nakit-satovi" },
                    { 79, 11, "Drago kamenje", "", "Drago-kamenje", "Nakit-satovi" },
                    { 80, 11, "Ostalo - nakit i satovi", "", "Ostalo-nakit-satovi", "Nakit-satovi" },
                    { 81, 12, "Torbice", "torbe,neseseri,tašne,tasne,tasnice,tašnice", "Torbice", "Modni-dodaci" },
                    { 82, 12, "Naočale", "", "Naocale", "Modni-dodaci" },
                    { 83, 12, "Kaiševi", "remenovi,remeni,remenje", "Kaisevi", "Modni-dodaci" },
                    { 84, 12, "Novčanici", "", "Novcanici", "Modni-dodaci" },
                    { 85, 12, "Ostalo - modni dodaci", "", "Ostalo-modni-dodaci", "Modni-dodaci" },
                    { 86, 13, "Kozmetika i šminka", "maskare,maskara,puderi,ruzevi,ruževi,karmini", "Kozmetika-sminka", "Ljepota-zdravlje" },
                    { 87, 13, "Njega kose i tijela", "samponi,šamponi,ulja,gelovi", "Njega-kose-tijela", "Ljepota-zdravlje" },
                    { 88, 13, "Parfemi", "mirisi", "Parfemi", "Ljepota-zdravlje" },
                    { 89, 13, "Zdravlje", "", "Zdravlje", "Ljepota-zdravlje" },
                    { 90, 13, "Ostalo - ljepota i zdravlje", "", "Ostalo-ljepota-zdravlje", "Ljepota-zdravlje" },
                    { 91, 14, "Sportska odjeća i obuća - žene", "", "Sportska-odjeca-obuca-zene", "Sport-oprema" },
                    { 92, 14, "Sportska odjeća i obuća - muški", "", "Sportska-odjeca-obuca-muski", "Sport-oprema" },
                    { 93, 14, "Sportovi s loptom", "", "Sportovi-s-loptom", "Sport-oprema" },
                    { 94, 14, "Vodeni sportovi", "", "Vodeni-sportovi", "Sport-oprema" },
                    { 95, 14, "Zimski sportovi", "", "Zimski-sportovi", "Sport-oprema" },
                    { 96, 14, "Fitness i trening", "", "Fitness-trening", "Sport-oprema" },
                    { 97, 14, "Lov i ribolov", "", "Lov-ribolov", "Sport-oprema" },
                    { 98, 14, "Bicikli, role, romobili", "bicikla", "Bicikli-role-romobili", "Sport-oprema" },
                    { 99, 14, "Posteri", "", "Posteri", "Sport-oprema" },
                    { 100, 14, "Ostalo - sport", "", "Ostalo-sport", "Sport-oprema" },
                    { 101, 15, "Namještaj", "", "Namjestaj", "Dom-vrt" },
                    { 102, 15, "Bijela tehnika", "", "Bijela-tehnika", "Dom-vrt" },
                    { 103, 15, "Alati i pribor", "", "Alati-pribor", "Dom-vrt" },
                    { 104, 15, "Rasvjeta i sigurnost", "", "Rasvjeta-sigurnost", "Dom-vrt" },
                    { 105, 15, "Sve za čišćenje", "", "Ciscenje", "Dom-vrt" },
                    { 106, 15, "Sve za vrt", "", "Vrt", "Dom-vrt" },
                    { 107, 15, "Ostalo - dom", "", "Ostalo-dom", "Dom-vrt" },
                    { 108, 16, "Akcijske figurice", "akcione figurice", "Akcijske-figurice", "Igre-igracke" },
                    { 109, 16, "Na baterije", "igračke na baterije,igracke na baterije", "Na-baterije", "Igre-igracke" },
                    { 110, 16, "Plišane igračke", "plišanci,plisane igracke", "Plisanci", "Igre-igracke" },
                    { 111, 16, "Lego i slaganje", "lego kockice,lego kocke", "Lego-slaganje", "Igre-igracke" },
                    { 112, 16, "Društvene igre", "", "Drustvene-igre", "Igre-igracke" },
                    { 113, 16, "Ostalo - igre i igračke", "", "Ostalo-igracke", "Igre-igracke" },
                    { 114, 17, "Školski pribor", "za školu,za skolu,skolski pribor", "Skolski-pribor", "Skola-posao" },
                    { 115, 17, "Uredski pribor", "za posao,za ured", "Uredski-pribor", "Skola-posao" },
                    { 116, 18, "Vozila i oprema", "auta,auti,automobili,motori,quadovi,kombiji,dzipovi,džipovi", "Vozila", "Ostalo" },
                    { 117, 18, "Sve za bebe", "", "Za-bebe", "Ostalo" },
                    { 118, 18, "Kućni ljubimci", "kucni,ljubimci,psi,mačke,macke", "Kucni-ljubimci", "Ostalo" },
                    { 119, 18, "Maske", "", "Maske", "Ostalo" },
                    { 120, 18, "Medicinska pomagala", "", "Medicinska-pomagala", "Ostalo" },
                    { 121, 18, "Mjernoregulacijski instrumenti", "", "Mjernoregulacijski-instrumenti", "Ostalo" },
                    { 122, 18, "Špijunska oprema", "", "Spijunska-oprema", "Ostalo" },
                    { 123, 18, "Oprema za pušače", "", "Oprema-pusaci", "Ostalo" },
                    { 124, 18, "Seksualna pomagala", "sex,porno", "Seksualna-pomagala", "Ostalo" },
                    { 125, 18, "Ostalo - nesvrstano", "", "Ostalo-nesvrstano", "Ostalo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
