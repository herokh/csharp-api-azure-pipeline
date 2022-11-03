namespace KhWebApi.WebApi.DTOs.Product
{
    public class ProductDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ProductCategorySlug { get; set; }
    }
}
