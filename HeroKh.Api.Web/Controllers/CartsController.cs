using Microsoft.AspNetCore.Mvc;
using HeroKh.Api.Web.Models;
using AutoMapper;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using HeroKh.Api.Web.DTOs.Cart;

namespace HeroKh.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<CartDto> GetCart()
        {
            var currentUser = await _unitOfWork.UserRepository.GetByEmailAddressAsync(User.Identity.Name);
            var cart = await _unitOfWork.CartRepository.GetCartIncludeCartItemsAsync(currentUser.Id);
            var cartDto = _mapper.Map<CartDto>(cart);
            if (cartDto != null)
                cartDto.TotalPrice = cartDto.CartItems.Sum(x => x.Product.Price * x.Quantity);
            return cartDto ?? new CartDto();
        }

        // POST: api/Carts/items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("items")]
        public async Task<ActionResult> PostCartItem(IEnumerable<CartItemDto> items)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByEmailAddressAsync(User.Identity.Name);
            var cartItems = _mapper.Map<IEnumerable<CartItem>>(items);
            var success = await _unitOfWork.CartRepository.AddCartItemAsync(currentUser.Id, cartItems);
            return success ? Ok() : BadRequest();
        }

        // DELETE: api/Carts
        [HttpDelete]
        public async Task<IActionResult> ClearUserCart()
        {
            var currentUser = await _unitOfWork.UserRepository.GetByEmailAddressAsync(User.Identity.Name);
            await _unitOfWork.CartRepository.ClearUserCartAsync(currentUser.Id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
