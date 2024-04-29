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
            
            if(await userService.RegisterUserAsync(newUser))
            {
                return Results.Ok("User Registered");
            }
            else
            {
                return Results.BadRequest("User Not Registered");
            }
           

        }

        public static async Task<IResult> LoginAsync(IUserService userService, LoginUserDto loginUser)
        {
            if (await userService.LoginAsync(loginUser))
            {
                return Results.Ok("Login Success");
            }
            else
            {
                return Results.BadRequest("Login Failed");
            }
        }
    }
}
