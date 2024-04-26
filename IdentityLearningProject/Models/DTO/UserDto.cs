using System.ComponentModel.DataAnnotations;

namespace IdentityLearningProject.Models.DTO
{
    public class UserDto
    {
        
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
     
        [MinLength(6)]
        public string Password { get; set; }
    }
}
