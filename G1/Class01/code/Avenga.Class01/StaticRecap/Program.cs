using StaticRecap;

HelloWorld();

void HelloWorld() 
{
    Console.WriteLine("Hello, World!");
}

var mario = new Developer("Mario", "Rossi", 30);
Console.WriteLine(mario.GetNumberOfDevelopers());
Console.WriteLine(Developer.NumberOfDevelopers);
Developer.ResetNumberOfDevelopers();
Console.WriteLine(Developer.NumberOfDevelopers);


Console.ReadLine();