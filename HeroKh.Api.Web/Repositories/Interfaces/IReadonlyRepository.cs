using HeroKh.Api.Web.Models;
using System.Linq.Expressions;

namespace HeroKh.Api.Web.Repositories.Interfaces
{
    public interface IReadonlyRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<bool> ExistsAsync(Guid id);
    }
}
