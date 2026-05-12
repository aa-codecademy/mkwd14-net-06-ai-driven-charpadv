using Polymorphism.Models;

namespace Polymorphism.Services
{
    // Compile-Time Polymorphism ( Method overloading )
    // Methods have the same name
    // Their signature is different

    // Method Signature: <method name>(<parameter types and order>)
    public class PetService
    {
        public void PrintPetInfo()
        {
            Console.WriteLine("Missing pet info");
        }

        public void PrintPetInfo(Cat cat)
        {
            Console.WriteLine($"This cat is {(cat.IsLazy ? "lazy" : "not lazy")}");
        }

        //public void PrintPetInfo(Cat petko)
        //{
        //    Console.WriteLine();
        //}

        public void PrintPetInfo(Dog dog)
        {
            Console.WriteLine($"This dog is {(dog.IsFriendly ? "friendly" : "not friendly")}");
        }

        public void PrintPetInfo(string owner, Dog dog)
        {
            Console.WriteLine($"The owner {owner} has dog named {dog.Name}");
        }

        public void PrintPetInfo(Dog dog, string owner)
        {
            Console.WriteLine($"The owner {owner} has dog named {dog.Name}");
        }

        public void PrintPetInfo(string owner, Dog dog, int dogAge)
        {
            Console.WriteLine($"The owner {owner} has dog named {dog.Name} that is {dogAge} year.");
        }
    }
}
