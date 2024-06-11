using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ecom.Models;
using ecom.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductContext") ?? throw new InvalidOperationException("Connection string 'ProductContext' not found.")));

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<Writer, IdentityRole<int>>(options => options.Stores.MaxLengthForKeys = 128 ) //options.SignIn.RequireConfirmedAccount = true
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ProductContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProductContext>();
    context.Database.Migrate();
    
    var config = app.Services.GetRequiredService<IConfiguration>();
    var testUserPw = config["SeedUserPW"];

    SeedData.InitializeAsync(context, services, "Placeholder1;").Wait();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");// The default HSTS value is 30 days. You may change this for production, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
