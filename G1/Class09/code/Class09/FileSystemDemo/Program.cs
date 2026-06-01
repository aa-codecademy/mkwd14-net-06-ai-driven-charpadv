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






#endregion





Console.ReadLine();