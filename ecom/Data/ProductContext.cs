using Microsoft.EntityFrameworkCore;
using ecom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace ecom.Data;
public class ProductContext : IdentityDbContext<Writer, IdentityRole<int>, int>
    {
        public ProductContext (DbContextOptions<ProductContext> options) : base(options){}
        public DbSet<Product> Products { get; set; } //= default!;
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
