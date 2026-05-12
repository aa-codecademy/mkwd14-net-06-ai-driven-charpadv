namespace Polymorphism.Models
{
    public class Dog : Pet
    {
        public bool IsFriendly { get; set; }

        public override void Eat()
        {
            Console.WriteLine($"The {(IsFriendly ? "friendly" : "")} dog {Name} is eating...");
        }
    }
}
