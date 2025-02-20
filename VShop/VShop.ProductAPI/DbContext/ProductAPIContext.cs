using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.ProductAPI_Context;

public class ProductAPIContext : DbContext
{
    public ProductAPIContext(DbContextOptions<ProductAPIContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    //FluentAPI

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Category

        mb.Entity<Category>().HasKey(c => c.Id);
        mb.Entity<Category>().Property(x=> x.Name).HasMaxLength(100).IsRequired();


        mb.Entity<Category>().HasMany(x => x.Products).WithOne(x=> x.Category).IsRequired().OnDelete(DeleteBehavior.Cascade);



        // Product
        mb.Entity<Category>().Property(x => x.Name).HasMaxLength(100).IsRequired();

        mb.Entity<Product>().Property(x=> x.ImageURL).HasMaxLength(255).IsRequired();

        mb.Entity<Product>().Property(x => x.Description).HasMaxLength(255).IsRequired();

        mb.Entity<Product>().Property(x => x.Price).HasPrecision(12,2);
    }

}
