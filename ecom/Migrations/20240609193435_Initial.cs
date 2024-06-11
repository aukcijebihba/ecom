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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    ProdGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferCount = table.Column<int>(type: "int", nullable: false),
                    AuctionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    ImagesUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Products_AspNetUsers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "CategoryId", "Keywords", "Name", "ParentCategoryName", "RouteName" },
                values: new object[,]
                {
                    { 1, 1, "", "Militarija", "Kolekcionarstvo", "Militarija" },
                    { 2, 1, "", "Filatelija", "Kolekcionarstvo", "Filatelija" },
                    { 3, 1, "figure", "Figurice", "Kolekcionarstvo", "Figurice" },
                    { 4, 1, "slicice,kartice,igraće karte,igrace karte", "Sličice, karte i albumi", "Kolekcionarstvo", "Slicice-karte-albumi" },
                    { 5, 1, "", "Razglednice", "Kolekcionarstvo", "Razglednice" },
                    { 6, 1, "modelarstvo,maketarstvo,autići,autici,modeli auta", "Modeli i makete", "Kolekcionarstvo", "Modeli-makete" },
                    { 7, 1, "", "Suveniri", "Kolekcionarstvo", "Suveniri" },
                    { 8, 1, "privesci,privjesci za ključeve,privjesci za kljuceve", "Privjesci", "Kolekcionarstvo", "Privjesci" },
                    { 9, 1, "", "Ulaznice i karte", "Kolekcionarstvo", "Ulaznice-karte" },
                    { 10, 1, "", "Telefonske kartice", "Kolekcionarstvo", "Telefonske-kartice" },
                    { 11, 1, "trofeji,kolajne", "Pehari i medalje", "Kolekcionarstvo", "Pehari-medalje" },
                    { 12, 1, "registracije,registarske tablice", "Registracijske tablice", "Kolekcionarstvo", "Registracijske-tablice" },
                    { 13, 1, "zastavice", "Zastave", "Kolekcionarstvo", "Zastave" },
                    { 14, 1, "salvetice", "Salvete", "Kolekcionarstvo", "Salvete" },
                    { 15, 1, "", "Lotovi", "Kolekcionarstvo", "Lotovi" },
                    { 16, 1, "", "Ostalo - kolekcionarstvo", "Kolekcionarstvo", "Ostalo-kolekcionarstvo" },
                    { 17, 2, "novčići,novcici", "Kovanice", "Numizmatika", "Kovanice" },
                    { 18, 2, "novcanice", "Novčanice", "Numizmatika", "Novcanice" },
                    { 19, 2, "", "Bonovi", "Numizmatika", "Bonovi" },
                    { 20, 2, "", "Žetoni", "Numizmatika", "Zetoni" },
                    { 21, 2, "", "Ostalo - numizmatika", "Numizmatika", "Ostalo-numizmatika" },
                    { 22, 3, "", "Keramika, porculan i staklo", "Antikviteti", "Keramika-porculan-staklo" },
                    { 23, 3, "starinski", "Stari namještaj", "Antikviteti", "Stari-namjestaj" },
                    { 24, 3, "", "Stari uređaji i aparati", "Antikviteti", "Stari-uredaji-aparati" },
                    { 25, 3, "", "Stari pribor i oprema", "Antikviteti", "Stari-pribor-oprema" },
                    { 26, 3, "", "Stara odjeća i obuća", "Antikviteti", "Stara-odjeca-obuca" },
                    { 27, 3, "starinski nakit", "Stari nakit i satovi", "Antikviteti", "Stari-nakit-satovi" },
                    { 28, 3, "", "Stare knjige i dokumenti", "Antikviteti", "Stare-knjige-dokumenti" },
                    { 29, 3, "", "Ostalo - antikviteti", "Antikviteti", "Ostalo-antikviteti" },
                    { 30, 4, "", "Umjetničke slike", "Umjetnost", "Umjetnicke-slike" },
                    { 31, 4, "", "Fotografije", "Umjetnost", "Fotografije" },
                    { 32, 4, "", "Ikone", "Umjetnost", "Ikone" },
                    { 33, 4, "", "Skulpture", "Umjetnost", "Skulpture" },
                    { 34, 4, "", "Gobleni", "Umjetnost", "Gobleni" },
                    { 35, 4, "", "Ostalo - umjetnost", "Umjetnost", "Ostalo-umjetnost" },
                    { 36, 5, "", "Književnost", "Knjige-tisak", "Knjizevnost" },
                    { 37, 5, "", "Znanost i enciklopedije", "Knjige-tisak", "Znanost-enciklopedije" },
                    { 38, 5, "", "Atlasi i karte", "Knjige-tisak", "Atlasi-karte" },
                    { 39, 5, "", "Magazini i časopisi", "Knjige-tisak", "Magazini-casopisi" },
                    { 40, 5, "", "Stripovi", "Knjige-tisak", "Stripovi" },
                    { 41, 5, "", "Dječja literatura", "Knjige-tisak", "Djecja-literatura" },
                    { 42, 5, "", "Ostalo - tisak", "Knjige-tisak", "Ostalo-tisak" },
                    { 43, 6, "muzički,instrumenti", "Glazbeni instrumenti", "Glazba-film", "Glazbeni-instrumenti" },
                    { 44, 6, "", "CDovi", "Glazba-film", "CDovi" },
                    { 45, 6, "", "Audio kasete", "Glazba-film", "Audio-Kasete" },
                    { 46, 6, "", "Gramofonske ploče", "Glazba-film", "Gramofonske-ploce" },
                    { 47, 6, "", "DVD i BluRay", "Glazba-film", "DVD-BluRay" },
                    { 48, 6, "", "VHS", "Glazba-film", "VHS" },
                    { 49, 6, "", "Ostalo - glazba i film", "Glazba-film", "Ostalo-glazba-film" },
                    { 50, 7, "Televizori", "TV i oprema", "Audio-video", "TV-oprema" },
                    { 51, 7, "", "Fotoaparati i kamere", "Audio-video", "Fotoaparati-kamere" },
                    { 52, 7, "", "Dronovi", "Audio-video", "Dronovi" },
                    { 53, 7, "radioprijemnik,radioprijemnici", "Radio i telefoni", "Audio-video", "Radio-telefoni" },
                    { 54, 7, "zvučnik,pojačalo", "Zvučnici i pojačala", "Audio-video", "Zvucnici-pojacala" },
                    { 55, 7, "kazetofoni", "Linije i kasetofoni", "Audio-video", "Linije-kasetofoni" },
                    { 56, 7, "kućno kino", "Kućna kina i DVD playeri", "Audio-video", "Kucno-kino-dvd-playeri" },
                    { 57, 7, "mp3 playeri", "MP3, walkmani, iPodi", "Audio-video", "MP3-walkman-ipod" },
                    { 58, 7, "", "Ostalo - audio / video", "Audio-video", "Ostalo-audio-video" },
                    { 59, 8, "PC, kompjuteri, kompjutori", "Desktop računala", "Racunala-mobiteli", "Desktop-racunala" },
                    { 60, 8, "", "Laptopi", "Racunala-mobiteli", "Laptopi" },
                    { 61, 8, "kompjuterska oprema", "Računalna oprema", "Racunala-mobiteli", "Racunalna-oprema" },
                    { 62, 8, "mobilni telefoni", "Mobiteli", "Racunala-mobiteli", "Mobiteli" },
                    { 63, 8, "", "Punjači i oprema za mobitele", "Racunala-mobiteli", "Punjaci-oprema-mobiteli" },
                    { 64, 8, "", "Pametni satovi", "Racunala-mobiteli", "Pametni-satovi" },
                    { 65, 8, "", "Tableti", "Racunala-mobiteli", "Tableti" },
                    { 66, 8, "", "Ostalo - računala i mobiteli", "Racunala-mobiteli", "Ostalo-racunala-mobiteli" },
                    { 67, 9, "konzola", "Konzole", "Konzole-igrice", "Konzole" },
                    { 68, 9, "igrice,videoigrice", "Videoigre", "Konzole-igrice", "Videoigre" },
                    { 69, 9, "", "Oprema i dodaci", "Konzole-igrice", "Oprema-dodaci-konzole" },
                    { 70, 10, "Odjeca za zene,Odjeća za žene", "Ženska odjeća", "Odjeca-obuca", "Zenska-odjeca" },
                    { 71, 10, "Obuca za zene,", "Ženska obuća", "Odjeca-obuca", "Zenska-obuca" },
                    { 72, 10, "", "Muška odjeća", "Odjeca-obuca", "Muska-odjeca" },
                    { 73, 10, "", "Muška obuća", "Odjeca-obuca", "Muska-obuca" },
                    { 74, 10, "odjeca za djecu,odjeća za djecu", "Dječja odjeća i obuća", "Odjeca-obuca", "Djecja-odjeca-obuca" },
                    { 75, 11, "", "Nakit", "Nakit-satovi", "Nakit" },
                    { 76, 11, "", "Ručni satovi", "Nakit-satovi", "Rucni-satovi" },
                    { 77, 11, "", "Zidni satovi", "Nakit-satovi", "Zidni-satovi" },
                    { 78, 11, "", "Broševi i bedževi", "Nakit-satovi", "Brosevi-bedzevi" },
                    { 79, 11, "", "Drago kamenje", "Nakit-satovi", "Drago-kamenje" },
                    { 80, 11, "", "Ostalo - nakit i satovi", "Nakit-satovi", "Ostalo-nakit-satovi" },
                    { 81, 12, "torbe,neseseri,tašne,tasne,tasnice,tašnice", "Torbice", "Modni-dodaci", "Torbice" },
                    { 82, 12, "", "Naočale", "Modni-dodaci", "Naocale" },
                    { 83, 12, "remenovi,remeni,remenje", "Kaiševi", "Modni-dodaci", "Kaisevi" },
                    { 84, 12, "", "Novčanici", "Modni-dodaci", "Novcanici" },
                    { 85, 12, "", "Ostalo - modni dodaci", "Modni-dodaci", "Ostalo-modni-dodaci" },
                    { 86, 13, "maskare,maskara,puderi,ruzevi,ruževi,karmini", "Kozmetika i šminka", "Ljepota-zdravlje", "Kozmetika-sminka" },
                    { 87, 13, "samponi,šamponi,ulja,gelovi", "Njega kose i tijela", "Ljepota-zdravlje", "Njega-kose-tijela" },
                    { 88, 13, "mirisi", "Parfemi", "Ljepota-zdravlje", "Parfemi" },
                    { 89, 13, "", "Zdravlje", "Ljepota-zdravlje", "Zdravlje" },
                    { 90, 13, "", "Ostalo - ljepota i zdravlje", "Ljepota-zdravlje", "Ostalo-ljepota-zdravlje" },
                    { 91, 14, "", "Sportska odjeća i obuća - žene", "Sport-oprema", "Sportska-odjeca-obuca-zene" },
                    { 92, 14, "", "Sportska odjeća i obuća - muški", "Sport-oprema", "Sportska-odjeca-obuca-muski" },
                    { 93, 14, "", "Sportovi s loptom", "Sport-oprema", "Sportovi-s-loptom" },
                    { 94, 14, "", "Vodeni sportovi", "Sport-oprema", "Vodeni-sportovi" },
                    { 95, 14, "", "Zimski sportovi", "Sport-oprema", "Zimski-sportovi" },
                    { 96, 14, "", "Fitness i trening", "Sport-oprema", "Fitness-trening" },
                    { 97, 14, "", "Lov i ribolov", "Sport-oprema", "Lov-ribolov" },
                    { 98, 14, "bicikla", "Bicikli, role, romobili", "Sport-oprema", "Bicikli-role-romobili" },
                    { 99, 14, "", "Posteri", "Sport-oprema", "Posteri" },
                    { 100, 14, "", "Ostalo - sport", "Sport-oprema", "Ostalo-sport" },
                    { 101, 15, "", "Namještaj", "Dom-vrt", "Namjestaj" },
                    { 102, 15, "", "Bijela tehnika", "Dom-vrt", "Bijela-tehnika" },
                    { 103, 15, "", "Alati i pribor", "Dom-vrt", "Alati-pribor" },
                    { 104, 15, "", "Rasvjeta i sigurnost", "Dom-vrt", "Rasvjeta-sigurnost" },
                    { 105, 15, "", "Sve za čišćenje", "Dom-vrt", "Ciscenje" },
                    { 106, 15, "", "Sve za vrt", "Dom-vrt", "Vrt" },
                    { 107, 15, "", "Ostalo - dom", "Dom-vrt", "Ostalo-dom" },
                    { 108, 16, "akcione figurice", "Akcijske figurice", "Igre-igracke", "Akcijske-figurice" },
                    { 109, 16, "igračke na baterije,igracke na baterije", "Na baterije", "Igre-igracke", "Na-baterije" },
                    { 110, 16, "plišanci,plisane igracke", "Plišane igračke", "Igre-igracke", "Plisanci" },
                    { 111, 16, "lego kockice,lego kocke", "Lego i slaganje", "Igre-igracke", "Lego-slaganje" },
                    { 112, 16, "", "Društvene igre", "Igre-igracke", "Drustvene-igre" },
                    { 113, 16, "", "Ostalo - igre i igračke", "Igre-igracke", "Ostalo-igracke" },
                    { 114, 17, "za školu,za skolu,skolski pribor", "Školski pribor", "Skola-posao", "Skolski-pribor" },
                    { 115, 17, "za posao,za ured", "Uredski pribor", "Skola-posao", "Uredski-pribor" },
                    { 116, 18, "auta,auti,automobili,motori,quadovi,kombiji,dzipovi,džipovi", "Vozila i oprema", "Ostalo", "Vozila" },
                    { 117, 18, "", "Sve za bebe", "Ostalo", "Za-bebe" },
                    { 118, 18, "kucni,ljubimci,psi,mačke,macke", "Kućni ljubimci", "Ostalo", "Kucni-ljubimci" },
                    { 119, 18, "", "Maske", "Ostalo", "Maske" },
                    { 120, 18, "", "Medicinska pomagala", "Ostalo", "Medicinska-pomagala" },
                    { 121, 18, "", "Mjernoregulacijski instrumenti", "Ostalo", "Mjernoregulacijski-instrumenti" },
                    { 122, 18, "", "Špijunska oprema", "Ostalo", "Spijunska-oprema" },
                    { 123, 18, "", "Oprema za pušače", "Ostalo", "Oprema-pusaci" },
                    { 124, 18, "sex,porno", "Seksualna pomagala", "Ostalo", "Seksualna-pomagala" },
                    { 125, 18, "", "Ostalo - nesvrstano", "Ostalo", "Ostalo-nesvrstano" }
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
                name: "IX_Products_WriterId",
                table: "Products",
                column: "WriterId");

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
