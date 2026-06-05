// See https://aka.ms/new-console-template for more information
using SerializationDeserialization.Demo;

Console.WriteLine("Hello, World!");

void WriteInFile(string path, string text)
{
	using (StreamWriter sw = new StreamWriter(path))
	{
		sw.WriteLine(text);
	}
}

string ReadFromFile(string path)
{
    using (StreamReader sr = new StreamReader(path))
    {
        return sr.ReadToEnd();
    }
}

string directoryPath = @"..\..\..\OurData";
string filePath = Path.Combine(directoryPath, "myFirstJson.json");


#region Manual Serialization/DeSerialization
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

Student bob = new Student()
{
    FirstName = "Bob",
    LastName = "Bobsky",
    Age = 33,
    IsPartTime = false
};

WriteInFile(filePath, bob.ToString());

#endregion


Console.ReadLine();