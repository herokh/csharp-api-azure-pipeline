namespace HeroKh.Api.Web.DTOs.Cart
{
    public class CartDto
    {
        public IEnumerable<ReadonlyCartItemDto>? CartItems { get; set; } = new List<ReadonlyCartItemDto>();     
        public decimal TotalPrice { get; set; }
    }
}
