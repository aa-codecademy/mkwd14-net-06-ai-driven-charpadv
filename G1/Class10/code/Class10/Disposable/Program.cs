using Helpers;

ExtendedConsole.PrintInColor("\n================== DISPOSING ==================\n\n", ConsoleColor.Cyan);
// => process of releasing unmanaged resources such as file handles, database connections, and network connections
// => it's important to dispose of these resources properly to avoid memory leaks and ensure the efficient use of resources

// => Are these connections disposed automatically? => No, we need to dispose of them manually, otherwise they will be disposed when the GC collects the object, but this is not deterministic and can lead to resource leaks if not done properly
// => What is disposed automatically ? => managed resources (objects that are managed by the GC) are disposed automatically when they are no longer referenced, but unmanaged resources (objects that are not managed by the GC) need to be disposed of manually

const string FolderPath = @"..\..\..\Text";
string FilePath = Path.Combine(FolderPath, "text.txt");

static void CreateFolder(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
}

static void CreateFile(string path)
{
    if (!File.Exists(path))
    {
        File.Create(path).Close();
    }
}

CreateFolder(FolderPath);
CreateFile(FilePath);

#region Manual Dispose Methods



#endregion


Console.ReadLine();