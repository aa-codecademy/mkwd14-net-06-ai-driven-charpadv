using AbstractClassesAndInterfaces.Domain.Model;

Developer firstDeveloper = new Developer("Petko", "Petkovski", 27, "Address1", "070123456", "Avenga", 4, new List<string> { "Javascript", "C#" });

//Person person = new Person(); ERROR ->abstract class

firstDeveloper.PrintInfo(); //we call the impl from Person class

Console.WriteLine(firstDeveloper.GetProffestionalInfo()); //here we call the impl from the Developer class

JuniorDeveloper junior = new JuniorDeveloper("Nikola", "Nikolovski", 30, "Address2", "070456123", "Avenga", 1, new List<string> { "Javascript", "C#" }, false);
junior.PrintInfo(); //from Person class
junior.GetProffestionalInfo(); //from Developer
junior.Greet(); //Person - person implements IPerson
junior.Code(); //Developer implements IDeveloper

//junior.TestingFeature(); //ERROR - juniorDeveloper does not implement IQAEngineer

QAEngineer qa = new QAEngineer("Stefan", "Stefanovski", 25, "Address3", "070789654", 3, new List<string> { "Selenium", "Karma"});
qa.TestingFeature("search", DateTime.Now.AddDays(5)); //qa implements IQAEngineer
qa.Code(); //qa implements IDeveloper
qa.Greet(); //qa inherits from Person who implements IPerson


//Boxing and unboxing

Developer dev = new Developer("Trajko", "Trajkovski", 34, "Address4", "07013242", "Avenga", 5, new List<string> { "JS", "C#" });

//Boxing
Person person = (Person)dev;

//Unboxing
Developer developer = (Developer)person; //we convert it back to the specific type

//List<Developer> devs = new List<Developer> { firstDeveloper, dev };
//List<JuniorDeveloper> juniors = new List<JuniorDeveloper> { junior };
//List<QAEngineer> qas = new List<QAEngineer> { qa };


//Boxing all children to parent person class so that they can fit into one list instead of having to create multiple lists
//here we are only interested in the features of all person properties - we do not care about the specifics, we just need the ones from Person class
List<Person> employees = new List<Person> { firstDeveloper, junior, qa, dev };

foreach( Person employee in employees)
{
	employee.GetProffestionalInfo();
	//employee.Code() - person does not implement IDeveloper, so here we cannot call Code method even though most of the employees implement this method. Here we only access the properties and methods that are present in the Person class
}