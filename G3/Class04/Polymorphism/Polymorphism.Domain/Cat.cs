namespace Polymorphism.Domain
{
	public class Cat : Pet
	{
        private int Age { get; set; } //if we want to use additional get and set methods for some validations, permissions etc we need to make this prop private so that the default get and set are not accessable from other classes

		public override void Eat()
		{
			Console.WriteLine("Calling Eat method from Cat class");
		}

		public int GetAge()
		{
			Console.WriteLine("getting the cat age");
			return Age;
		}

		public void SetAge(int age)
		{
			Console.WriteLine("Setting the age");
			Age = age;
		}
	}
}
