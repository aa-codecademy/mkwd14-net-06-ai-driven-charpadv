namespace Polymorphism.Domain
{
	public class Pet
	{
		public string Name { 
			get
			{
				//we can add some validation, or permission check here
				Console.WriteLine("Getting the name");
				return Name;
			}

			set
			{
				if(!string.IsNullOrEmpty(value))
				{
					Name = value;
				}
			}
		}

		//we use the virtual keyword to allow the method to be overriden in the derived classes
		public virtual void Eat()
		{
			Console.WriteLine("Calling Eat method from Pet class...");
		}
	}
}
