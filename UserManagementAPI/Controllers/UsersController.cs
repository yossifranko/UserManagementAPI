using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;
using UserManagementAPI.DTOs;
using UserManagementAPI.DTOs.UserManagementAPI.DTOs;
namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult ZorMishtamesh([FromBody] User mishtameshHadash)
        {
            if (string.IsNullOrEmpty(mishtameshHadash.UserName) || string.IsNullOrEmpty(mishtameshHadash.UserPassword))
            {
                return BadRequest("שם משתמש וסיסמה הם שדות חובה.");
            }

            var mishtamesh = _repo.AddUser(mishtameshHadash);
            return CreatedAtAction(nameof(KabelMishtamesh), new { id = mishtamesh.UserId }, mishtamesh);
        }

        [HttpDelete("{id}")]
        public IActionResult MehakMishtamesh(int id)
        {
            var nimhak = _repo.FindUser(id);
            if (nimhak)
            {
                return NoContent();
            }
            return NotFound($"לא נמצא משתמש עם מזהה {id}.");
        }

        [HttpPost("add")]
        public IActionResult AddUser(string username,string password)
        {
            User to_add= new User();
            to_add.UserName = username;
            to_add.UserPassword = password;
            User added = _repo.AddUser(to_add);

            return Ok (added);
        }



        [HttpGet("getall")]
        public IActionResult GetAllUsers()
        {

            List<User> all = _repo.GetAllUsers();

            return Ok(all);
        }


        [HttpGet("find")] 
        public IActionResult find_user( int id)
        {
            // check if is valid 
            var user = _repo.FindUser(id);
            if (!user)
                return NotFound("user missing");

            return Ok("user exiest ");
        }


        [HttpDelete("remove")]
        public IActionResult remove_user(int id)
        {
            // check if is valid 
            var user = _repo.GetUserObj(id);
            if (user != null)
            {
                _repo.removeUser(user);
                return Ok(string.Format("user {0} was deleted ",id));
            }
            return NotFound();
      
        }


        [HttpPost("validate")]
        public IActionResult validate([FromBody] LoginRequestDto bakasha)
        {
            var mishtamesh = _repo.Validate(bakasha.Username, bakasha.Password);
            if (mishtamesh != null)
            {
                return Ok(mishtamesh);
            }
            return Unauthorized("שם משתמש או סיסמה לא תקינים.");
        }

        [HttpGet("{id}")]
        public IActionResult KabelMishtamesh(int id)
        {
     
            return Ok();
        }
    }
}
