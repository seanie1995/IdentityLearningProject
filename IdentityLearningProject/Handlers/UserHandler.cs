using Microsoft.AspNetCore.Mvc;
using IdentityLearningProject.Services;
using IdentityLearningProject.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace IdentityLearningProject.Handlers
{
    public class UserHandler
    {
        public static IResult RegisterUser(IUserService userService, UserDto newUser)
        {
            try
            {
                userService.RegisterUser(newUser);
            }
            catch
            {
                return Results.BadRequest();
            }

            return Results.StatusCode((int)HttpStatusCode.Created);

        }
    }
}
