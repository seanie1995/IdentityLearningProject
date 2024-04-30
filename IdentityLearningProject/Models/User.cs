using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityLearningProject.Models
{
    public class User : IdentityUser
    {
       
        public string Name { get; set; }
             
        public virtual ICollection<Child> Children { get; set; }


    }

   
}
