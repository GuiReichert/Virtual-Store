using VShop.ProductAPI.DTO_s;

namespace VShop.ProductAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> CreateProduct (ProductDTO productDTO);
        Task<ProductDTO> UpdateProduct (ProductDTO productDTO);
        Task<ProductDTO> DeleteProduct (int id);
    }
}
