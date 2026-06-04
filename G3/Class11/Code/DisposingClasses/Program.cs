using DisposingClasses;

string appPath = @"..\..\..\Example";
string filePath = appPath + @"\example.txt";

#region ManualDispose
void AppendTextToFile(string text, string filePath)
{
	StreamWriter writer = new StreamWriter(filePath, true);
	writer.WriteLine(text);
	//throw new Exception("If an exception is thrown here, the Dispose method will not be called");
	//StreamWriter implements IDisposable interface (StreamWriter inherits from TextWriter and TextWriter impl IDisposable, so that means that StreamWriter has the Dispose method as well)
	//This method has to be called so that the writer is destroyed and the connection to the file is closed
	//Here we need to call this method explicitly, since we do not have a using block
	writer.Dispose(); //we can make sure that this is executed even if an error occurrs before this line if we put the call of the Dispose method in a finally block
}

void ReadTextFromFile(string filePath)
{
	StreamReader reader = new StreamReader(filePath);
	string text = reader.ReadToEnd();
	Console.WriteLine(text);
	//throw new Exception("If an exception is thrown here, the Dispose method will not be called");
	//StreamReader impl IDisposable interface, that means that it has impl of the Dispose method
	//This method has to be called so that the reader is destroyed and the connection to the file is closed
	//Here we need to call this method explicitly, since we do not have a using block
	reader.Dispose();
}

Directory.CreateDirectory(appPath);

try
{
	AppendTextToFile("Hello world", filePath);
	ReadTextFromFile(filePath);
}catch(Exception ex)
{
	Console.WriteLine(ex.Message);
}

#endregion

#region Disposing with using block
void AppendTextInFileWithUsing(string text, string filePath)
{
	using(StreamWriter writer = new StreamWriter(filePath, true))
	{
		writer.WriteLine(text);
	} //here, writer.Dispose() is automatically called, we don't have to call it ourselves
}

void ReadFromFileWithUsing(string filePath)
{
	using (StreamReader reader = new StreamReader(filePath))
	{
		string text = reader.ReadToEnd();
		Console.WriteLine(text);
	} //here, reader.Dispose() will be called automatically, we don't have to call it oursel
}

AppendTextInFileWithUsing("Test with using", filePath);
#endregion

#region Dispose with Custom class
void AppendTextToFileWithCustomWriter(string text, string filePath)
{
	using(CustomWriter writer = new CustomWriter(filePath))
	{
		writer.Write(text);
	} //here the Dispose from our method from our CustomWriter will be called
}

AppendTextToFileWithCustomWriter("Hello from custom writer", filePath);
AppendTextToFileWithCustomWriter("stop", filePath);
#endregion