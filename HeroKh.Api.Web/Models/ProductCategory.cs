using KhWebApi.WebApi.Enums;

namespace KhWebApi.WebApi.Models
{
    public class ProductCategory : BaseEntity
    {
        public string? Name { get; set; }
        public EnumProductCategory Slug { get; set; }
    }
}
