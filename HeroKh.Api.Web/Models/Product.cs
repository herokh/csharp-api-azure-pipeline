using System.ComponentModel.DataAnnotations.Schema;

namespace HeroKh.Api.Web.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public Guid ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory? ProductCategory { get; set; }

        public Product()
        {
        }

        public Product(string? name, string? description, decimal price, Guid productCategoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            ProductCategoryId = productCategoryId;
        }

        public static Product GetInstance(string? name, string? description, decimal price, Guid productCategoryId)
        {
            return new Product(name, description, price, productCategoryId);
        }
    }
}
