using AutoMapper;
using VShop.ProductAPI.DTO_s;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.Repositories;

namespace VShop.ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepo;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesWithProducts = await _categoryRepo.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesWithProducts);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepo.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async  Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            var categoryToCreate = _mapper.Map<Category>(categoryDTO);
            var response = await _categoryRepo.CreateCategory(categoryToCreate);
            return _mapper.Map<CategoryDTO>(response);
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryToUpdate = _mapper.Map<Category>(categoryDTO);
            var response = await _categoryRepo.UpdateCategory(categoryToUpdate);
            return _mapper.Map<CategoryDTO>(response);
        }

        public async Task<CategoryDTO> DeleteCategory(int id)
        {
            var response = await _categoryRepo.DeleteCategory(id);
            return _mapper.Map<CategoryDTO>(response);
        }



    }
}
