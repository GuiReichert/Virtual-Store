using System.ComponentModel.DataAnnotations;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTO_s
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]

        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        [Range(1,9999)]
        public long Stock { get; set; }
        public string? ImageURL { get; set; }
        public Category? Category { get; set; }
    }
}
