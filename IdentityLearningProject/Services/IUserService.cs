using IdentityLearningProject.Data;
using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace IdentityLearningProject.Services
{
    public interface IUserService
    {    
        Task<bool> RegisterUserAsync(UserDto user);
        Task<bool> LoginAsync(LoginUserDto User);

    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager; // User manager is needed to add info into AspNetUsers. 
                                                         // Make sure to input User (or IdentityUser if not using custom model) as parameter
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(UserDto user) 
        {     

            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return false;
            }

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

        public async Task<bool> LoginAsync(LoginUserDto loginUser)
        {
            var identityUser = await _userManager.FindByEmailAsync(loginUser.Email);

            if (identityUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, loginUser.Password);

        }

     
    }
}
