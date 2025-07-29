namespace WebApi.Models
{
    public class MonitoredDestination
    {
        public Guid Id { get; set; }
        public required Location Location { get; set; }
        public required int RiskLevel { get; set; }
        public required DateTime LastChecked { get; set; }  

    }
}
