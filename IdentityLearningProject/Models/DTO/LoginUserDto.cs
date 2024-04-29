using System.ComponentModel.DataAnnotations;

namespace IdentityLearningProject.Models.DTO
{
    public class LoginUserDto
    {     

     
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
    }
}
