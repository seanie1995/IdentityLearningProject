using Microsoft.AspNetCore.Mvc;
using IdentityLearningProject.Services;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace IdentityLearningProject.Handlers
{
    public class UserHandler
    {
        public static async Task<bool> RegisterUser(IUserService userService, UserDto newUser)
        {
            try
            {
                return await userService.RegisterUser(newUser);
                
                
            }
            catch 
            {
                return false;         
            }

           

        }

        public static async Task<bool> Login(IUserService userService, LoginUserDto loginUser)
        {
            try
            {
                return await userService.Login(loginUser);
                         
            }
            catch
            {
                return false;
            }
           
        }
    }
}
