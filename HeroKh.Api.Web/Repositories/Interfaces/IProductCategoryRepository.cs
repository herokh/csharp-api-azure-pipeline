using KhWebApi.WebApi.Enums;
using KhWebApi.WebApi.Models;

namespace KhWebApi.WebApi.Repositories.Interfaces
{
    public interface IProductCategoryRepository : IReadonlyRepository<ProductCategory>
    {
        Task<ProductCategory> GetBySlugAsync(EnumProductCategory slug);
    }
}
