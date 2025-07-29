namespace WebApi.Model
{
    public class UserDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Salt { get; set; }
        public required string PasswordHash { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdateAt { get; set; }
    }
}
