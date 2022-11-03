using HeroKh.Api.Web.Models;

namespace HeroKh.Api.Web.Models
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
