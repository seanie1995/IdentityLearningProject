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
            var result = await UserHandler.RegisterUser(_userService, user);

            if (result == false)
            {
                return BadRequest("Failed");
            }


            return Ok("Account Created");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            var result = await UserHandler.Login(_userService, loginUser);

            if (result == false)
            {
                return BadRequest("Wrong username or password");
            }

            return Ok("Login success");

        }

    }

   
}