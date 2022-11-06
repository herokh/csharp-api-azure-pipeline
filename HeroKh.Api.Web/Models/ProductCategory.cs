using HeroKh.Api.Web.Enums;

namespace HeroKh.Api.Web.Models
{
    public class ProductCategory : BaseEntity
    {
        public string? Name { get; set; }
        public EnumProductCategory Slug { get; set; }

        public ProductCategory()
        {
        }

        public ProductCategory(string name, EnumProductCategory slug)
        {
            Name = name;
            Slug = slug;
        }

        public static ProductCategory GetInstance(string name, EnumProductCategory slug)
        {
            return new ProductCategory(name, slug);
        }
    }
}
