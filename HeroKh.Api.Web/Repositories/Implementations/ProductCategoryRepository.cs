using HeroKh.Api.Web.Enums;
using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroKh.Api.Web.Repositories.Implementations
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
