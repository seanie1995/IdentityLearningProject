using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityLearningProject.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual ICollection<Child> Children { get; set; }


    }

   
}
