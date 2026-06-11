using Newtonsoft.Json;
using SerializationAndDeserialization;

string folderPath = @"..\..\..\Example";
string filePath = folderPath + @"\jsonFile.json";

Student student = new Student()
{
	Firstname = "Petko",
	Lastname = "Petkovski",
	Age = 25,
	IsPartTime = true,
};

CustomReaderWriter readerWriter = new CustomReaderWriter();

Directory.CreateDirectory(folderPath);

//1. serialze the student obj to json
string studentJson = CustomSerializerAndDeserializer.SerializeStudent(student);

//2. write JSON to file
readerWriter.WriteToFile(studentJson, filePath);

//3. read from file
string jsonFromFile = readerWriter.ReadFromFile(filePath);

//4. deserialize JSON into a student obj
Student deserializedStudent = CustomSerializerAndDeserializer.DeserializeStudent(jsonFromFile);

Console.WriteLine(deserializedStudent.Firstname + " " + deserializedStudent.Lastname);


//Newtonsoft.JSON
//we need to install a library (package) from nuget package manager
//we can install it on a concrete project or multiple projects
//to install it you need to right click on solution or project -> manage nuget packages

Student anotherStudent = new Student
{
	Firstname = "Marko",
	Lastname = "Markovski",
	Age = 25,
	IsPartTime = false
};

//1. serialize student obj to JSON - we need to include JsonConvert from Newtonsoft.Json
string jsonString = JsonConvert.SerializeObject(anotherStudent);

//2. write to file
readerWriter.WriteToFile(jsonString, filePath);

//3.read from file
string jsonFileContent = readerWriter.ReadFromFile(filePath);

//4. deserialize json into student obj - we need to tell the DeserializeObject method into what obj to deserialize
Student marko = JsonConvert.DeserializeObject<Student>(jsonFileContent);

Console.WriteLine(marko?.Firstname + " " + marko?.Lastname);