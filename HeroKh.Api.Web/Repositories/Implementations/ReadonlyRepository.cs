using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class ReadonlyRepository<T> : IReadonlyRepository<T> where T : BaseEntity
    {
        protected readonly ModelContext Context;

        public ReadonlyRepository(ModelContext context)
        {
            Context = context;
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

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Context.Set<T>().AsNoTracking().AnyAsync(x => x.Id == id);
        }

    }
}
