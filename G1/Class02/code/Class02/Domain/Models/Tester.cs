using Domain.BaseEntity;
using Domain.Interfaces;

namespace Domain.Models
{
    public class Tester : Person, ITester
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

        public override string GetInfo()
        {
            return $"{GetFullName()} ({Age}) - Found {BugsFound} bugs!";
        }

        public void TestFeature(string feature)
        {
            Console.WriteLine($"{feature} is being tested...");
            Console.WriteLine("Testing complete!");
        }
    }
}
