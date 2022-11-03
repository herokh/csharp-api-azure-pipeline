using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ModelContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAddressAsync(string emailAddress)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Context.Set<User>().AsNoTracking().FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
