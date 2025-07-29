using System.ComponentModel.DataAnnotations;
using WebApi.Dtos;
using WebApi.Model;

namespace WebApi.Interfaces
{
    public interface IUser
    {
        public void RegisterUser(UserDto userDto);
        public LogInResponse LogInUser(string Email, string Password);
        public User GetUser(string Email);
        public List<User> GetUsers();
        public void UpdateUser(string Email, string newPassword);
        public void UpdateUser(string Email, UserDto userDto);
        public void DeleteUser(string Email);

    }
}
