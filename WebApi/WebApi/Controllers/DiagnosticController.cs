using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiagnosticTestController : ControllerBase
    {
        private static readonly List<DiagnosticTest> Tests = new();

        private readonly ILogger<DiagnosticTestController> _logger;

        public DiagnosticTestController(ILogger<DiagnosticTestController> logger)
        {
            _logger = logger;
        }

        // GET: /DiagnosticTest
        [HttpGet]
        public ActionResult<IEnumerable<DiagnosticTest>> GetAllTests()
        {
            return Ok(Tests);
        }

        // GET: /DiagnosticTest/{id}
        [HttpGet("{id}")]
        public ActionResult<DiagnosticTest> GetTestById(Guid id)
        {
            var test = Tests.FirstOrDefault(t => t.Id == id);
            if (test == null)
                return NotFound();

            return Ok(test);
        }

        // POST: /DiagnosticTest
        [HttpPost]
        public ActionResult<DiagnosticTest> CreateTest([FromBody] DiagnosticTest newTest)
        {
            newTest.Id = Guid.NewGuid();
            Tests.Add(newTest);

            return CreatedAtAction(nameof(GetTestById), new { id = newTest.Id }, newTest);
        }

        // PUT: /DiagnosticTest/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTest(Guid id, [FromBody] DiagnosticTest updatedTest)
        {
            var existingTest = Tests.FirstOrDefault(t => t.Id == id);
            if (existingTest == null)
                return NotFound();

            existingTest.Name = updatedTest.Name;
            existingTest.Result = updatedTest.Result;
            existingTest.Date = updatedTest.Date;

            return NoContent();
        }

        // DELETE: /DiagnosticTest/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTest(Guid id)
        {
            var test = Tests.FirstOrDefault(t => t.Id == id);
            if (test == null)
                return NotFound();

            Tests.Remove(test);
            return NoContent();
        }
    }
}
