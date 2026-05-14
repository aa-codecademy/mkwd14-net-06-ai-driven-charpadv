
//Runtime polymorphism

using Polymorphism.Domain;

Pet firstPet = new Pet();
firstPet.Name = "PetName";
firstPet.Eat(); //method from Pet

Pet secondPet = new Cat(); //boxing
secondPet.Name = "Lucy";
//secondPet.Age; ERROR -> because secondPet is of type Pet (boxing) and we can only access the properties and methods from Cat that are actually inherited from Pet
secondPet.Eat(); //from Cat - with boxing we are only seeing the properties and methods that are inherited from Pet, but we are seeing/using them from Cat. We are "ignoring" the properties and methods that are specific for Cat

Cat cat = new Cat();
cat.Eat(); //from Cat

List<Pet> pets = new List<Pet>();
Dog dog = new Dog();
dog.Name = "Sparky";
dog.Eat(); //from Dog

//Boxing
pets.Add(dog); //from Dog
pets.Add(firstPet); //from Pet
pets.Add(secondPet); //from Cat
pets.Add(cat); //from Cat

foreach(Pet pet in pets)
{
	pet.Eat(); //in each iteration the method Eat will be called from the specific class with its specific impl
}

//Compile time polymorphism
PetService service = new PetService();
service.PetStatus();
service.PetStatus("Petko", cat);
service.PetStatus(cat, "Petko");
service.PetStatus(dog, "Petko");
service.PetStatus("Petko", dog);
service.PetStatus("Petko");
service.PetStatus(3);
