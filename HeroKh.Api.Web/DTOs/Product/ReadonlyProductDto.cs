namespace HeroKh.Api.Web.DTOs.Product
{
    public class ReadonlyProductDto : ProductDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}
