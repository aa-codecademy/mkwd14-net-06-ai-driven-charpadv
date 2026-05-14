namespace Polymorphism.Domain
{
	public class Dog : Pet
	{
		public string Color {  get; set; }
		public void Bark()
		{
			Console.WriteLine("Bark bark");
		}

		//we use the override keyword to override the parent impl of a method
		public override void Eat()
		{
			//base.Eat(); //we can use this and call the method from the base class if we want to add something to the existing impl and not completely override the impl

			Console.WriteLine("Calling Eat method from Dog class");
		}
	}
}
