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
                var u1 = User.GetInstance("test", "test", "test");
                await model.Users.AddRangeAsync(u1);

                // product categories
                var cat1 = ProductCategory.GetInstance("Computer", EnumProductCategory.Computer);
                var cat2 = ProductCategory.GetInstance("Mobile", EnumProductCategory.Mobile);
                await model.ProductCategory.AddRangeAsync(cat1, cat2);

                // products
                var p1 = Product.GetInstance("Product 1", 
                    "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Culpa soluta labore sed qui totam facere minima dicta a reiciendis inventore!",
                    500.00m, cat1.Id);                
                var p2 = Product.GetInstance("Product 2", 
                    "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Culpa soluta labore sed qui totam facere minima dicta a reiciendis inventore!",
                    750.50m, cat1.Id);                
                var p3 = Product.GetInstance("Product 3", 
                    "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Culpa soluta labore sed qui totam facere minima dicta a reiciendis inventore!",
                    1500.75m, cat2.Id);
                await model.Products.AddRangeAsync(p1,p2,p3);

                await model.SaveChangesAsync();
            }
        }
    }
}
