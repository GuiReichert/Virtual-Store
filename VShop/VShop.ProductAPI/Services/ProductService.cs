using AutoMapper;
using VShop.ProductAPI.DTO_s;
using VShop.ProductAPI.Models;
using VShop.ProductAPI.ProductAPI_Context;
using VShop.ProductAPI.Repositories;

namespace VShop.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepo;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepo = productRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepo.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productById = await _productRepo.GetProductById(id);
            return _mapper.Map<ProductDTO>(productById);
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            var productToCreate = _mapper.Map<Product>(productDTO);
            var response = await _productRepo.CreateProduct(productToCreate);
            return _mapper.Map<ProductDTO>(response);
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            var productToUpdate = _mapper.Map<Product>(productDTO);
            var response = await _productRepo.CreateProduct(productToUpdate);
            return _mapper.Map<ProductDTO>(response);
        }
        public async Task<ProductDTO> DeleteProduct(int id)
        {
            var response = await _productRepo.DeleteProduct(id);
            return _mapper.Map<ProductDTO>(response);
        }


    }
}
