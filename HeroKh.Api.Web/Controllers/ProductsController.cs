using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using AutoMapper;
using HeroKh.Api.Web.DTOs.User;
using HeroKh.Api.Web.DTOs.Product;
using System.Security.Cryptography;
using HeroKh.Api.Web.Repositories.Implementations;
using HeroKh.Api.Web.Enums;

namespace HeroKh.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

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

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.UpdateAsync(id, product);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _unitOfWork.ProductRepository.ExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            var id = Guid.Empty;
            try
            {
                var productCategory = await _unitOfWork.ProductCategoryRepository.GetBySlugAsync(EnumConvertor.ToEnum<EnumProductCategory>(productDto.ProductCategorySlug));
                var product = _mapper.Map<Product>(productDto);
                if (productCategory != null)
                    product.ProductCategoryId = productCategory.Id;
                await _unitOfWork.ProductRepository.AddAsync(product);
                id = product.Id;
                await _unitOfWork.SaveChangesAsync();
                return CreatedAtAction("GetProduct", new { id = id });
            }
            catch (DbUpdateException)
            {
                if (await _unitOfWork.ProductRepository.ExistsAsync(id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (!await _unitOfWork.ProductRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
