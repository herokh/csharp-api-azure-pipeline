using HeroKh.Api.Web.Enums;

namespace HeroKh.Api.Web.Models
{
    public class ProductCategory : BaseEntity
    {
        public string? Name { get; set; }
        public EnumProductCategory Slug { get; set; }
    }
}
