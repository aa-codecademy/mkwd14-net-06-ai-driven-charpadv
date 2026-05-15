using Exercise01_PetStore.Domain.Enums;

namespace Exercise01_PetStore.Domain.Models
{
	public class Dog : Pet
	{
		public bool GoodBoy { get; set; }
		public string FavouriteFood { get; set; }
		public override void PrintInfo()
		{
			//int type = (int)PetType;
			Console.WriteLine($"{Name} is of type {PetType.ToString()} aged {Age} whose favourite food is {FavouriteFood}");
		}

		public Dog(string name, int age, bool goodBoy,  string favouriteFood)
			:base(name, age, PetTypeEnum.Dog) //here we know that the pet that we are creating is of type Dog
		{
			GoodBoy = goodBoy;
			FavouriteFood = favouriteFood;
		}
	}
}
