using System.ComponentModel.DataAnnotations;

namespace IdentityLearningProject.Models.DTO
{
    public class LoginUserDto
    {     

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
    }
}
