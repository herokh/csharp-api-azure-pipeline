using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAddressAsync(string emailAddress);
    }
}
