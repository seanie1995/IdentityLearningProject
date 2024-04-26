using IdentityLearningProject.Handlers;
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

        private readonly UserHandler _userHandler;

        public UserController(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public void Register(UserDto user)
        {
            UserHandler.RegisterUser(_userService, user);
            
        }
    }

   
}