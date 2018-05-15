namespace ProductsShop.Models.DTOs
{
    public class CategoryProductDto
    {
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
