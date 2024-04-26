namespace IdentityLearningProject.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set;}
        public virtual ICollection<User> Parents { get; set; }



    }
}
