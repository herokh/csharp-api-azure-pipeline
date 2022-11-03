using System.ComponentModel.DataAnnotations.Schema;

namespace HeroKh.Api.Web.Models
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }
    }
}
