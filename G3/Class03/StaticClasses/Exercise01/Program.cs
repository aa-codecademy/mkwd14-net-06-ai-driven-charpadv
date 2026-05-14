using Exercise01.Domain;
using Exercise01.Domain.Models;

Dog dog1 = new Dog();
dog1.Name = ""; //string.Empty
dog1.Color = "Black";
dog1.Id = 4;

//Bark is a non-static member - so we use the object (the instance) to call it
dog1.Bark();

//Validate is a static method, so we use the class name to call it
if (Dog.Validate(dog1))
{
	DogShelter.Dogs.Add(dog1); //static list
}

DogShelter.PrintAll(); //static method