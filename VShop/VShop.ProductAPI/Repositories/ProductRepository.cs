using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.ProductAPI_Context;

namespace VShop.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductAPIContext db;


        public ProductRepository(ProductAPIContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var productById = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (productById == null)
            {
                throw new Exception("Could not find any Products with this Id.");
            }
            return productById;

        }

        public async Task<Product> CreateProduct(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var productToDelete = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(productToDelete == null)
            {
                throw new Exception("Could not find any Products with this Id.");
            }
            db.Products.Remove(productToDelete);
            await db.SaveChangesAsync();
            return productToDelete;
        }



    }
}
