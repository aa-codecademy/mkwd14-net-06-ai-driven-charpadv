string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectory); //absolute path C:\Users\stoja\OneDrive\Desktop\SEDC\C# Advanced 2026\repo\G3\Class10\Code\WorkingWithFileSystem\bin\Debug\net8.0

string appPath = @"..\..\..\"; //relative path to the console app folder

//check if this path exists ..\..\..\myFolder (check if three levels before (before the current directory) there is a folder named myFolder
bool myFolderExists = Directory.Exists(appPath + "myFolder"); //here we pass as param the path which we want to check
Console.WriteLine(myFolderExists);

string newFolderPath = appPath + "newFolder";
if (!Directory.Exists(newFolderPath)) //if this newFolder does not exist in this location (this path)
{
	Directory.CreateDirectory(newFolderPath); //here we send the path where we want the directory to be created
	Console.WriteLine("New folder created successfully");
}

Console.WriteLine(Directory.Exists(newFolderPath)); //now it should be true

if (Directory.Exists(newFolderPath)) //always check that the path exists before trying to delete it
{
	//Directory.Delete(newFolderPath); //here we send the path that we want to delete
	Console.WriteLine("New folder deleted successfully");
}

if(!Directory.Exists(appPath + "myFolder"))
{
	Directory.CreateDirectory(appPath + "myFolder"); //we need to create the folder before trying to manipulate with it
}

string textTxtPath = appPath + @"myFolder\test.txt";
bool textTxtExists = File.Exists(textTxtPath);
Console.WriteLine(textTxtExists);

if (!textTxtExists)
{
	File.Create(textTxtPath).Close(); //Create returns a FileStream that we need to close because we do not need it now, and we do not want to keep it unnecessary opened
}

if(File.Exists(textTxtPath)) //check if the file was successfully created
{
	File.WriteAllText(textTxtPath, "Hello G3"); //writeAllText overwrites the content of test.txt
}


if (File.Exists(textTxtPath)) //check if the file was successfully created
{
	File.WriteAllText(textTxtPath, "Hello again G3! This is another text in test.txt"); //writeAllText overwrites the content of test.txt
}

if(File.Exists(textTxtPath))
{
	//this will append the text to the existing content of test.txt
	File.AppendAllText(textTxtPath, Environment.NewLine + "See you next Thursday!");
}

if (File.Exists(textTxtPath))
{
	string fileContent = File.ReadAllText(textTxtPath); //we send the path from where we want to read
	Console.Write("==================================");
	Console.WriteLine(fileContent);
}

if (File.Exists(textTxtPath))
{
	File.Delete(textTxtPath);
}