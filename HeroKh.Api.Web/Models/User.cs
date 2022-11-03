namespace KhWebApi.WebApi.Models
{
    public class User : BaseEntity
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? DisplayName { get; set; }
    }
}
