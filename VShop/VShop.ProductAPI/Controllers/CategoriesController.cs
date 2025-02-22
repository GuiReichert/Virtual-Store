using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductAPI.DTO_s;
using VShop.ProductAPI.Services;

namespace VShop.ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categoriesDTO = await _categoryService.GetAllCategories();
            if (categoriesDTO == null)
            {
                return NotFound("No categories found");
            }
            return Ok(categoriesDTO);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDTO = await _categoryService.GetCategoriesProducts();
            if (categoriesDTO == null)
            {
                return NotFound("No categories found.");
            }
            return Ok(categoriesDTO);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var categoryById = await _categoryService.GetCategoryById(id);
            if (categoryById == null)
            {
                return NotFound("Could not find a category with this Id.");
            }
            return Ok(categoryById);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Invalid data.");
            }
            var createdCategory = await _categoryService.CreateCategory(categoryDTO);
            return new CreatedAtRouteResult("GetCategoryById", new { id = createdCategory.Id},createdCategory);
        }


        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(CategoryDTO categoryDTO)
        {
            if(categoryDTO == null)
            {
                return BadRequest("Invalid Data.");
            }

           var categoryToUpdate = await _categoryService.GetCategoryById(categoryDTO.Id);
            if (categoryToUpdate == null)
            {
                return BadRequest("There is no current category with this Id.");
            }


            await _categoryService.UpdateCategory(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryService.GetCategoryById(id);
            if (categoryToDelete == null)
            {
                return NotFound("Could not find a category with this Id.");
            }
            await _categoryService.DeleteCategory(id);
            return Ok(categoryToDelete);

        }

    }
}
