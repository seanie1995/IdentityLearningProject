using IdentityLearningProject.Handlers;
using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using IdentityLearningProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        
        public async Task<IActionResult> Register(UserDto user)
        {
           
            if  (await UserHandler.RegisterUser(_userService, user))
            {
                return Ok("User Registered");
            }
            return BadRequest("User Not Registered");
        }

        [HttpPost("Login")]
        
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (await UserHandler.Login(_userService, loginUser))
            {
                return Ok("Succesfully Logged In");
            }
            return BadRequest("Login Failed");

        }

    }

   
}