using Exercise01_PetStore.Domain;
using Exercise01_PetStore.Domain.Models;

PetStore<Dog> dogPetStore = new PetStore<Dog>(); //the petStore is non-static
dogPetStore.Pets.Add(new Dog("Sparky", 1, true, "Bacon"));
dogPetStore.Pets.Add(new Dog("Lucy", 3, true, "Meat"));

Console.WriteLine("Dogs in our store:");
dogPetStore.PrintPets();

//boxing
PetStore<Pet> petStore = new PetStore<Pet>();
petStore.Pets.Add(new Dog("Sparky", 1, true, "Bacon"));
petStore.Pets.Add(new Cat("Lucy", 3, true, 9));
petStore.Pets.Add(new Fish("Nemo", 1, "orange", 6));

Console.WriteLine("Welcome to our pet store");
petStore.PrintPets();

petStore.BuyPet("Nemo");
petStore.PrintPets();