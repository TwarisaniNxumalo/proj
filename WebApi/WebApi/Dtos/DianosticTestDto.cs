namespace WebApi.Dtos
{
    public class DianosticTestDto
    {
        public required string Name { get; set; }
        public required string Result { get; set; }
        public required DateTime Date { get; set; }
    }
}
