using KhWebApi.WebApi.Models;
using System.Linq.Expressions;

namespace KhWebApi.WebApi.Repositories.Interfaces
{
    public interface IReadonlyRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<bool> ExistsAsync(Guid id);
    }
}
