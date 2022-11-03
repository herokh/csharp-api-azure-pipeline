using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.Repositories.Interfaces;

namespace KhWebApi.WebApi.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ModelContext context) : base(context)
        {
        }
    }
}
