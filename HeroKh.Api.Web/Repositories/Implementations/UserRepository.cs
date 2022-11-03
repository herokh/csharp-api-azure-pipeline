using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ModelContext context) : base(context)
        {
        }
    }
}
