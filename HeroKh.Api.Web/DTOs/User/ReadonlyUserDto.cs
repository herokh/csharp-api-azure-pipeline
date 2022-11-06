namespace HeroKh.Api.Web.DTOs.User
{
    public class ReadonlyUserDto : UserDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
