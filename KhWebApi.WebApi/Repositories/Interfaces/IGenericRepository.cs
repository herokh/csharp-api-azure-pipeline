using System.Linq.Expressions;

namespace KhWebApi.WebApi.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task RemoveAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
