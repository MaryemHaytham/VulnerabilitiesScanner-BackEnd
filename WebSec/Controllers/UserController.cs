using DAL.Entity;
using DAL.Repositories.IRepositories;
using DLL.Services;
using DLL.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSec.ViewModels;

namespace WebSec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _iJwtService;

        public UserController(IUserService userService, IUserRepository userRepository, IJwtService ijwtService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _iJwtService = ijwtService;

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] AddUserVM user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var Newuser = new User
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                RePassword = user.RePassword


            };
            // Validate and register the user
            bool registrationResult = _userService.RegisterUser(Newuser);


            if (registrationResult)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //[HttpPost("login")]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserVM request)
        {
            var user = _userRepository.GetUserByEmail(request.Email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            // Hash the password entered during login
            string hashedPassword = _userService.HashPassword(request.Password);

            if (user.Password != hashedPassword)
            {
                return BadRequest("Invalid Password");
            }

            var token = _iJwtService.GenerateToken(user);

            return Ok(new { Token = token });
        }
        //[Authorize] //this attribute to secure the endpoint
        //[HttpGet("secure-endpoint")]
        //public IActionResult SecureEndpoint()
        //{

        //    return Ok("This is a secure endpoint.");
        //}
        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userService.GetUser(id));
        }

    }
    


}
