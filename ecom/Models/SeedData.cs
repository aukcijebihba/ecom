using Microsoft.EntityFrameworkCore;
using ecom.Data;
using Microsoft.AspNetCore.Identity;
namespace ecom.Models;

public static class SeedData
{
    public static async Task InitializeAsync(ProductContext context, IServiceProvider services, string Pw)
    {
        await context.Database.EnsureCreatedAsync();

        if (context.Writers.Any())
        {
            return;  
        }

        var writers = new Writer[]
        {
            new Writer{FirstName="Testko",LastName="Testković",DOB = new DateTime(2000, 1, 1), UserName = "milancinija@yahoo.com", Email = "milancinija@yahoo.com"} 
        };

        var categories = new Category[]
        {
            new Category{Name="Kolekcionarstvo",Keywords="kolekcije,kolekcija",DisplayName="Kolekcionarstvo",Note=""},
            new Category{Name="Numizmatika",Keywords="novac",DisplayName="Numizmatika",Note=""},
            new Category{Name="Antikviteti",Keywords="starine",DisplayName="Antikviteti",Note=""},
            new Category{Name="Umjetnost",Keywords="umjetnine",DisplayName="Umjetnost",Note=""},
            new Category{Name="Knjige-tisak",Keywords="",DisplayName="Knjige i tisak",Note=""},
            new Category{Name="Glazba-film",Keywords="",DisplayName="Glazba i film",Note=""},
            new Category{Name="Audio-video",Keywords="multimedija,av tehnika, audio video tehnika, audio i video tehnika,a/v tehnika",DisplayName="Audio / video",Note=""},
            new Category{Name="Racunala-mobiteli",Keywords="",DisplayName="Računala i mobiteli",Note=""},
            new Category{Name="Konzole-igrice",Keywords="igrice",DisplayName="Konzole i igrice",Note=""},
            new Category{Name="Odjeca-obuca",Keywords="",DisplayName="Odjeća i obuća",Note=""},
            new Category{Name="Nakit-satovi",Keywords="",DisplayName="Nakit i satovi",Note=""},
            new Category{Name="Modni-dodaci",Keywords="accessories",DisplayName="Modni dodaci",Note=""},
            new Category{Name="Ljepota-zdravlje",Keywords="",DisplayName="Ljepota i zdravlje",Note=""},
            new Category{Name="Sport-oprema",Keywords="sportska oprema",DisplayName="Sport i oprema",Note=""},
            new Category{Name="Dom-vrt",Keywords="za kuću,za kucu,za dom,kuća,stan,kuca",DisplayName="Dom i vrt",Note=""},
            new Category{Name="Igre-igracke",Keywords="igracke",DisplayName="Igre i igračke",Note=""},
            new Category{Name="Skola-posao",Keywords="",DisplayName="Škola i posao",Note=""},
            new Category{Name="Ostalo",Keywords="",DisplayName="Ostalo",Note="Predmeti koji nemaju posebnu kategoriju."}
        };

        var subcategories = new SubCategory[]
        {
            new SubCategory{Name="Militarija",Keywords="",DisplayName="Militarija",ParentCategoryName="Kolekcionarstvo"}, //filumenija, memorabilija?
            new SubCategory{Name="Filatelija",Keywords="",DisplayName="Filatelija",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Figurice",Keywords="figure",DisplayName="Figurice",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Slicice-karte-albumi",Keywords="slicice,kartice,igraće karte,igrace karte",DisplayName="Sličice, karte i albumi",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Razglednice",Keywords="",DisplayName="Razglednice",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Modeli-makete",Keywords="modelarstvo,maketarstvo,autići,autici,modeli auta",DisplayName="Modeli i makete",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Suveniri",Keywords="",DisplayName="Suveniri",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Privjesci",Keywords="privesci,privjesci za ključeve,privjesci za kljuceve",DisplayName="Privjesci",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Ulaznice-karte",Keywords="",DisplayName="Ulaznice i karte",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Telefonske-kartice",Keywords="",DisplayName="Telefonske kartice",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Pehari-medalje",Keywords="trofeji,kolajne",DisplayName="Pehari i medalje",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Registracijske-tablice",Keywords="registracije,registarske tablice",DisplayName="Registracijske tablice",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Zastave",Keywords="zastavice",DisplayName="Zastave",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Salvete",Keywords="salvetice",DisplayName="Salvete",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Lotovi",Keywords="",DisplayName="Lotovi",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Ostalo-kolekcionarstvo",Keywords="",DisplayName="Ostalo - kolekcionarstvo",ParentCategoryName="Kolekcionarstvo"},
            new SubCategory{Name="Kovanice",Keywords="novčići,novcici",DisplayName="Kovanice",ParentCategoryName="Numizmatika"},
            new SubCategory{Name="Novcanice",Keywords="novcanice",DisplayName="Novčanice",ParentCategoryName="Numizmatika"},
            new SubCategory{Name="Bonovi",Keywords="",DisplayName="Bonovi",ParentCategoryName="Numizmatika"},
            new SubCategory{Name="Zetoni",Keywords="",DisplayName="Žetoni",ParentCategoryName="Numizmatika"},
            new SubCategory{Name="Ostalo-numizmatika",Keywords="",DisplayName="Ostalo - numizmatika",ParentCategoryName="Numizmatika"},
            new SubCategory{Name="Keramika-porculan-staklo",Keywords="",DisplayName="Keramika, porculan i staklo",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Stari-namjestaj",Keywords="starinski",DisplayName="Stari namještaj",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Stari-uredaji-aparati",Keywords="",DisplayName="Stari uređaji i aparati",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Stari-pribor-oprema",Keywords="",DisplayName="Stari pribor i oprema",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Stara-odjeca-obuca",Keywords="",DisplayName="Stara odjeća i obuća",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Stari-nakit-satovi",Keywords="starinski nakit",DisplayName="Stari nakit i satovi",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Stare-knjige-dokumenti",Keywords="",DisplayName="Stare knjige i dokumenti",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Ostalo-antikviteti",Keywords="",DisplayName="Ostalo - antikviteti",ParentCategoryName="Antikviteti"},
            new SubCategory{Name="Umjetnicke-slike",Keywords="",DisplayName="Umjetničke slike",ParentCategoryName="Umjetnost"},
            new SubCategory{Name="Fotografije",Keywords="",DisplayName="Fotografije",ParentCategoryName="Umjetnost"},
            new SubCategory{Name="Ikone",Keywords="",DisplayName="Ikone",ParentCategoryName="Umjetnost"},
            new SubCategory{Name="Skulpture",Keywords="",DisplayName="Skulpture",ParentCategoryName="Umjetnost"},
            new SubCategory{Name="Gobleni",Keywords="",DisplayName="Gobleni",ParentCategoryName="Umjetnost"},
            new SubCategory{Name="Ostalo-umjetnost",Keywords="",DisplayName="Ostalo - umjetnost",ParentCategoryName="Umjetnost"},
            new SubCategory{Name="Knjizevnost",Keywords="",DisplayName="Književnost",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Znanost-enciklopedije",Keywords="",DisplayName="Znanost i enciklopedije",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Atlasi-karte",Keywords="",DisplayName="Atlasi i karte",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Magazini-casopisi",Keywords="",DisplayName="Magazini i časopisi",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Stripovi",Keywords="",DisplayName="Stripovi",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Djecja-literatura",Keywords="",DisplayName="Dječja literatura",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Ostalo-tisak",Keywords="",DisplayName="Ostalo - tisak",ParentCategoryName="Knjige-tisak"},
            new SubCategory{Name="Glazbeni-instrumenti",Keywords="muzički,instrumenti",DisplayName="Glazbeni instrumenti",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="CDovi",Keywords="",DisplayName="CDovi",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="Audio-Kasete",Keywords="",DisplayName="Audio kasete",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="Gramofonske-ploce",Keywords="",DisplayName="Gramofonske ploče",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="DVD-BluRay",Keywords="",DisplayName="DVD i BluRay",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="VHS",Keywords="",DisplayName="VHS",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="Ostalo-glazba-film",Keywords="",DisplayName="Ostalo - glazba i film",ParentCategoryName="Glazba-film"},
            new SubCategory{Name="TV-oprema",Keywords="Televizori",DisplayName="TV i oprema",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Fotoaparati-kamere",Keywords="",DisplayName="Fotoaparati i kamere",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Dronovi",Keywords="",DisplayName="Dronovi",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Radio-telefoni",Keywords="radioprijemnik,radioprijemnici",DisplayName="Radio i telefoni",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Zvucnici-pojacala",Keywords="zvučnik,pojačalo",DisplayName="Zvučnici i pojačala",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Linije-kasetofoni",Keywords="kazetofoni",DisplayName="Linije i kasetofoni",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Kucno-kino-dvd-playeri",Keywords="kućno kino",DisplayName="Kućna kina i DVD playeri",ParentCategoryName="Audio-video"},
            new SubCategory{Name="MP3-walkman-ipod",Keywords="mp3 playeri",DisplayName="MP3, walkmani, iPodi",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Ostalo-audio-video",Keywords="",DisplayName="Ostalo - audio / video",ParentCategoryName="Audio-video"},
            new SubCategory{Name="Desktop-racunala",Keywords="",DisplayName="Desktop računala,pc,kompjuteri,kompjutori",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Laptopi",Keywords="",DisplayName="Laptopi",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Racunalna-oprema",Keywords="kompjuterska oprema",DisplayName="Računalna oprema",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Mobiteli",Keywords="mobilni telefoni",DisplayName="Mobiteli",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Punjaci-oprema-mobiteli",Keywords="",DisplayName="Punjači i oprema za mobitele",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Pametni-satovi",Keywords="",DisplayName="Pametni satovi",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Tableti",Keywords="",DisplayName="Tableti",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Ostalo-racunala-mobiteli",Keywords="",DisplayName="Ostalo - računala i mobiteli",ParentCategoryName="Racunala-mobiteli"},
            new SubCategory{Name="Konzole",Keywords="konzola",DisplayName="Konzole",ParentCategoryName="Konzole-igrice"},
            new SubCategory{Name="Videoigre",Keywords="igrice,videoigrice",DisplayName="Videoigre",ParentCategoryName="Konzole-igrice"},
            new SubCategory{Name="Oprema-dodaci-konzole",Keywords="",DisplayName="Oprema i dodaci",ParentCategoryName="Konzole-igrice"},
            new SubCategory{Name="Zenska-odjeca",Keywords="Odjeca za zene,Odjeća za žene",DisplayName="Ženska odjeća",ParentCategoryName="Odjeca-obuca"},
            new SubCategory{Name="Zenska-obuca",Keywords="Obuca za zene,",DisplayName="Ženska obuća",ParentCategoryName="Odjeca-obuca"},
            new SubCategory{Name="Muska-odjeca",Keywords="",DisplayName="Muška odjeća",ParentCategoryName="Odjeca-obuca"},
            new SubCategory{Name="Muska-obuca",Keywords="",DisplayName="Muška obuća",ParentCategoryName="Odjeca-obuca"},
            new SubCategory{Name="Djecja-odjeca-obuca",Keywords="odjeca za djecu,odjeća za djecu",DisplayName="Dječja odjeća i obuća",ParentCategoryName="Odjeca-obuca"},
            new SubCategory{Name="Nakit",Keywords="",DisplayName="Nakit",ParentCategoryName="Nakit-satovi"},
            new SubCategory{Name="Rucni-satovi",Keywords="",DisplayName="Ručni satovi",ParentCategoryName="Nakit-satovi"},
            new SubCategory{Name="Zidni-satovi",Keywords="",DisplayName="Zidni satovi",ParentCategoryName="Nakit-satovi"},
            new SubCategory{Name="Brosevi-bedzevi",Keywords="",DisplayName="Broševi i bedževi",ParentCategoryName="Nakit-satovi"},
            new SubCategory{Name="Drago-kamenje",Keywords="",DisplayName="Drago kamenje",ParentCategoryName="Nakit-satovi"},
            new SubCategory{Name="Ostalo-nakit-satovi",Keywords="",DisplayName="Ostalo - nakit i satovi",ParentCategoryName="Nakit-satovi"},
            new SubCategory{Name="Torbice",Keywords="torbe,neseseri,tašne,tasne,tasnice,tašnice",DisplayName="Torbice",ParentCategoryName="Modni-dodaci"},
            new SubCategory{Name="Naocale",Keywords="",DisplayName="Naočale",ParentCategoryName="Modni-dodaci"},
            new SubCategory{Name="Kaisevi",Keywords="remenovi,remeni,remenje",DisplayName="Kaiševi",ParentCategoryName="Modni-dodaci"},
            new SubCategory{Name="Novcanici",Keywords="",DisplayName="Novčanici",ParentCategoryName="Modni-dodaci"},
            new SubCategory{Name="Ostalo-modni-dodaci",Keywords="",DisplayName="Ostalo - modni dodaci",ParentCategoryName="Modni-dodaci"},
            new SubCategory{Name="Kozmetika-sminka",Keywords="maskare,maskara,puderi,ruzevi,ruževi,karmini",DisplayName="Kozmetika i šminka",ParentCategoryName="Ljepota-zdravlje"},
            new SubCategory{Name="Njega-kose-tijela",Keywords="samponi,šamponi,ulja,gelovi",DisplayName="Njega kose i tijela",ParentCategoryName="Ljepota-zdravlje"},
            new SubCategory{Name="Parfemi",Keywords="mirisi",DisplayName="Parfemi",ParentCategoryName="Ljepota-zdravlje"},
            new SubCategory{Name="Zdravlje",Keywords="",DisplayName="Zdravlje",ParentCategoryName="Ljepota-zdravlje"},
            new SubCategory{Name="Ostalo-ljepota-zdravlje",Keywords="",DisplayName="Ostalo - ljepota i zdravlje",ParentCategoryName="Ljepota-zdravlje"},
            new SubCategory{Name="Sportska-odjeca-obuca-zene",Keywords="",DisplayName="Sportska odjeća i obuća - žene",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Sportska-odjeca-obuca-muski",Keywords="",DisplayName="Sportska odjeća i obuća - muški",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Sportovi-s-loptom",Keywords="",DisplayName="Sportovi s loptom",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Vodeni-sportovi",Keywords="",DisplayName="Vodeni sportovi",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Zimski-sportovi",Keywords="",DisplayName="Zimski sportovi",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Fitness-trening",Keywords="",DisplayName="Fitness i trening",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Lov-ribolov",Keywords="",DisplayName="Lov i ribolov",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Bicikli-role-romobili",Keywords="bicikla",DisplayName="Bicikli, role, romobili",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Posteri",Keywords="",DisplayName="Posteri",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Ostalo-sport",Keywords="",DisplayName="Ostalo - sport",ParentCategoryName="Sport-oprema"},
            new SubCategory{Name="Namjestaj",Keywords="",DisplayName="Namještaj",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Bijela-tehnika",Keywords="",DisplayName="Bijela tehnika",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Alati-pribor",Keywords="",DisplayName="Alati i pribor",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Rasvjeta-sigurnost",Keywords="",DisplayName="Rasvjeta i sigurnost",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Ciscenje",Keywords="",DisplayName="Sve za čišćenje",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Vrt",Keywords="",DisplayName="Sve za vrt",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Ostalo-dom",Keywords="",DisplayName="Ostalo - dom",ParentCategoryName="Dom-vrt"},
            new SubCategory{Name="Akcijske-figurice",Keywords="akcione figurice",DisplayName="Akcijske figurice",ParentCategoryName="Igre-igracke"},
            new SubCategory{Name="Na-baterije",Keywords="igračke na baterije,igracke na baterije",DisplayName="Na baterije",ParentCategoryName="Igre-igracke"},
            new SubCategory{Name="Plisanci",Keywords="plišanci,plisane igracke",DisplayName="Plišane igračke",ParentCategoryName="Igre-igracke"},
            new SubCategory{Name="Lego-slaganje",Keywords="lego kockice,lego kocke",DisplayName="Lego i slaganje",ParentCategoryName="Igre-igracke"},
            new SubCategory{Name="Drustvene-igre",Keywords="",DisplayName="Društvene igre",ParentCategoryName="Igre-igracke"},
            new SubCategory{Name="Ostalo-igracke",Keywords="",DisplayName="Ostalo - igre i igračke",ParentCategoryName="Igre-igracke"},
            new SubCategory{Name="Skolski-pribor",Keywords="za školu,za skolu,skolski pribor",DisplayName="Školski pribor",ParentCategoryName="Skola-posao"},
            new SubCategory{Name="Uredski-pribor",Keywords="za posao,za ured",DisplayName="Uredski pribor",ParentCategoryName="Skola-posao"},
            new SubCategory{Name="Vozila",Keywords="auta,auti,automobili,motori,quadovi,kombiji,dzipovi,džipovi",DisplayName="Vozila i oprema",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Za-bebe",Keywords="",DisplayName="Sve za bebe",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Kucni-ljubimci",Keywords="kucni,ljubimci,psi,mačke,macke",DisplayName="Kućni ljubimci",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Maske",Keywords="",DisplayName="Maske",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Medicinska-pomagala",Keywords="",DisplayName="Medicinska pomagala",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Mjernoregulacijski-instrumenti",Keywords="",DisplayName="Mjernoregulacijski instrumenti",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Spijunska-oprema",Keywords="",DisplayName="Špijunska oprema",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Oprema-pusaci",Keywords="",DisplayName="Oprema za pušače",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Seksualna-pomagala",Keywords="sex,porno",DisplayName="Seksualna pomagala",ParentCategoryName="Ostalo"},
            new SubCategory{Name="Ostalo-nesvrstano",Keywords="",DisplayName="Ostalo - nesvrstano",ParentCategoryName="Ostalo"}
        };

        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
        await EnsureRoleAsync(roleManager, "Manager");

        foreach (Writer w in writers)
        {
            var userManager = services.GetRequiredService<UserManager<Writer>>();
            string pass = w.FirstName + "321;"; //Testko321; username = testamentzz123

            w.IsAdmin = false;
            w.EmailConfirmed = true;
            w.PhoneNumberConfirmed = true;
            w.PhoneNumber = "+385976248769";
            w.RatingCount = 0;
            w.RatingSum = 0;
            w.IsTopTrader = false;
            w.Balance = 0.0;
            w.MemberSince = DateTime.Today;
            context.Writers.Add(w);

            await userManager.CreateAsync(w, pass);
            await userManager.AddToRoleAsync(w, "Manager");
        }

        foreach(Category c in categories)
        {
            context.Categories.Add(c);
        }
        foreach(SubCategory s in subcategories)
        {
            context.SubCategories.Add(s);
        }
        

        context.SaveChanges();
        var categorya = context.Categories.Where(c => c.Id == 1).First(); //kolekcionartstvo
        var categoryb = context.Categories.Where(c => c.Id == 2).First(); //numizmatika
        var categoryc = context.Categories.Where(c => c.Id == 3).First(); //antikviteti
        var subcategorya = context.SubCategories.Where(c => c.Id == 1).First(); //Militarija
        var subcategoryb = context.SubCategories.Where(c => c.Id == 2).First(); //Filatelija
        var subcategoryc = context.SubCategories.Where(c => c.Id == 18).First(); //novcanice?

        var products = new Product[]
        {
            new Product{Name="Kol / Militarija test 1",Description="",ImagesUrl="",Category=categorya,SubCategory=subcategorya,AuctionStart=DateTime.Today,AuctionEnd=new DateTime(2024, 03, 31)},
            new Product{Name="Kol / Filatelija test 1",Description="",ImagesUrl="",Category=categorya,SubCategory=subcategoryb,AuctionStart=DateTime.Today,AuctionEnd=new DateTime(2024, 03, 31)},
            new Product{Name="Num / Novcanice test 1",Description="",ImagesUrl="",Category=categoryb,SubCategory=subcategoryc,AuctionStart=DateTime.Today,AuctionEnd=new DateTime(2024, 03, 31)}
        };

        foreach(Product p in products)
        {
            context.Products.Add(p);
        }

        context.SaveChanges();

        var roleAdmin = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
        await EnsureRoleAsync(roleAdmin, "Administrator");

        var userAdmin = services.GetRequiredService<UserManager<Writer>>();
        await EnsureAdminAsync(userAdmin, Pw);
    }

    private static async Task EnsureRoleAsync(RoleManager<IdentityRole<int>> roleManager, string role)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(role);
            if(alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole<int>(role));
        }

    private static async Task EnsureAdminAsync(UserManager<Writer> userManager, string userPw)
    {
        var testAdmin = await userManager.Users
            .Where(x => x.UserName == "stecajnikadmin")
            .SingleOrDefaultAsync();

        if(testAdmin != null) return;

        testAdmin = new Writer
        {
            UserName = "stecajnikadmin",
            Email = "aukcije-bih@outlook.com",  
            LastName = "Stecajnik",
            FirstName = "Admin",
            IsAdmin = true,
            DOB = new DateTime(1990, 1, 1) 
        };
        
        await userManager.CreateAsync(testAdmin, userPw);
        await userManager.AddToRoleAsync(testAdmin, "Administrator");
    }
}
