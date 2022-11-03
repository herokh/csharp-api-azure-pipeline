using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ModelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllIncludeRelationAsync()
        {
            return await Context.Set<Product>().AsNoTracking().Include(x => x.ProductCategory).ToListAsync();
        }

        public async Task<Product> GetByIdIncludeRelationAsync(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Context.Set<Product>().AsNoTracking().Include(x => x.ProductCategory).FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
