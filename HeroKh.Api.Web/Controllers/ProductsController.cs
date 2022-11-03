using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using AutoMapper;
using HeroKh.Api.Web.DTOs.Product;
using HeroKh.Api.Web.Enums;
using Microsoft.AspNetCore.Authorization;

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
