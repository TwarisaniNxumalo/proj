namespace WebApi.Model
{
    public class DianosticTest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Result { get; set; }
        public required DateTime Date { get; set; }

    }
}
