using Domain.BaseEntity;

namespace Domain.Models
{
    public class Operations : Person
    {
        public List<string> Projects { get; set; } = new();

        public Operations(
            string firstName, 
            string lastName, 
            int age, 
            string mobileNumber,
            List<string> projects) 
            : base(firstName, lastName, age, mobileNumber)
        {
            Projects = projects;
        }
    }
}
