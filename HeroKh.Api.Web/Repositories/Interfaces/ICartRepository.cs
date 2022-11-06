using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Repositories.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartIncludeCartItemsAsync(Guid userId);

        Task<bool> AddCartItemAsync(Guid userId, IEnumerable<CartItem> items);

        Task ClearUserCartAsync(Guid userId);
    }
}
