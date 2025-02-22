using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.ProductAPI_Context;

namespace VShop.ProductAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ProductAPIContext db;

        public CategoryRepository(ProductAPIContext db)
        {
            this.db = db;
        }



        public async Task<IEnumerable<Category>> GetAll()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            return await db.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categoryById = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryById == null)
            {
                throw new Exception("Could not find any Categories with this Id.");
            }
            return categoryById;
        }


        public async Task<Category> CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;                // 
            await db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var categoryToDelete = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryToDelete == null)
            {
                throw new Exception("Could not find any Categories with this Id.");
            }
            db.Remove(categoryToDelete);
            await db.SaveChangesAsync();
            return categoryToDelete;

        }



    }
}
