using Exercise.Domain.Models;
using Exercise.Domain.Enums;
using System.Globalization;

List<Dog> dogs = new List<Dog>()
{
	new Dog("Charlie", "Black", 3, Race.Collie), // 0
	new Dog("Buddy", "Brown", 1, Race.Doberman),
	new Dog("Max", "Olive", 1, Race.Plott),
	new Dog("Archie", "Black", 2, Race.Mutt),
	new Dog("Oscar", "White", 1, Race.Mudi),
	new Dog("Toby", "Maroon", 3, Race.Bulldog), // 5
	new Dog("Ollie", "Silver", 4, Race.Dalmatian),
	new Dog("Bailey", "White", 4, Race.Pointer),
	new Dog("Frankie", "Gray", 2, Race.Pug),
	new Dog("Jack", "Black", 5, Race.Dalmatian),
	new Dog("Chanel", "Black", 1, Race.Pug), // 10
	new Dog("Henry", "White", 7, Race.Plott),
	new Dog("Bo", "Maroon", 1, Race.Boxer),
	new Dog("Scout", "Olive", 2, Race.Boxer),
	new Dog("Ellie", "Brown", 6, Race.Doberman),
	new Dog("Hank", "Silver", 2, Race.Collie), // 15
	new Dog("Shadow", "Silver", 3, Race.Mudi),
	new Dog("Diesel", "Brown", 4, Race.Bulldog),
	new Dog("Abby", "Black", 1, Race.Dalmatian),
	new Dog("Trixie", "White", 8, Race.Pointer), // 19
};

List<Person> people = new List<Person>()
{
	new Person("Nathanael", "Holt", 20, Job.Choreographer),
	new Person("Rick", "Chapman", 35, Job.Dentist),
	new Person("Oswaldo", "Wilson", 19, Job.Developer),
	new Person("Kody", "Walton", 43, Job.Sculptor),
	new Person("Andreas", "Weeks", 17, Job.Developer),
	new Person("Kayla", "Douglas", 28, Job.Developer),
	new Person("Richie", "Campbell", 19, Job.Waiter),
	new Person("Soren", "Velasquez", 33, Job.Interpreter),
	new Person("August", "Rubio", 21, Job.Developer),
	new Person("Rocky", "Mcgee", 57, Job.Barber),
	new Person("Emerson", "Rollins", 42, Job.Choreographer),
	new Person("Everett", "Parks", 39, Job.Sculptor),
	new Person("Amelia", "Moody", 24, Job.Waiter)
	{ Dogs = new List<Dog>() {dogs[16], dogs[18] } },
	new Person("Emilie", "Horn", 16, Job.Waiter),
	new Person("Leroy", "Baker", 44, Job.Interpreter),
	new Person("Nathen", "Higgins", 60, Job.Archivist)
	{ Dogs = new List<Dog>(){dogs[6], dogs[0] } },
	new Person("Erin", "Rocha", 37, Job.Developer)
	{ Dogs = new List<Dog>() {dogs[2], dogs[3], dogs[19] } },
	new Person("Freddy", "Gordon", 26, Job.Sculptor)
	{ Dogs = new List<Dog>() {dogs[4], dogs[5], dogs[10], dogs[12], dogs[13] } },
	new Person("Valeria", "Reynolds", 26, Job.Dentist),
	new Person("Cristofer", "Stanley", 28, Job.Dentist)
	{ Dogs = new List<Dog>() {dogs[9], dogs[14], dogs[15] } }
};

//All persons firstnames starting with 'R', ordered by Age DESC
List<string> s1 = people
	.OrderByDescending(x => x.Age) //we need to be able to access the age, so we need the order by to be before the select
	.Where(x => x.FirstName.StartsWith("R"))
	.Select(x => x.FirstName)
	.ToList();

//All brown dogs older than 3 years
List<Dog> s2 = dogs
	.Where(x => x.Color == "Brown" && x.Age > 3)
	.ToList();

//All persons with more than 2 dogs
List<Person> s3 = people
	.Where(x => x.Dogs.Count > 2)
	.ToList();

//All Freddy’s dogs older than 1 year
List<string> s4 = people
	.Single(x => x.FirstName == "Freddy") //we use single to make sure there is only one Freddy in our list
	.Dogs //we need to access Freddy's dogs
	.Where(x => x.Age > 1) //filter them by age before selecting the name
	.Select(x => x.Name)
	.ToList();

//Nathen’s first dog
Dog s5 = people
	.Single(x => x.FirstName == "Nathan") //we use single to make sure there is only one Nathan in our list
	.Dogs //we need to access Nathen’s dogs
	.FirstOrDefault();


//All white dogs from Cristofer, Freddy, Erin and Amelia

List<string> s6 = people
	.Where(x => x.FirstName == "Cristofer" ||x.FirstName == "Freddy" || x.FirstName == "Erin" || x.FirstName == "Amelia") //We need to filter by name for Cristofer, Freddy, Erin and Amelia
	.SelectMany(x => x.Dogs) //we use selectMany beacuse we have a list of people and a list for each person for their dogs -> we want a List<Dog> not a List<List<Dog>>
	.Where(x => x.Color == "White") //Filter by color
	.Select(x => x.Name) //select the name
	.ToList();