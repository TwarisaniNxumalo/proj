using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitoredDestinationController : ControllerBase
    {
        private static readonly List<MonitoredDestination> Destinations = new();

        private readonly ILogger<MonitoredDestinationController> _logger;

        public MonitoredDestinationController(ILogger<MonitoredDestinationController> logger)
        {
            _logger = logger;
        }

        // GET: /MonitoredDestination
        [HttpGet]
        public ActionResult<IEnumerable<MonitoredDestination>> GetAll()
        {
            return Ok(Destinations);
        }

        // GET: /MonitoredDestination/{id}
        [HttpGet("{id}")]
        public ActionResult<MonitoredDestination> GetById(Guid id)
        {
            var destination = Destinations.FirstOrDefault(d => d.Id == id);
            if (destination == null)
                return NotFound();

            return Ok(destination);
        }

        // POST: /MonitoredDestination
        [HttpPost]
        public ActionResult<MonitoredDestination> Create([FromBody] MonitoredDestination newDestination)
        {
            newDestination.Id = Guid.NewGuid();
            Destinations.Add(newDestination);

            return CreatedAtAction(nameof(GetById), new { id = newDestination.Id }, newDestination);
        }

        // PUT: /MonitoredDestination/{id}
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] MonitoredDestination updatedDestination)
        {
            var existing = Destinations.FirstOrDefault(d => d.Id == id);
            if (existing == null)
                return NotFound();

            existing.Location = updatedDestination.Location;
            existing.RiskLevel = updatedDestination.RiskLevel;
            existing.LastChecked = updatedDestination.LastChecked;

            return NoContent();
        }

        // DELETE: /MonitoredDestination/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var destination = Destinations.FirstOrDefault(d => d.Id == id);
            if (destination == null)
                return NotFound();

            Destinations.Remove(destination);
            return NoContent();
        }
    }
}
