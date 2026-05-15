using Exercise01_PetStore.Domain.Models;

namespace Exercise01_PetStore.Domain
{
	public class PetStore<T> where T : Pet
	{
		public List<T> Pets { get; set;}

		public PetStore()
		{
			Pets = new List<T>(); //we need to create an empty list here, so that it is not null (the default value)
		}

		public void PrintPets()
		{
            foreach (T item in Pets)
            {
				item.PrintInfo(); //we can call PrintInfo here, beacuse T must be a type that is or inherits from Pet - which means that it has to have an impl of printInfo
            }
        }

		//for this example we do not have an id, so we will use the name as identifier
		public void BuyPet(string name)
		{
			//Lucy != lucy 
			//with toLower -> lucy == lucy
			//here we can use the Name property because our T inherits from Pet and each Pet has a name
			T pet = Pets.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
			if(pet != null)
			{
				Pets.Remove(pet); //this pet now has its owner and is no longer a part of our store
				Console.WriteLine($"Your pet name is {name}");
			}
			else
			{
				Console.WriteLine($"There is no pet named {name}");
			}
		}
	}
}
