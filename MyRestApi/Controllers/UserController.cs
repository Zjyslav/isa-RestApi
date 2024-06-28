using Microsoft.AspNetCore.Mvc;

namespace MyRestApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            _userRepository.Add(user);
            return Created("database", user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePutUser([FromBody] User user)
        {
            _userRepository.Update(user);
            return Ok(user);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePatchUser([FromBody] User user)
        {
            _userRepository.Update(user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = _userRepository.Get(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async    Task<IActionResult> DeleteUserById([FromRoute] int id)
        {
            var user = _userRepository.Delete(id);
            return Ok(user);
        }
    }
}
