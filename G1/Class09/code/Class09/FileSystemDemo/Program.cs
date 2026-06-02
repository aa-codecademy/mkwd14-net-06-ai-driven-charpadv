using FileSystemDemo;

ConsoleHelper.WriteInColor("\n================== WORKING WITH FILE SYSTEM ==================\n", ConsoleColor.Cyan);
// File system is a way of organizing and storing data on storage devices like hard drives, SSDs, or USBs. It defines how files and directories are named, stored, and accessed.
// Usecases:
// => Saving Data (application configuration files, logs, user-generated content, reports etc..)
// => Data Processing (reading & processing data from files, CSV, xls, json...)
// => Temporary Storage (working with temporary files during processing, caching, etc.)

// System.IO is a namespace in C# that provides types (classes, enums, interfaces, etc.) to work with files, directories, and streams.
// Important classes: Directory, DirectoryInfo, File, FileInfo, Path, StreamReader, StreamWriter ...


#region Paths
ConsoleHelper.WriteInColor("\n================== PATHS ==================\n", ConsoleColor.Cyan);
// In file system operations, a path tells the program where a file or folder is located

// ===> ABSOLUTE PATHS
// An absolute path specifies the complete location of a file or folder starting from the root of the file system

// => Absolute directory (folder) path
string studentRepoClassFullPath = @"C:\Users\ilija.mitev\Desktop\New folder\CSharpAdv\students-repo\G1\Class09";
// => Absolute file path (ends with extension => .md in this case)
string studentRepoClassHomeworkFullPath = @"C:\Users\ilija.mitev\Desktop\New folder\CSharpAdv\students-repo\G1\Class09\Homework.md";

// ===> RELATIVE PATHS
// A relative path starts from the current working directory (usually where the app is running).
// NOTE: the relative path typically starts where the executable (.exe) file of the app is located (bin\Debug\net8.0\)
string classReadmeRelativePath = @"..\..\..\..\..\..\README.md";

#endregion


#region Directory
ConsoleHelper.WriteInColor("\n================== DIRECTORY (Folder) ==================\n", ConsoleColor.Cyan);
// The Directory class provides static methods to create, move, delete, and query folders 

// ===> Get Current Directory
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine($"Current Directory: {currentDirectory}");

// ===> Check if a folder exists
string testFolderPath = @"..\..\..\TestFolder";

bool testFolderExists = Directory.Exists(testFolderPath);

Console.WriteLine("The folder 'TestFolder' exists: {0}", testFolderExists);

// ===> Create new folder if it doesn't exist
if (!testFolderExists)
{
    Directory.CreateDirectory(testFolderPath);
    ConsoleHelper.WriteInColor("Succefully created folder TestFolder.", ConsoleColor.Green);
}
else
{
    ConsoleHelper.WriteInColor("TestFolder already exists.", ConsoleColor.DarkYellow);
}

// ===> Delete a folder
if (Directory.Exists(testFolderPath))
{
    // will delete the FOLDER if it is empty, or throw exception if contains any content
    //Directory.Delete(testFolderPath);
    // if you send the second argument (recursive) as true it will delete the FOLDER and IT'S CONTENT
    Directory.Delete(testFolderPath, recursive: true);
}

#endregion


#region File
ConsoleHelper.WriteInColor("\n================== FILE ==================\n", ConsoleColor.Cyan);
// The File class provides static methods to create, copy, delete, move, and open files, and helps with file read/write operations

// ===> Check if a file exists
// => Determine the file's path
testFolderPath = @"..\..\..\TestFolder";
string fileName = "example.txt";

// => using string interpolation (directory path + file name)
//string filePath = $@"{testFolderPath}\{fileName}";
// => using Path.Combine (BETTER WAY)
string filePath = Path.Combine(testFolderPath, fileName);

bool fileExists = File.Exists(filePath);

// NOTE: When creating a file, the directory(s) in the file's path must be created prior to the file creation
if (!Directory.Exists(testFolderPath))
{
    Directory.CreateDirectory(testFolderPath);
}

// ===> Create a new file
if (!fileExists)
{
    // NOTE: Important to CLOSE THE CONNECTION after creating or writing to a file
    File.Create(filePath).Close();
    //FileStream stream = File.Create(filePath);
    //stream.Close();
}
else
{
    ConsoleHelper.WriteInColor("File already exists.", ConsoleColor.DarkYellow);
}

// ===> Delete a file
//if (File.Exists(filePath))
//{
//    File.Delete(filePath);
//    ConsoleHelper.WriteInColor("Succefully deleted file 'example.txt'.", ConsoleColor.Green);
//}

// ===> Write to a file
File.WriteAllText(filePath, "Hello from SEDC :)\n");

// NOTE: The file get's re-writed when using WriteAllText
//File.WriteAllText(filePath, "Hello from Avenga Academy!");

// ===> Append text to a file
File.AppendAllText(filePath, "Hello from Avenga Academy!");

// ===> Read from a file
// This reads all the text content from the specified file
string fileContent = File.ReadAllText(filePath);
ConsoleHelper.WriteInColor("File content:\n");
ConsoleHelper.WriteInColor(fileContent, ConsoleColor.DarkGreen);

// ===> Get File Info
FileInfo fileInfo = new FileInfo(filePath);
ConsoleHelper.WriteInColor("\nThe File's info: ", ConsoleColor.Blue);
Console.WriteLine("Full Name " + fileInfo.FullName);
Console.WriteLine("File Name " + fileInfo.Name);
Console.WriteLine("Extension " + fileInfo.Extension);
Console.WriteLine("Size " + fileInfo.Length + " bytes");
Console.WriteLine("Last modified " + fileInfo.LastWriteTime);

#endregion


Console.ReadLine();