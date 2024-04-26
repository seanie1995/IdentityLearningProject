namespace IdentityLearningProject.Models
{
    public class Allergy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Child> Children { get; set; }



    }
}
