using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HeroKh.Api.Web.Repositories.Implementations
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ModelContext context) : base(context)
        {
        }

        public async Task<bool> AddCartItemAsync(Guid userId, IEnumerable<CartItem> items)
        {
            var productIds = items.Select(x => x.ProductId).Distinct();
            var totalProducts = await Context.Set<Product>().AsNoTracking().CountAsync(x => productIds.Contains(x.Id));
            if (totalProducts != items.Count())
            {
                throw new Exception("Some of products not exist or invalid.");
            }

            var userCart = await Context.Set<Cart>().AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
            
            if (userCart != null)
            {
                await ClearUserCartAsync(userId);
                await Context.SaveChangesAsync();
            }

            using var transaction = Context.Database.BeginTransaction();

            try
            {
                userCart = new Cart();
                userCart.UserId = userId;
                await Context.Set<Cart>().AddAsync(userCart);
                await Context.SaveChangesAsync();

                foreach (var item in items)
                {
                    item.CartId = userCart.Id;
                    await Context.Set<CartItem>().AddAsync(item);
                }
                await Context.SaveChangesAsync();

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task ClearUserCartAsync(Guid userId)
        {
            var userCart = await GetCartIncludeCartItemsAsync(userId);
            Context.Set<Cart>().Remove(userCart);
        }

        public async Task<Cart> GetCartIncludeCartItemsAsync(Guid userId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Context.Set<Cart>().AsNoTracking()
                .Include(x => x.CartItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductCategory)
                .FirstOrDefaultAsync(x => x.UserId == userId);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
