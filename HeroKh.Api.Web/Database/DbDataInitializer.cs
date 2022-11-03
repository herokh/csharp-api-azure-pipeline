using HeroKh.Api.Web.Enums;
using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Database
{
    public static class DbDataInitializer
    {
        public static async Task SeedDataAsync(ModelContext model)
        {
            using (model)
            {
                await model.Database.EnsureCreatedAsync();

                // users
                await model.Users.AddAsync(new User { EmailAddress = "test", DisplayName = "test", Password = "test" });

                // product categories
                await model.ProductCategory.AddAsync(new ProductCategory { Name = "Computer", Slug = EnumProductCategory.Computer });
                await model.ProductCategory.AddAsync(new ProductCategory { Name = "Mobile", Slug = EnumProductCategory.Mobile });

                await model.SaveChangesAsync();
            }
        }
    }
}
