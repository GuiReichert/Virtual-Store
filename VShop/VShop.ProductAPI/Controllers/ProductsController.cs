using Microsoft.AspNetCore.Mvc;
using VShop.ProductAPI.DTO_s;
using VShop.ProductAPI.Services;

namespace VShop.ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            if (products == null)
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }

        [HttpGet("{id:int}",Name = "GetProductById")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Could not find a product with this Id.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDTO)
        {
            if(productDTO == null)
            {
                return BadRequest("Invalid Data.");
            }
            var createdProduct = await _productService.CreateProduct(productDTO);
            return new CreatedAtRouteResult("GetProductById", new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct (ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("Invalid Data.");
            }
            var productToUpdate = await _productService.GetProductById(productDTO.Id);
            if (productToUpdate == null)
            {
                return BadRequest("There is no current category with this Id.");
            }

            await _productService.UpdateProduct(productDTO);

            return Ok(productDTO);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
        {
            var productToDelete = await _productService.GetProductById(id);
            if (productToDelete == null)
            {
                return NotFound("Could not find a product with this Id.");
            }
            await _productService.DeleteProduct(id);
            return Ok(productToDelete);

        }


    }
}
