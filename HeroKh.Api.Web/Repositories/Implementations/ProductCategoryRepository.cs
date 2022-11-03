using KhWebApi.WebApi.Enums;
using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KhWebApi.WebApi.Repositories.Implementations
{
    public class ProductCategoryRepository : ReadonlyRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ModelContext context) : base(context)
        {
        }

        public async Task<ProductCategory> GetBySlugAsync(EnumProductCategory slug)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Context.Set<ProductCategory>().AsNoTracking().FirstOrDefaultAsync(x => x.Slug == slug);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
