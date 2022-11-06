using System.ComponentModel.DataAnnotations.Schema;

namespace HeroKh.Api.Web.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
