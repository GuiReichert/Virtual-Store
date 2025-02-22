using AutoMapper;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTO_s.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();         //ReverseMap: makes the map both ways.
            CreateMap<Product,ProductDTO>().ReverseMap();
        }
    }
}
