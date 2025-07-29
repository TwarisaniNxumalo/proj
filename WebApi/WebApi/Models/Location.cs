namespace WebApi.Models
{
    public class Location
    {
        public required string Country { get; set; }
        public required string City { get; set; }
        public required Double Longitude { get; set; }
        public required Double Latitude { get; set; }
    }
}
