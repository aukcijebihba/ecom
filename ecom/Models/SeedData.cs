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

        await context.SaveChangesAsync();
        var categorya = context.Categories.Where(c => c.Id == 1).First(); //kolekcionartstvo
        var categoryb = context.Categories.Where(c => c.Id == 2).First(); //numizmatika
        var categoryc = context.Categories.Where(c => c.Id == 3).First(); //antikviteti
        var subcategorya = context.SubCategories.Where(c => c.Id == 1).First(); //Militarija
        var subcategoryb = context.SubCategories.Where(c => c.Id == 2).First(); //Filatelija
        var subcategoryc = context.SubCategories.Where(c => c.Id == 18).First(); //novcanice?

        var products = new Product[]
        {
            new Product{Name="Kol / Militarija test 1",Description="",ImagesUrl="",Category=categorya,SubCategory=subcategorya,AuctionStart=DateTime.Today,AuctionEnd=new DateTime(2024, 05, 31)},
            new Product{Name="Kol / Filatelija test 1",Description="",ImagesUrl="",Category=categorya,SubCategory=subcategoryb,AuctionStart=DateTime.Today,AuctionEnd=new DateTime(2024, 05, 31)},
            new Product{Name="Num / Novcanice test 1",Description="",ImagesUrl="",Category=categoryb,SubCategory=subcategoryc,AuctionStart=DateTime.Today,AuctionEnd=new DateTime(2024, 05, 31)}
        };

        foreach(Product p in products)
        {
            context.Products.Add(p);
        }

        await context.SaveChangesAsync();

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
            UserName = "aukcije-bih@outlook.com",
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
