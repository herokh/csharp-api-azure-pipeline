using HeroKh.Api.Web.DTOs.Product;

namespace HeroKh.Api.Web.DTOs.Cart
{
    public class ReadonlyCartItemDto : CartItemDto
    {
        public ReadonlyProductDto? Product { get; set; }
    }
}
