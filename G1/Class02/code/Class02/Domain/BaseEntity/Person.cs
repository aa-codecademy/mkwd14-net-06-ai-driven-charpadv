using Domain.Interfaces;

namespace Domain.BaseEntity
{
    /*
        *Abstract Class* => A class declared with the abstract keyword. It may contain abstract members, non-abstract members, constructors etc.

        *Abstract Member* => A member (method, property) declared in an abstract class without providing an implementation. Abstract members are intended to be implemented by derived classes.
        
        *Usecase* => Abstract classes are often used as base classes for inheritance. 
    */
    public abstract class Person : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        //public abstract string Test { get; set; } // rarely used

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

        // Not abstract method => will be inherited as is
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Abstract method => the derived classes will have to provide implementation
        public abstract string GetInfo();

        public void Greet(string name)
        {
            Console.WriteLine($"Hello {name}");
        }
    }
}
