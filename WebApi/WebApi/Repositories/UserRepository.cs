using Microsoft.AspNetCore.Identity;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Exceptions;
using WebApi.Helpers;
using WebApi.Interfaces;
using WebApi.Model;
using WebApi.Validators;

namespace WebApi.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDBContext _dbContext;
      
        public UserRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteUser(string Email)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string Email)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public LogInResponse LogInUser(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserDto userDto)
        {
            bool isUserExist = _dbContext.users.Find(userDto.Email) != null;
            if (isUserExist)
            {
                throw new AlreadyExistException("User already registered");
            }

            var (PasswordHash, Salt) = PasswordHandlingService.HashPassword(userDto.Password);

            var newUser = new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                PasswordHash = PasswordHash,
                Salt = Salt,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };

            var validator = new UserValidator();
            var result = validator.Validate(newUser);
            if (result.IsValid)
            {
               _dbContext.users.Add(newUser);
                _dbContext.SaveChanges();
            }
            else
            {
                string errorMessages = string.Empty;
                foreach (var error in result.Errors) {
                    errorMessages += error.ErrorMessage;
                }
                throw new InvalidDataException(errorMessages);
            }
        }

        public void UpdateUser(string Email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(string Email, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
