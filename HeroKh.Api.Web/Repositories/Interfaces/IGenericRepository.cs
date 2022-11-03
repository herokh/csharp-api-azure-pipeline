using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Repositories.Interfaces
{
    public interface IGenericRepository<T> : IReadonlyRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task RemoveAsync(Guid id);
    }
}
