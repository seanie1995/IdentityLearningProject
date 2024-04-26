﻿using IdentityLearningProject.Data;
using IdentityLearningProject.Models;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace IdentityLearningProject.Services
{
    public interface IUserService
    {    
        void RegisterUser(UserDto user);       
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager; // User manager is needed to add info into AspNetUsers. 
                                                         // Make sure to input User (or IdentityUser if not using custom model) as parameter
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async void RegisterUser(UserDto user) 
        {     
            var identityUser = new User
            {           
                Name = user.Name,
                UserName = user.Email,
                Email = user.Email,           
                Password = user.Password,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
        
        }
     
    }
}
