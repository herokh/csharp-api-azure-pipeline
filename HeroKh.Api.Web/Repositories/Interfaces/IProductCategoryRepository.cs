using HeroKh.Api.Web.Enums;
using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Repositories.Interfaces
{
    public interface IProductCategoryRepository : IReadonlyRepository<ProductCategory>
    {
        Task<ProductCategory> GetBySlugAsync(EnumProductCategory slug);
    }
}
