using System;

namespace WebApi.Model
{
    public class Notification
    {
        public Guid NotificationId { get; set; } = Guid.NewGuid(); // Unique identifier
        public required string Title { get; set; } // e.g., "Severe Storm Alert"
        public required string Message { get; set; } // e.g., "A thunderstorm is expected at 3PM."
        public required string Type { get; set; } // e.g., "Alert", "Info", "Warning"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; } // Optional: when the notification should expire
        public bool IsRead { get; set; } = false;
    }
}
