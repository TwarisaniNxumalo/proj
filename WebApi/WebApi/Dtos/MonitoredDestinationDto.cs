using WebApi.Models;

namespace WebApi.Dtos
{
    public class MonitoredDestinationDto
    {
        public required Location Location { get; set; }
        public required int RiskLevel { get; set; }
        public required DateTime LastChecked { get; set; }
    }
}
