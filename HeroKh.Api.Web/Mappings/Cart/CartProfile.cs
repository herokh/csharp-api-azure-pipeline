using AutoMapper;
using HeroKh.Api.Web.DTOs.Cart;

namespace HeroKh.Api.Web.Mappings.Cart
{
    public class CartProfile: Profile
    {
        public CartProfile()
        {
            CreateMap<Models.Cart, CartDto>();
            CreateMap<Models.CartItem, ReadonlyCartItemDto>();
            CreateMap<CartItemDto, Models.CartItem>();
        }
    }
}
