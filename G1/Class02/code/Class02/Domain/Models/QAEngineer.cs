using Domain.BaseEntity;
using Domain.Interfaces;

namespace Domain.Models
{
    // We can inherit from multiple interfaces at a time
    public class QAEngineer : Person, IDeveloper, ITester
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string MobileNumber { get; set; }
        //public int Age { get; set;  }

        public List<string> TestingFrameworks { get; set; }

        public QAEngineer(
            string firstName,
            string lastName,
            int age,
            string mobileNumber,
            List<string> frameworks)
            : base(firstName, lastName, age, mobileNumber)
        {
            TestingFrameworks = frameworks;
        }

        public override string GetInfo()
        {
            return $"{GetFullName()} ({Age}) - Knows testing frameworks: {(TestingFrameworks.Count != 0 ? string.Join(", ", TestingFrameworks) : "N/A")}";
        }

        public void Code()
        {
            Console.WriteLine("Tak tak tak...");
            Console.WriteLine("Writes automation test...");
            Console.WriteLine("Tak tak tak...");
        }

        public void TestFeature(string feature)
        {
            Console.WriteLine("Run Unit Tests...");
            Console.WriteLine("Run Automated Tests...");
            Console.WriteLine($"Tests for the {feature} feature are done!");
        }
    }
}
