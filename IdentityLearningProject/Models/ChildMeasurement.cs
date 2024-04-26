namespace IdentityLearningProject.Models
{
    public class ChildMeasurement
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double headMeasurement { get; set; }
        public DateTime dateOfMeasurement { get; set; }

        public Child Child { get; set; }



    }
}
