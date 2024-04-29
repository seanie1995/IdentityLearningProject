using IdentityLearningProject.Data;
using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityLearningProject.Services
{
    public interface IUserService
    {    
        Task<IResult> RegisterUserAsync(UserDto user);
        Task<IResult> UserLoginAsync(LoginUserDto User);

    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager; // User manager is needed to add info into AspNetUsers. 
                                                         // Make sure to input User (or IdentityUser if not using custom model) as parameter
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

       
        public async Task<IResult> RegisterUserAsync(UserDto user) 
        {     

            User existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser != null)
            {
                return Results.BadRequest("User already exists in database.");
            }

            var identityUser = new User
            {           
                Name = user.Name,
                UserName = user.Email,
                Email = user.Email,                         
            };
        
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                // User created successfully, return Ok
                return Results.Ok("User created successfully.");
            }
            else
            {
                // User creation failed, return BadRequest with error message
                return Results.BadRequest("Failed to create user.");
            }

        }

        public async Task<IResult> UserLoginAsync(LoginUserDto loginUser)
        {

            var identityUser = await _userManager.FindByEmailAsync(loginUser.Email);

            if (identityUser == null)
            {
                return Results.BadRequest($"User Not Found");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(identityUser, loginUser.Password);

            if (!isPasswordValid)
            {
                return Results.BadRequest("Invalid email or password.");
            }

            return Results.Ok("Login successful.");
        }

        //public async Task<bool> UserLoginAsync(LoginUserDto loginUser)
        //{
        //    var identityUser = await _userManager.FindByEmailAsync(loginUser.Email);

        //    if (identityUser is null)
        //    {
        //        return false;
        //    }

        //    return await _userManager.CheckPasswordAsync(identityUser, loginUser.Password);

        //}

    }
}
