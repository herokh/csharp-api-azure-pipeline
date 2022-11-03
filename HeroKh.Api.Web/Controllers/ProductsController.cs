using Microsoft.AspNetCore.Mvc;
using HeroKh.Api.Web.Repositories.Interfaces;
using AutoMapper;
using HeroKh.Api.Web.DTOs.Product;

namespace HeroKh.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ReadonlyProductDto>> GetProduct()
        {
            var products = await _unitOfWork.ProductRepository.GetAllIncludeRelationAsync();
            return _mapper.Map<IEnumerable<ReadonlyProductDto>>(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadonlyProductDto>> GetProduct(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ReadonlyProductDto>(product);
            return productDto;
        }
    }
}
