using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class GenericRepository<T> : ReadonlyRepository<T>, IGenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(ModelContext context)
            : base(context)
        {
        }

        public async Task AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity != null)
                Context.Set<T>().Remove(entity);
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            var current = await GetByIdAsync(id);
            if (current == null)
                return;
            entity.Id = id;
            entity.CreatedDate = current.CreatedDate;

            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
