using Exercise.Domain;
using Newtonsoft.Json;

string folderPath = @"..\..\..\Data";
string filePath = $@"{folderPath}\dogs.json";

Directory.CreateDirectory(folderPath);

//in the beginning we need to read from the file to check if some dogs already exist
//beacause StreamReader does not create the file for us, we need to create it here
if (!File.Exists(filePath))
{
	File.Create(filePath).Close(); //we need to close the file, because it return FileStream and we need to close that stream otherwise our file will not be free for access
}

List<Dog> dogs;

//we need to check if the file already contains a list of dogs - if so, we need to take the content, deserialize it, add the new dog, serialize it again and write it in the file
using(StreamReader sr = new StreamReader(filePath))
{
	string content = sr.ReadToEnd(); //json string
	dogs = JsonConvert.DeserializeObject<List<Dog>>(content); //in the file we would have a List<Dog>

	if(dogs == null)
	{
		dogs = new List<Dog>(); //we need to create an empty list if there isn't one already
	}
}

//loop while the user enters info about dogs
while (true)
{
	Console.WriteLine("Please enter your dog info:");
	Console.WriteLine("Name:");
	string name = Console.ReadLine();
	Console.WriteLine("Color:");
	string color = Console.ReadLine();
	Console.WriteLine("Age:");
	string age = Console.ReadLine();

	if(!int.TryParse(age, out int ageNumber))
	{
		Console.WriteLine("Wrong input for age, please enter a valid number");
		continue; //it will skip this iteration and go back and to ln 31 and enter the info again
	}

	Dog dog = new Dog(name, color, ageNumber);
	dogs.Add(dog);

	Console.WriteLine("Do you want to enter a new dog - press Y");
	string choice = Console.ReadLine();	

	if(choice.ToLower() != "y") {
		break; //if the user enters anything else - end the loop
	}
}

using (StreamWriter sw = new StreamWriter(filePath))
{
	//we need to serialize our List<Dog> into json
	string result = JsonConvert.SerializeObject(dogs);
	sw.WriteLine(result);
}