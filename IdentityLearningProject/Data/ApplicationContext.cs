using IdentityLearningProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IdentityLearningProject.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<ChildMeasurement> ChildMeasurements { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

       
    }
}
