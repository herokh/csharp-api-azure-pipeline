using KhWebApi.WebApi.Models;

namespace KhWebApi.WebApi.Repositories.Interfaces
{
    public interface IGenericRepository<T> : IReadonlyRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task RemoveAsync(Guid id);
    }
}
