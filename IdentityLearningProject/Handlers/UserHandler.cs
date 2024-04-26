using Microsoft.AspNetCore.Mvc;
using IdentityLearningProject.Services;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace IdentityLearningProject.Handlers
{
    public class UserHandler
    {
        public static async Task<IResult> RegisterUser(IUserService userService, UserDto newUser)
        {
            try
            {
                await userService.RegisterUser(newUser);
            }
            catch
            {
                return Results.BadRequest();
            }

            return Results.StatusCode((int)HttpStatusCode.Created);

        }
    }
}
