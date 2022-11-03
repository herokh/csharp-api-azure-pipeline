using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllIncludeRelationAsync();
        Task<Product> GetByIdIncludeRelationAsync(Guid id);
    }
}
