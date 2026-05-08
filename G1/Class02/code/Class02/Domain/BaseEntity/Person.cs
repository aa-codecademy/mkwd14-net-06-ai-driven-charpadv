namespace Domain.BaseEntity
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }

        public Person(
            string firstName,
            string lastName,
            int age,
            string mobileNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            MobileNumber = mobileNumber;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
