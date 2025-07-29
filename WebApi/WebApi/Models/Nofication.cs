namespace WebApi.Model
{
    public class Nofication
    {
        public Guid Id { get; set; }
        public required string title { get; set; }
        public required DateTime timestamp { get; set; }
    }
}
