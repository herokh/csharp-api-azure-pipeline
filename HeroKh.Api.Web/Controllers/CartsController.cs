using Microsoft.AspNetCore.Mvc;
using HeroKh.Api.Web.Models;
using AutoMapper;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IEnumerable<Cart>> GetCart()
        {
            return await _unitOfWork.CartRepository.GetAllAsync();
        }

        // PUT: api/Carts/items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("items/{id}")]
        public async Task<IActionResult> PutCartItem(Guid id, Cart cart)
        {

            return NoContent();
        }

        // POST: api/Carts/items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("items")]
        public async Task<ActionResult<Cart>> PostCartItem(Cart cart)
        {
            return NoContent();
        }

        // DELETE: api/Carts/items/5
        [HttpDelete("items/{id}")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {

            return NoContent();
        }
    }
}
