using WebApi.Dtos;

namespace WebApi.Interfaces
{
    public interface INotification
    {
        public void SendNotification(NotificationDto notificationDto);
        
    }
}
