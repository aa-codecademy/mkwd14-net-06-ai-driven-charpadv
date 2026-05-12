using Polymorphism.Models;
using Polymorphism.Services;

Console.WriteLine("Hello, World!");

#region Runtime Polymorphism
// Run-Time Polymorphism (Method Overriding / Dynamic)

Pet randomPet = new Pet
{
    Name = "Mali"
};
randomPet.Eat();

Cat zuza = new Cat
{
    Name = "Zuza",
    IsLazy = true
};
zuza.Eat();

Dog aks = new Dog
{
    Name = "Aks"
};
aks.Eat();

#endregion

#region Compile-Time Polymorphism
// Compile-Time Polymorphism (Method Overloading / Static)

PetService petService = new PetService();

petService.PrintPetInfo();
petService.PrintPetInfo(aks);
petService.PrintPetInfo(zuza);
petService.PrintPetInfo("Bob", aks);


#endregion

Console.ReadLine();