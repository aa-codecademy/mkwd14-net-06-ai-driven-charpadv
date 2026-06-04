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

void AppendTextInFile(string text, string filePath)
{
    StreamWriter sw = new StreamWriter(filePath, true);
    sw.WriteLine(text);
    sw.Dispose();
}

void ReadFromFile(string path)
{
    StreamReader sr = new StreamReader(path);
    Console.WriteLine(sr.ReadToEnd());
    sr.Dispose();
}

void ManualDisposeExample()
{
    ExtendedConsole.PrintInColor("Enter text part 1: ");
    string text1 = Console.ReadLine();
    AppendTextInFile(text1, FilePath);

    ExtendedConsole.PrintInColor("Enter text part 2: ");
    string text2 = Console.ReadLine();
    AppendTextInFile(text2, FilePath);

    ExtendedConsole.PrintInColor("Enter text part 3: ");
    string text3 = Console.ReadLine();
    AppendTextInFile(text3, FilePath);

    Console.ReadLine();

    Console.WriteLine("----------------- Read -----------------\n");
    ReadFromFile(FilePath);
}

#endregion

#region Dispose with 'using' block (BETTER WAY)

void AppendTextInFileWithUsing(string text, string filePath)
{
    // The 'using' statement ensures that the StreamWriter is disposed of properly, even if an exception occurs.
    // It automatically calls Dispose() at the end of the block.
    using (StreamWriter sw = new StreamWriter(filePath, true))
    {
        sw.WriteLine(text);
    }
}

void ReadFromFileWithUsing(string path)
{
    using StreamReader sr = new StreamReader(path);
    Console.WriteLine(sr.ReadToEnd());
}

void UsingDisposeExample()
{
    ExtendedConsole.PrintInColor("Enter text part 1: ");
    string text1 = Console.ReadLine();
    AppendTextInFileWithUsing(text1, FilePath);

    ExtendedConsole.PrintInColor("Enter text part 2: ");
    string text2 = Console.ReadLine();
    AppendTextInFileWithUsing(text2, FilePath);

    ExtendedConsole.PrintInColor("Enter text part 3: ");
    string text3 = Console.ReadLine();
    AppendTextInFileWithUsing(text3, FilePath);

    Console.ReadLine();

    Console.WriteLine("----------------- Read -----------------\n");
    ReadFromFileWithUsing(FilePath);
}
#endregion


// Calling the examples
//ManualDisposeExample();
UsingDisposeExample();

Console.ReadLine();