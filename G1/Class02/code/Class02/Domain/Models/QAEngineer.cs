using Domain.BaseEntity;

namespace Domain.Models
{
    public class QAEngineer : Person
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

    }
}
