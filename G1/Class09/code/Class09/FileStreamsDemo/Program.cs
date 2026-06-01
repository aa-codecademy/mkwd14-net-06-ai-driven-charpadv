using FileStreamsDemo;

ConsoleHelper.WriteInColor("\n================== FILE STREAMS ==================\n", ConsoleColor.Blue);
// File streams allow you to work with data in a more controlled, efficient, and memory-friendly way.
// NOTE: Working with files is generally considered a "heavy" operation that can consume significant processing resources.

// Benefits of using File Streams:
// - More control over how data is read/written (buffering, encoding, file mode, etc.)
// - Efficient memory usage (especially for large files)
// - Useful for reading/writing large files line by line or in chunks

// SETUP
string folderPath = @"..\..\..\TestFiles";

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

string fileName = "notes.txt";
string filePath = Path.Combine(folderPath, fileName);


ConsoleHelper.WriteInColor("\n================== StreamWriter ==================\n", ConsoleColor.Cyan);
// StreamWriter is better than File.WriteAllText for writing large files or writing data gradually (line by line).
// It gives you control over buffering and encoding.

try
{
    // The 'using' closes the connection made to the file automatically
    // The file is created automatically when using StreamWriter
    using (StreamWriter streamWriter = new StreamWriter(filePath))
    {
        streamWriter.WriteLine("This is a sample note.");
        streamWriter.WriteLine("StreamWriter lets us write text line by line efficiently.");
        streamWriter.WriteLine("It also allows you to append OR overwrite.");
    }

    using (StreamWriter streamWriter = new StreamWriter(filePath, true))
    {
        streamWriter.WriteLine("NEW This is a sample note.");
        streamWriter.WriteLine("NEW StreamWriter lets us write text line by line efficiently.");
        streamWriter.WriteLine("NEW It also allows you to append OR overwrite.");
    }
}
catch (Exception ex)
{
    ConsoleHelper.WriteInColor("Error writing in file. Error: " + ex.Message, ConsoleColor.Red);
}


ConsoleHelper.WriteInColor("\n================== StreamReader ==================\n", ConsoleColor.Cyan);
// StreamReader is better than File.ReadAllText for large files or reading line-by-line.
// It reads the file gradually, reducing memory usage for large content.

try
{
    using (StreamReader streamReader = new StreamReader(filePath))
    {
        ConsoleHelper.WriteInColor("Reading file content using StreamReader:\n", ConsoleColor.Yellow);

        // Read lines one at a time
        //string firstLine = streamReader.ReadLine();
        //Console.WriteLine("First line: " + firstLine);
        //string secondLine = streamReader.ReadLine();
        //Console.WriteLine("Second line: " + secondLine);

        // Read lines dynamically (until there are any) 
        string line = string.Empty;
        while ((line = streamReader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
catch (Exception ex)
{
    ConsoleHelper.WriteInColor("Error reading file. Error: " + ex.Message, ConsoleColor.Red);
}


Console.ReadLine();