using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.ProductAPI_Context;

public class ProductAPI_Context : DbContext
{
    public ProductAPI_Context(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


}
