using Domain.BaseEntity;

namespace Domain.Models
{
    public class Tester : Person
    {
        public int BugsFound { get; set; }

        public Tester(
            string firstName,
            string lastName,
            int age,
            string mobileNumber,
            int bugsFound)
            : base(firstName, lastName, age, mobileNumber)
        {
            BugsFound = bugsFound;
        }
    }
}
