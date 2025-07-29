using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private static readonly List<Notification> Notifications = new();

        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            _logger = logger;
        }

        // GET: /Notification
        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetAll()
        {
            return Ok(Notifications);
        }

        // GET: /Notification/{id}
        [HttpGet("{id}")]
        public ActionResult<Notification> GetById(Guid id)
        {
            var notification = Notifications.FirstOrDefault(n => n.NotificationId == id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        // POST: /Notification
        [HttpPost]
        public ActionResult<Notification> Create([FromBody] Notification newNotification)
        {
            newNotification.NotificationId = Guid.NewGuid();
            newNotification.CreatedAt = DateTime.UtcNow;
            Notifications.Add(newNotification);

            return CreatedAtAction(nameof(GetById), new { id = newNotification.NotificationId }, newNotification);
        }

        // PUT: /Notification/{id}
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, [FromBody] Notification updatedNotification)
        {
            var existing = Notifications.FirstOrDefault(n => n.NotificationId == id);
            if (existing == null)
                return NotFound();

            existing.Title = updatedNotification.Title;
            existing.Message = updatedNotification.Message;
            existing.Type = updatedNotification.Type;
            existing.ExpiresAt = updatedNotification.ExpiresAt;
            existing.IsRead = updatedNotification.IsRead;

            return NoContent();
        }

        // DELETE: /Notification/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existing = Notifications.FirstOrDefault(n => n.NotificationId == id);
            if (existing == null)
                return NotFound();

            Notifications.Remove(existing);
            return NoContent();
        }

        // PATCH: /Notification/{id}/mark-as-read
        [HttpPatch("{id}/mark-as-read")]
        public ActionResult MarkAsRead(Guid id)
        {
            var existing = Notifications.FirstOrDefault(n => n.NotificationId == id);
            if (existing == null)
                return NotFound();

            existing.IsRead = true;
            return NoContent();
        }
    }
}
