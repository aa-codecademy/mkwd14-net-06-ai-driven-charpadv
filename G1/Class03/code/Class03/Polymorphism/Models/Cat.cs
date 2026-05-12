namespace Polymorphism.Models
{
    public class Cat : Pet
    {
        public bool IsLazy { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Cat {Name} says hello!");
        }

        public override void Eat()
        {
            //base.Eat();
            Console.WriteLine($"The {(IsLazy ? "lazy" : "")} cat {Name} is eating...");
        }

    }
}
