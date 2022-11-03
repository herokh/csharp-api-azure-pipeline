using System.ComponentModel.DataAnnotations.Schema;

namespace HeroKh.Api.Web.Models
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public List<CartItem>? CartItems { get; set; }
    }
}
