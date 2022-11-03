namespace HeroKh.Api.Web.Models
{
    public class User : BaseEntity
    {
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? DisplayName { get; set; }

        public User()
        {

        }

        public User(string? emailAddress, string? password, string? displayName)
        {
            EmailAddress = emailAddress;
            Password = password;
            DisplayName = displayName;
        }

        public static User GetInstance(string? emailAddress, string? password, string? displayName)
        {
            return new User(emailAddress, password, displayName);
        }
    }
}
