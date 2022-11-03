using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ModelContext context) : base(context)
        {
        }
    }
}
