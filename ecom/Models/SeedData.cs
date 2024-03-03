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
            new Category{Name="Kolekcionarstvo",Keywords="kolekcije,kolekcija",Note=""},
            new Category{Name="Numizmatika",Keywords="",Note=""},
            new Category{Name="Antikviteti",Keywords="",Note=""},
            new Category{Name="Umjetnost",Keywords="",Note=""},
            new Category{Name="Knjige i tisak",Keywords="",Note=""},
            new Category{Name="Glazba i film",Keywords="",Note=""},
            new Category{Name="Audio / video",Keywords="multimedija,av tehnika, audio video tehnika, audio i video tehnika,a/v tehnika",Note=""},
            new Category{Name="Računala i mobiteli",Keywords="",Note=""},
            new Category{Name="Konzole i igrice",Keywords="igrice",Note=""},
            new Category{Name="Odjeća i obuća",Keywords="",Note=""},
            new Category{Name="Modni dodaci",Keywords="",Note=""},
            new Category{Name="Nakit i satovi",Keywords="",Note=""},
            new Category{Name="Ljepota i zdravlje",Keywords="",Note=""},
            new Category{Name="Dom i vrt",Keywords="za kuću,za kucu,za dom",Note=""},
            new Category{Name="Sport i oprema",Keywords="sportska oprema",Note=""},
            new Category{Name="Igre i igračke",Keywords="igracke",Note=""},
            new Category{Name="Škola i posao",Keywords="",Note=""},
            new Category{Name="Ostalo",Keywords="",Note="Predmeti koji nemaju posebnu kategoriju."}
        };

        var subcategories = new SubCategory[]
        {
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1},
            new SubCategory{Name="Militarija",Keywords="",ParentCategoryId=1}
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
