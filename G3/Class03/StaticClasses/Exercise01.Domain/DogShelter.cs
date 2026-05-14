using Exercise01.Domain.Models;

namespace Exercise01.Domain
{
	public static class DogShelter
	{
        public static List<Dog> Dogs { get; set; }

		static DogShelter()
		{
			Dogs = new List<Dog>()
			{
				new Dog()
				{
					Id = 1, Name="Sparky", Color="Black"
				},
				new Dog()
				{
					Id = 2, Name="Luna", Color="Brown"
				},
				new Dog()
				{
					Id = 3, Name="Hera", Color="Black"
				}
			};
		}

		public static void PrintAll()
		{
			foreach(Dog dog in Dogs)
			{
				Console.WriteLine($"{dog.Id}. {dog.Name} {dog.Color}");
			}
		}
    }
}
