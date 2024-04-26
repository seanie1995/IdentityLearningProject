﻿using IdentityLearningProject.Data;
using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace IdentityLearningProject.Services
{
    public interface IUserService
    {    
        Task<bool> RegisterUser(UserDto user);
        Task<bool> Login(LoginUserDto User);

    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager; // User manager is needed to add info into AspNetUsers. 
                                                         // Make sure to input User (or IdentityUser if not using custom model) as parameter
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

        public async Task<bool> Login(LoginUserDto user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);

            if (identityUser == null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);

        }

     
    }
}
