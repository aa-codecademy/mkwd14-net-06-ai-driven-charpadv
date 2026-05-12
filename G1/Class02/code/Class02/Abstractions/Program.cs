using Domain.BaseEntity;
using Domain.Interfaces;
using Domain.Models;

Console.WriteLine("Hello, World!");

#region Creating instances (objects)

Developer dev = new Developer("Bob", "Bobsky", 35, "+1 123 532 2343", new List<string> { "JavaScript", "C#", "C++" }, 5);

Tester tester = new Tester("Jill", "Wayne", 24, "+1 223 305 1234", 10);

Operations operations = new Operations("Greg", "Gregsky", 38, "+1 234 434 5353", ["Optimus", "ProtoBeat", "Abacus"]);

DevOps devOps = new DevOps("John", "Doe", 29, "+1 123 123 1234", false, true);

QAEngineer qa = new QAEngineer("Steve", "Stevenson", 34, "+1 123 354 4323", ["Selenium", "Playwright"]);

// => Can't create an instance of an abstract class !
//Person person = new Person("Ilija", "Mitev", 45, "+123 123412");
//Console.WriteLine(person.GetFullName());

#endregion


#region Using Abstractions as Types (BAD PRACTISE - in most cases)
// => we can still use Person as a type (eventhough it's now abstract class)
Person juniorDev = new Developer("Ilija", "Mitev", 45, "+123 123412", ["C#"], 10);
// juniorDev.Code(); // ERROR
// However, only the methods and properties from the Person class will be available in the created instance

IDeveloper seniorDev = new Developer("Ilija", "Mitev", 45, "+123 123412", ["C#"], 10);
// since we are using IDeveloper as a type, only the Code() method will be available in the seniorDev object

seniorDev.Code();
// seniorDev.GetInfo(); // ERROR

#endregion


#region Testing methods

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(dev.GetInfo());
dev.Code();
dev.Greet("Buddy");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(qa.GetInfo());
qa.Code();
qa.TestFeature("Log in");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(devOps.GetInfo());
devOps.Code();
Console.WriteLine(devOps.CheckInfrastructure(500) ? "Error occured!" : "Everything's fine");
Console.ResetColor();

#endregion


Console.ReadLine();