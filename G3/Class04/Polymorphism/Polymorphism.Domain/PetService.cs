using System.Xml.Linq;

namespace Polymorphism.Domain
{
	//Compile time polymorphism
	//Having methods with the same name but different signatures
	public class PetService
	{
		public void PetStatus()
		{
			Console.WriteLine("PetStatus without params");
		}

		//ERROR
		//When calling this method we don't specify the return type - we call it using its name and the type and number and order of params
		//so here the program won't know which PetStatus without params to call
		//public string PetStatus()
		//{
		//	return "Will show an error";
		//}


		//the name of the method is the same, but now it has two params - first one is string and second one is Cat
		//now when calling the PetStatus method if we send it a string and a Cat in that order it will know which method to call
		public void PetStatus(string name, Cat cat)
		{
			Console.WriteLine($"Hello {name}. The {cat.Name} is {cat.Age} years old");
		}

		//ERROR
		//When we call the method we do not specify the name of the params, just the types
		//here it will conflict with the method above - first param is string and second param is Cat
		//public void PetStatus(string catName, Cat catObject)
		//{
		//	Console.WriteLine($"Hello {catName}. The {catObject.Name} is {catObject.Age} years old");
		//}

		//This is valid - the name of the method is the same, it has two params, but here the type of the first param is Cat and the type of the second param is string
		//The order of the params is important
		public void PetStatus(Cat cat, string name)
		{
			Console.WriteLine($"Hello {name}. The {cat.Name} is {cat.Age} years old");
		}

		//same name, also two params, but here first param is of type string and the second one is of type Dog
		public void PetStatus(string name, Dog dog)
		{
			Console.WriteLine($"Hello {name}. The {dog.Name} is {dog.Color}");
		}

		//same name, also two params, but here first param is of type Dog and the second one is of type string
		public void PetStatus (Dog dog, string name)
		{
			Console.WriteLine($"Hello {name}. The {dog.Name} is {dog.Color}");
		}

		//one param - type string
		public void PetStatus(string name)
		{
			Console.WriteLine($"Hello {name}");
		}

		//also one param, but type int
		public void PetStatus(int age)
		{
			Console.WriteLine(age);
		}
	}
}
