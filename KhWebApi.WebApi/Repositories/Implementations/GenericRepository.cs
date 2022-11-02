using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KhWebApi.WebApi.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ModelContext Context;

        public GenericRepository(ModelContext context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Context.Set<T>().AsNoTracking().AnyAsync(x => x.Id == id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().AsNoTracking().Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
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
