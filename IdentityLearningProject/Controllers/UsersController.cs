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

        [HttpPost]
        public IActionResult Register(UserDto user)
        {
            var result = UserHandler.RegisterUser(_userService, user);

            
            return StatusCode((int)HttpStatusCode.Created);
        }
    }

   
}