 using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using IdentityLearningProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<bool> Register(UserDto user)
        {
            return await _userService.RegisterUser(user);
        }
    }

   
}