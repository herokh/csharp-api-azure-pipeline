using KhWebApi.WebApi.Models;

namespace KhWebApi.WebApi.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllIncludeRelationAsync();
        Task<Product> GetByIdIncludeRelationAsync(Guid id);
    }
}
