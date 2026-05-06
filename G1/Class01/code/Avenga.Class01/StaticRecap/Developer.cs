namespace StaticRecap
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public static int NumberOfDevelopers { get; set; }

        public Developer(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            NumberOfDevelopers++;
        }

        public int GetNumberOfDevelopers()
        {
            return NumberOfDevelopers;
        }

        public static void ResetNumberOfDevelopers()
        {
            NumberOfDevelopers = 0;
        }

    }
}
