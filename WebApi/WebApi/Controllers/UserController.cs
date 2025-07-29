using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // GET: /User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(Users);
        }

        // GET: /User/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: /User
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            newUser.UserId = Guid.NewGuid();
            newUser.CreatedAt = DateTime.UtcNow;
            newUser.UpdateAt = DateTime.UtcNow;

            Users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        // PUT: /User/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, [FromBody] User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.Salt = updatedUser.Salt;
            user.PasswordHash = updatedUser.PasswordHash;
            user.UpdateAt = DateTime.UtcNow;

            return NoContent();
        }

        // DELETE: /User/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();

            Users.Remove(user);
            return NoContent();
        }
    }
}
