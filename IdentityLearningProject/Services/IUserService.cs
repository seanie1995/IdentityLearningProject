using IdentityLearningProject.Data;
using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace IdentityLearningProject.Services
{
    public interface IUserService
    {    
        Task<bool> RegisterUser(UserDto user);       
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> RegisterUser(UserDto user) 
        {     
            var identityUser = new User
            {           
                Name = user.Name,
                UserName = user.Email,
                Email = user.Email,           
                Password = user.Password,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            return result.Succeeded;
        }
     
    }
}
