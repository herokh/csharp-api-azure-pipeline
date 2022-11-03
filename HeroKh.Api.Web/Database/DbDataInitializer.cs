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

                await model.ProductCategory.AddAsync(new ProductCategory { Name = "Computer", Slug = EnumProductCategory.Computer });
                await model.ProductCategory.AddAsync(new ProductCategory { Name = "Mobile", Slug = EnumProductCategory.Mobile });

                await model.SaveChangesAsync();
            }
        }
    }
}
