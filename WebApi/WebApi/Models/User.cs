using System.Globalization;

namespace WebApi.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public required string Name { get; set; }
        public required  string Surname {  get; set; }
        public required string Email { get; set; }
        public required string Salt { get; set; }
        public required string PasswordHash { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdateAt { get; set; }
    }
}
