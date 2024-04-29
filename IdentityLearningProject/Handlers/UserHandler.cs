using Microsoft.AspNetCore.Mvc;
using IdentityLearningProject.Services;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace IdentityLearningProject.Handlers
{
    public class UserHandler
    {
        public static async Task<IResult> RegisterUserAsync(IUserService userService, UserDto newUser)
        {
            
            var result = await userService.RegisterUserAsync(newUser);

            return result;
           

        }
   

        public static async Task<IResult> UserLoginASync(IUserService userService, LoginUserDto loginUser)
        {
            var result = await userService.UserLoginAsync(loginUser);

            return result;
        }
    }
}
